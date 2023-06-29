﻿using StravaSegmentSniper.React.Controllers.Contracts;
using StravaSegmentSniper.Services.Internal.Adapters;
using StravaSegmentSniper.Services.Internal.Models.Activity;
using StravaSegmentSniper.Services.Internal.Models.Segment;
using StravaSegmentSniper.Services.Internal.Services;
using StravaSegmentSniper.Services.StravaAPI.Activity;
using StravaSegmentSniper.Services.StravaAPI.Segment;
using StravaSegmentSniper.Services.UIModels.Segment;
using System.Security.Claims;
using System.Text.RegularExpressions;

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
            try
            {
            //get detailed activity by Id
                var user = _webAppUserService.GetLoggedInUserById(_httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier).ToString());
                var stravaAthleteId = user.StravaAthleteId;
                DetailedActivityModel detailedActivityModel = _stravaAPIActivity.GetDetailedActivityById(contract.ActivityId, stravaAthleteId).Result;

                List<DetailedSegmentEffortModel> segmentEfforts = detailedActivityModel.SegmentEfforts;

                //limiting the list to 5 for testing to not blow up API call count
                segmentEfforts = segmentEfforts.GetRange(0, 5);

                List<DetailedSegmentModel> segmentModels = new List<DetailedSegmentModel>();
                List<SnipedSegmentUIModel> snipedSegments = new List<SnipedSegmentUIModel>();

                foreach (DetailedSegmentEffortModel segmentEffortModel in segmentEfforts)
                {
                    //get detailed segments for each segment Id
                    DetailedSegmentModel model = _stravaSegment.GetDetailedSegmentById(segmentEffortModel.Segment.Id, stravaAthleteId).Result;
                    segmentModels.Add(model);

                    //do sniping on list of segments
                        XomsTimes xomsTime = GetXomTimeFromStrings(model.Xoms);

                    double percentageOff = Math.Round((double)((segmentEffortModel.MovingTime - xomsTime.KomTime) / (double)xomsTime.KomTime), 3) * 100;
                    
                    int secondsOff = 0;

                    if (contract.SecondsFromKom != null && contract.SecondsFromKom > 0)
                    {
                        secondsOff = segmentEffortModel.MovingTime - xomsTime.KomTime;
                    }

                    SnipedSegmentUIModel UiModel = new SnipedSegmentUIModel
                    {
                        Id = model.Id,
                        Name = model.Name,
                        PercentageFromKom = percentageOff,
                        SecondsFromKom = secondsOff,
                        ActivityType = model.ActivityType,
                        Distance = Math.Round(CommonConversionHelpers.ConvertMetersToMiles(model.Distance), 2),
                        KomTime = model.Xoms.Kom,
                        CreatedAt = model.CreatedAt,
                        Map = model.Map,
                        EffortCount = model.EffortCount,
                        AthleteCount = model.AthleteCount,
                        Starred = model.Starred,
                        StarCount = model.StarCount,
                        AthleteSegmentStats = model.AthleteSegmentStats,
                        Xoms = model.Xoms,

                    };

                    if (percentageOff < contract.PercentageFromKom || secondsOff < contract.SecondsFromKom)
                    {
                        snipedSegments.Add(UiModel);
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
            time = RemoveLetters(time);

            int returnTime = 0;
            string[] timeParts = time.Split(':');

            for (int i = 0; i <= timeParts.Length - 1; i++)
            {
                int factor = (int)Math.Pow(60, i);
                returnTime += int.Parse(timeParts[timeParts.Length-(i+1)]) * factor;
            }
            return returnTime;
        }

        private string RemoveLetters(string input)
        {
            Regex regex = new Regex("[^0-9:]");
            return regex.Replace(input, "");
        }

        private class XomsTimes
        {
            public int KomTime { get; set; }
            public int QomTime { get; set; }
        }
    }

 
}
