using AutoMapper;
using StravaSegmentSniper.Data;
using StravaSegmentSniper.Data.DataAccess;
using StravaSegmentSniper.Data.Entities.Activity;
using StravaSegmentSniper.Services.Internal.Models.Activity;
using StravaSegmentSniper.Services.Internal.Models.Athlete;
using StravaSegmentSniper.Services.Internal.Models.Segment;
using StravaSegmentSniper.Services.StravaAPI;
using StravaSegmentSniper.Services.StravaAPI.Models.Activity;
using StravaSegmentSniper.Services.StravaAPI.Models.Athlete;

namespace StravaSegmentSniper.Services.Internal.Services
{
    public class AthleteActivityService : IAthleteActivityService
    {
        private readonly IStravaAPIService _stravaAPIService;
        private readonly IMapper _mapper;
        private readonly ITokenService _tokenService;
        private readonly StravaSegmentSniperDbContext _context;

        public AthleteActivityService(IStravaAPIService stravaAPIService, IMapper mapper, ITokenService tokenService, StravaSegmentSniperDbContext context
           )
        {
            _stravaAPIService = stravaAPIService;
            _mapper = mapper;
            _tokenService = tokenService;
            _context = context;
        }
        public List<SummaryActivityModel> GetSummaryActivityForATimeRange(int userId, int after, int before)
        {
            List<SummaryActivityModel> returnList = new List<SummaryActivityModel>();
            string token = _tokenService.GetTokenByUserId(userId).AuthorizationToken;
            returnList = _stravaAPIService.ViewAthleteActivity(after, before, token).Result;

            return returnList;
        }

        public DetailedActivityModel GetDetailedActivityByActivityId(int userId, long activityId)
        {
            string token =  _tokenService.GetTokenByUserId(userId).AuthorizationToken;

            var activityToReturn = _stravaAPIService.GetDetailedActivityById(activityId, token).Result;

            DetailedActivityModel model = _mapper
                                .Map<DetailedActivityAPIModel, DetailedActivityModel>(activityToReturn);

            return model;
        }

        public List<DetailedSegmentModel> GetAllDetailedSegments(int userId)
        {
            string token = _tokenService.GetTokenByUserId(userId).AuthorizationToken;
            //Get ist of activities for the athlete
            List<DetailedActivityModel> detailedActivites = new List<DetailedActivityModel>();
            // after 12/30/2022 = 1672426441
            // after 1/1/2020 = 1577904841
            List<SummaryActivityModel> summaryActivites = GetSummaryActivityForATimeRange(userId, 1672426441, 1673791441);

            //Get details of each activity in the list of SummaryActivities
            foreach (SummaryActivityModel activity in summaryActivites)
            {
                var activityToAdd = _stravaAPIService.GetDetailedActivityById(activity.Id, token).Result;


                DetailedActivityModel model = _mapper
                    .Map<DetailedActivityAPIModel, DetailedActivityModel>(activityToAdd);

                detailedActivites.Add(model);
            }

            //Get list of segment efforts for each activity
            List<DetailedSegmentEffortModel> segmentEffortsList = new List<DetailedSegmentEffortModel>();
            foreach (DetailedActivityModel detailedActivity in detailedActivites)
            {
                foreach (DetailedSegmentEffortModel segment in detailedActivity.SegmentEfforts)
                {
                    segmentEffortsList.Add(segment);
                }
            }

            //Get list of segments for each of the segments in the list of segmentEfforts
            List<DetailedSegmentModel> segments = new List<DetailedSegmentModel>();
            foreach (DetailedSegmentEffortModel dsem in segmentEffortsList)
            {
                DetailedSegmentModel segment = _stravaAPIService.GetDetailedSegmentById(dsem.Segment.Id, token).Result;
                segments.Add(segment);
            }

            return segments;
        }

        public int SaveDetailedActivityToDB(DetailedActivityModel model, int detailedAthleteId)
        {
            DetailedActivity activityToSave = new DetailedActivity
            {
                StravaActivityId = model.Id,
                DetailedAthleteId = detailedAthleteId,
                StravaAthleteId = model.Athlete.Id,
                Name = model.Name,
                Distance = model.Distance,
                MovingTime = model.MovingTime,
                ElapsedTime = model.ElapsedTime,
                TotalElevationGain = model.TotalElevationGain,
                Type = model.Type,
                SportType = model.SportType,
                StartDate = model.StartDate,
                AchievementCount = model.AchievementCount,
                AverageSpeed = model.AverageSpeed,
                MaxSpeed = model.MaxSpeed,
                ElevHigh = model.ElevHigh,
                ElevLow = model.ElevLow,
                PrCount = model.PrCount,
                HasKudoed = model.HasKudoed,
                Description = model.Description
            };

            var existingActivityCount = _context.DetailedActivities.Where(x => x.Id == detailedActivity.Id).Count();
            if (existingActivityCount > 0)
            {
                return -2;
            }
            else
            {
                _context.DetailedActivities.Add(activityToSave);

                if (_context.SaveChanges() == 1)
                    return 1;
                return -1;
            }


        }
    }
}
