using AutoMapper;
using StravaSegmentSniper.Data.DataAccess;
using StravaSegmentSniper.Data.Entities.Activity;
using StravaSegmentSniperServices.Library.Internal.Models.Activity;
using StravaSegmentSniperServices.Library.Internal.Models.Segment;
using StravaSegmentSniperServices.Library.StravaAPI;

namespace StravaSegmentSniperServices.Library.Internal.Services
{
    public class AthleteActivityService : IAthleteActivityService
    {
        private readonly IStravaAPIService _stravaAPIService;
        private readonly IMapper _mapper;
        private readonly ITokenService _tokenService;
        private readonly IDataAccessEF _dataAccessEF;

        public AthleteActivityService(IStravaAPIService stravaAPIService, IMapper mapper, ITokenService tokenService,
            IDataAccessEF dataAccessEF)
        {
            _stravaAPIService = stravaAPIService;
            _mapper = mapper;
            _tokenService = tokenService;
            _dataAccessEF = dataAccessEF;
        }
        public List<SummaryActivityModel> GetSummaryActivityForATimeRange(long stravaAthleteId, int after, int before)
        {
            List<SummaryActivityModel> returnList = new List<SummaryActivityModel>();
            string token = _tokenService.GetTokenByStravaAthleteId(stravaAthleteId).AuthorizationToken;
            returnList = _stravaAPIService.ViewAthleteActivity(after, before, token).Result;

            return returnList;
        }

        public DetailedActivityModel GetDetailedActivityByActivityId(long stravaAthleteId, long activityId)
        {
            string token = _tokenService.GetTokenByStravaAthleteId(stravaAthleteId).AuthorizationToken;
            return _stravaAPIService.GetDetailedActivityById(activityId, token).Result;
        }

        public List<DetailedSegmentModel> GetAllDetailedSegments(long stravaAthleteId)
        {
            string token = _tokenService.GetTokenByStravaAthleteId(stravaAthleteId).AuthorizationToken;
            //Get ist of activities for the athlete
            List<DetailedActivityModel> detailedActivites = new List<DetailedActivityModel>();
            // after 12/30/2022 = 1672426441
            // after 1/1/2020 = 1577904841
            List<SummaryActivityModel> summaryActivites = GetSummaryActivityForATimeRange(stravaAthleteId, 1672426441, 1673791441);

            //Get details of each activity for the athlete
            foreach (SummaryActivityModel activity in summaryActivites)
            {
                var activityToAdd = _stravaAPIService.GetDetailedActivityById(activity.Id, token).Result;
                detailedActivites.Add(activityToAdd);
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

        public string SaveDetailedActivityToDB(DetailedActivityModel model)
        {
            DetailedActivity activityToSave = new DetailedActivity
            {
                StravaActivityId = model.Id,
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

            int returnNum = _dataAccessEF.SaveDetailedActivity(activityToSave);

            switch (returnNum)
            {
                case 1:
                    return $"DetailedActivity Id {activityToSave.Id} was saved to the DB successfully";
                    break;
                case -1:
                    return $"Some shit went wrong saving DeatiledActivity Id {activityToSave.Id} to the database. Please contact support";
                    break;
                case -2:
                    return $"DetailedActivity Id {activityToSave.Id} already exists and was not updated.";
                    break;
                default:
                    return "This app needs A LOT of work";

            }
        }


    }
}
