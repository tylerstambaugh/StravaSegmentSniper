using AutoMapper;
using StravaDataAnalyzerDataEF.Entities.Segment;
using StravaSegmentSniper.Data.Entities.Activity;
using StravaSegmentSniper.Data.Entities.Athlete;
using StravaSegmentSniper.Data.Entities.Misc;
using StravaSegmentSniper.Data.Entities.Token;
using StravaSegmentSniper.Library.StravaAPI.Models.Activity;
using StravaSegmentSniperServices.Library.Internal.Models.Activity;
using StravaSegmentSniperServices.Library.Internal.Models.Athlete;
using StravaSegmentSniperServices.Library.Internal.Models.Misc;
using StravaSegmentSniperServices.Library.Internal.Models.Segment;
using StravaSegmentSniperServices.Library.Internal.Models.Token;
using StravaSegmentSniperServices.Library.StravaAPI.Models.Activity;
using StravaSegmentSniperServices.Library.StravaAPI.Models.Athlete;
using StravaSegmentSniperServices.Library.StravaAPI.Models.Misc;
using StravaSegmentSniperServices.Library.StravaAPI.Models.Segment;

namespace StravaSegmentSniper.ConsoleUI.Helpers
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            SourceMemberNamingConvention = new LowerUnderscoreNamingConvention();
            DestinationMemberNamingConvention = new PascalCaseNamingConvention();

            //map API models to service models. 
            CreateMap<AthleteAPIModel, MetaAthleteModel>();
            CreateMap<DetailedAthleteAPIModel, DetailedAthleteModel>();
            CreateMap<DetailedActivityAPIModel, DetailedActivityModel>();
            CreateMap<ActivityAPIModel, ActivityModel>();
            CreateMap<SummaryActivityAPIModel, SummaryActivityModel>();
            CreateMap<ActivityStatsAPIModel, ActivityStatsModel>();
            CreateMap<SummarySegmentAPIModel, SummarySegmentModel>();
            CreateMap<DetailedSegmentEffortAPIModel, DetailedSegmentEffortModel>();
            CreateMap<DetailedSegmentAPIModel, DetailedSegmentModel>();
            CreateMap<AchievementAPIModel, AchievementModel>();
            CreateMap<LocalLegendAPIModel, LocalLegendModel>();
            CreateMap<AthleteSegmentStatsAPIModel, AthleteSegmentStatsModel>();
            CreateMap<EffortCountsAPIModel, EffortCountsModel>();
            CreateMap<XomsAPIModel, XomsModel>();
            CreateMap<MapAPIModel, PolylineMapModel>();
            CreateMap<SplitsMetricAPIModel, SplitsMetricModel>();
            CreateMap<SplitsStandardAPIModel, SplitsStandardModel>();
            CreateMap<LapAPIModel, LapModel>();
            CreateMap<DestinationAPIModel, DestinationModel>();
            CreateMap<GearAPIModel, GearModel>();
            CreateMap<PhotosAPIModel, PhotosModel>();
            CreateMap<StatsVisibilityAPIModel, StatsVisibilityModel>();

            //map service models to Entities. 
            CreateMap<ActivityModel, Activity>();
            CreateMap<DetailedActivityModel, DetailedActivity>();
            CreateMap<SummaryActivityModel, SummaryActivity>();
            CreateMap<DetailedAthleteModel, DetailedAthlete>();
            CreateMap<AchievementModel, Achievement>();
            CreateMap<PolylineMapModel, Map>();
            CreateMap<GearModel, Gear>();
            CreateMap<AthleteSegmentStatsModel, AthleteSegmentStat>();
            CreateMap<DetailedSegmentModel, DetailedSegment>();
            CreateMap<DetailedSegmentEffortModel, DetailedSegmentEffort>();
            CreateMap<EffortCountsModel, EffortCount>();
            CreateMap<LocalLegendModel, LocalLegend>();
            CreateMap<SummarySegmentModel, SummarySegment>();
            CreateMap<XomsModel, Xom>();
            CreateMap<TokenModel, Token>();

        }
    }
}
