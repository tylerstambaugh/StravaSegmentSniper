using AutoMapper;
using StravaSegmentSniper.Data;
using StravaSegmentSniper.Data.Entities.Activity;
using StravaSegmentSniper.Services.Internal.Models.Activity;
using StravaSegmentSniper.Services.Internal.Models.Segment;
using StravaSegmentSniper.Services.StravaAPI;
using StravaSegmentSniper.Services.StravaAPI.Activity;
using StravaSegmentSniper.Services.StravaAPI.Models.Activity;
using StravaSegmentSniper.Services.StravaAPI.Segment;

namespace StravaSegmentSniper.Services.Internal.Services
{
    public class AthleteActivityService : IAthleteActivityService
    {
        private readonly IStravaApiActivity _stravaAPIActivity;
        private readonly IStravaApiSegment _stravaAPISegment;
        private readonly StravaSegmentSniperDbContext _context;

        public AthleteActivityService(IStravaApiActivity stravaAPIActivity,
                                      IStravaApiSegment stravaAPISegment,
                                      StravaSegmentSniperDbContext context)
        {            
            _stravaAPIActivity = stravaAPIActivity;
            _stravaAPISegment = stravaAPISegment;
            _context = context;
        }  

        public List<DetailedSegmentModel> GetAllDetailedSegments(string userId)
        {
           // string token = _tokenService.GetTokenByUserId(userId).AuthorizationToken;
            //Get ist of activities for the athlete
            List<DetailedActivityModel> detailedActivites = new List<DetailedActivityModel>();
            // after 12/30/2022 = 1672426441
            // after 1/1/2020 = 1577904841
            List<SummaryActivityModel> summaryActivites = GetSummaryActivityForATimeRange(userId, 1672426441, 1673791441);

            //Get details of each activity in the list of SummaryActivities
            foreach (SummaryActivityModel activity in summaryActivites)
            {
                var activityToAdd = _stravaAPIActivity.GetDetailedActivityById(activity.Id, userId).Result;

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
                DetailedSegmentModel segment = _stravaAPISegment.GetDetailedSegmentById(dsem.Segment.Id, userId).Result;
                segments.Add(segment);
            }

            return segments;
        }
        public List<SummaryActivityModel> GetSummaryActivityForATimeRange(string userId, int after, int before)
        {
            List<SummaryActivityModel> returnList = new List<SummaryActivityModel>();
            //string token = _tokenService.GetTokenByUserId(userId).AuthorizationToken;
            returnList = _stravaAPIActivity.GetSummaryActivityForTimeRange(after, before, userId).Result;

            return returnList;
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

            var existingActivityCount = _context.DetailedActivities.Where(x => x.Id == activityToSave.Id).Count();
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
