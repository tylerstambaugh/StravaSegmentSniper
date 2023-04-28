using AutoMapper;
using StravaDataAnalyzerDataEF.Entities.Segment;
using StravaSegmentSniper.Data.Entities.Activity;
using StravaSegmentSniper.Data.Entities.Athlete;
using StravaSegmentSniper.Data.Entities.Misc;
using StravaSegmentSniper.Data.Entities.Token;
using StravaSegmentSniper.Services.Internal.Models.Activity;
using StravaSegmentSniper.Services.Internal.Models.Athlete;
using StravaSegmentSniper.Services.Internal.Models.Misc;
using StravaSegmentSniper.Services.Internal.Models.Segment;
using StravaSegmentSniper.Services.Internal.Models.Token;
using StravaSegmentSniper.Services.StravaAPI.Models.Activity;
using StravaSegmentSniper.Services.StravaAPI.Models.Athlete;
using StravaSegmentSniper.Services.StravaAPI.Models.Misc;
using StravaSegmentSniper.Services.StravaAPI.Models.Segment;
using StravaSegmentSniper.Services.StravaAPI.Models.Token;

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
            CreateMap<ClubAPIModel, ClubModel>();
            CreateMap<BikeAPIModel, BikeModel>();
            CreateMap<PhotosAPIModel, PhotosModel>();
            CreateMap<StatsVisibilityAPIModel, StatsVisibilityModel>();
            CreateMap<RefreshTokenAPIModel, RefreshTokenModel>();

            //map service models to Entities. 
            CreateMap<DetailedActivityModel, DetailedActivity>();
            CreateMap<SummaryActivityModel, SummaryActivity>();
            CreateMap<DetailedAthleteModel, DetailedAthlete>();
            CreateMap<AchievementModel, Achievement>();
            CreateMap<PolylineMapModel, Map>();
            CreateMap<GearModel, Gear>();
            CreateMap<BikeModel, Bike>();
            CreateMap<AthleteSegmentStatsModel, AthleteSegmentStat>();
            CreateMap<DetailedSegmentModel, DetailedSegment>();
            CreateMap<DetailedSegmentEffortModel, DetailedSegmentEffort>();
            CreateMap<EffortCountsModel, EffortCount>();
            CreateMap<LocalLegendModel, LocalLegend>();
            CreateMap<SummarySegmentModel, SummarySegment>();
            CreateMap<XomsModel, Xom>();
            CreateMap<StravaApiTokenModel, StravaApiToken>();

        }
    }
}
