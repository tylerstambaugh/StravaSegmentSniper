using Microsoft.EntityFrameworkCore;
using StravaDataAnalyzerDataEF.Entities.Segment;
using StravaSegmentSniper.Data.Entities.Activity;
using StravaSegmentSniper.Data.Entities.Athlete;
using StravaSegmentSniper.Data.Entities.Misc;
using StravaSegmentSniper.Data.Entities.Token;

namespace StravaSegmentSniper.Data
{
    public interface IStravaSegmentSniperDbContext
    {
        DbSet<Achievement> Achievements { get; set; }
        DbSet<AthleteSegmentStat> AthleteSegmentStats { get; set; }
        DbSet<Bike> Bikes { get; set; }
        DbSet<DetailedActivity> DetailedActivities { get; set; }
        DbSet<DetailedAthlete> DetailedAthletes { get; set; }
        DbSet<DetailedSegmentEffort> DetailedSegmentEfforts { get; set; }
        DbSet<DetailedSegment> DetailedSegments { get; set; }
        DbSet<EffortCount> EffortCounts { get; set; }
        DbSet<Gear> Gear { get; set; }
        DbSet<LocalLegend> LocalLegends { get; set; }
        DbSet<Map> Maps { get; set; }
        DbSet<SummaryActivity> SummaryActivities { get; set; }
        DbSet<SummarySegment> SummarySegments { get; set; }
        DbSet<Token> Tokens { get; set; }
        DbSet<Xom> Xoms { get; set; }
    }
}