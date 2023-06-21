using StravaSegmentSniper.React.Controllers.Contracts;
using StravaSegmentSniper.Services.Internal.Models.Activity;
using StravaSegmentSniper.Services.Internal.Models.Segment;
using StravaSegmentSniper.Services.Internal.Services;
using StravaSegmentSniper.Services.StravaAPI.Activity;
using StravaSegmentSniper.Services.StravaAPI.Segment;
using StravaSegmentSniper.Services.UIModels.Segment;
using System.Security.Claims;

namespace StravaSegmentSniper.React.ActionHandlers.Segment
{
    public class StravaSegmentActionHandler : IStravaSegmentActionHandler
    {
        private readonly IStravaAPIActivity _stravaAPIActivity;
        private readonly IStravaAPISegment _stravaSegment;
        private readonly IWebAppUserService _webAppUserService;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public StravaSegmentActionHandler(IStravaAPIActivity stravaAPIActivity, IStravaAPISegment stravaSegment, IWebAppUserService webAppUserService, IHttpContextAccessor httpContextAccessor)
        {
            _stravaAPIActivity = stravaAPIActivity;
            _stravaSegment = stravaSegment;
            _webAppUserService = webAppUserService;
            _httpContextAccessor = httpContextAccessor;
        }

        public List<SnipedSegmentUIModel> HandleSnipingSegments(SegmentSniperContract contract)
        {

            //get detailed activity by Id
            try
            {


                var user = _webAppUserService.GetLoggedInUserById(_httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier).ToString());
                var stravaAthleteId = user.StravaAthleteId;
                DetailedActivityModel detailedActivityModel = _stravaAPIActivity.GetDetailedActivityById(contract.ActivityId, stravaAthleteId).Result;

                List<DetailedSegmentEffortModel> segmentsEfforts = detailedActivityModel.SegmentEfforts;

                List<DetailedSegmentModel> segmentModels = new List<DetailedSegmentModel>();
                List<SnipedSegmentUIModel> snipedSegments = new List<SnipedSegmentUIModel>();

                foreach (DetailedSegmentEffortModel segmentEffortModel in segmentsEfforts)
                {
                    //get detailed segments for each segment Id
                    DetailedSegmentModel model = _stravaSegment.GetDetailedSegmentById(segmentEffortModel.Id, stravaAthleteId).Result;
                    segmentModels.Add(model);

                    //do sniping on list of segments
                    XomsTimes xomsTime = GetXomTimeFromStrings(model.Xoms);

                    double percentageOff = 0;
                    int secondsOff = 0;
                    if (contract.PercentageFromKom > 0)
                    {
                        percentageOff = xomsTime.KomTime / (segmentEffortModel.MovingTime - xomsTime.KomTime);
                    }

                    if (contract.SecondsFromKom > 0)
                    {
                        secondsOff = segmentEffortModel.MovingTime - xomsTime.KomTime;
                    }

                    SnipedSegmentUIModel uIModel = new SnipedSegmentUIModel
                    {
                        Id = model.Id,
                        Name = model.Name,
                        LeaderboardPlace = 99,
                        PercentageFromKom = percentageOff,
                        SecondsOff = secondsOff,
                        ActivityType = model.ActivityType,
                        Distance = model.Distance,
                        CreatedAt = model.CreatedAt,
                        Map = model.Map,
                        EffortCount = model.EffortCount,
                        AthleteCount = model.AthleteCount,
                        StarCount = model.StarCount,
                        AthleteSegmentStats = model.AthleteSegmentStats,
                        Xoms = model.Xoms,

                    };

                    if (percentageOff < contract.PercentageFromKom || secondsOff < contract.SecondsFromKom)
                    {
                        snipedSegments.Add(uIModel);
                    }
                }

                return snipedSegments;
            }
            catch(Exception e)
            {
                throw new Exception(e.Message);
            }


        }

        private XomsTimes GetXomTimeFromStrings(XomsModel xoms)
        {
            return new XomsTimes
            {
                KomTime = GetTimeFromString(xoms.Kom),
                QomTime = GetTimeFromString(xoms.Qom)
            };
        }

        private int GetTimeFromString(string time)
        {

            int returnTime = 0;
            string[] timeParts = time.Split(':');

            for (int i = 0; i < timeParts.Length; i++)
            {
                int factor = i * 60;
                returnTime += int.Parse(timeParts[timeParts.Length-i]) * factor;
            }
            return returnTime;
        }

        private class XomsTimes
        {
            public int KomTime { get; set; }
            public int QomTime { get; set; }
        }
    }

 
}
