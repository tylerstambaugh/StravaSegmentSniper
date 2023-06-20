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
            //get detailed segments for each segment Id
            //do sniping on list of segments

            var user = _webAppUserService.GetLoggedInUserById(_httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier).ToString());
            var stravaAthleteId = user.StravaAthleteId;
            DetailedActivityModel detailedActivityModel = _stravaAPIActivity.GetDetailedActivityById(contract.ActivityId, stravaAthleteId).Result;

            List<DetailedSegmentEffortModel> segmentsEfforts = detailedActivityModel.SegmentEfforts;

            List<DetailedSegmentModel> segmentModels = new List<DetailedSegmentModel>();
            List<SnipedSegmentUIModel> snipedSegments = new List<SnipedSegmentUIModel>();

            foreach (DetailedSegmentEffortModel segmentEffortModel in segmentsEfforts)
            {
                DetailedSegmentModel model = _stravaSegment.GetDetailedSegmentById(segmentEffortModel.Id, stravaAthleteId).Result;
                segmentModels.Add(model);

                XomsTimes xomsTime = GetXomTimeFromStrings(model.Xoms);

                if (contract.PercentageFromTopTen != null && contract.PercentageFromTopTen > 0)
                {
                    var percentageOff = xomsTime.komTime / (segmentEffortModel.MovingTime - xomsTime.komTime) ;
                }
            }

            throw new NotImplementedException();

        }

        private XomsTimes GetXomTimeFromStrings(XomsModel xoms)
        {
            XomsTimes returnTimes = new XomsTimes();

            returnTimes.komTime = GetTimeFromString(xoms.Kom);
            returnTimes.qomTime = GetTimeFromString(xoms.Qom);
            return returnTimes;
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
    }

    class XomsTimes
    {
        public XomsTimes()
        {

        }
        public int komTime { get; set; }
        public int qomTime { get; set; }
    }
}
