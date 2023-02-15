using Microsoft.EntityFrameworkCore;
using StravaDataAnalyzerDataEF.Entities.Segment;
using StravaSegmentSniper.Data.Entities.Activity;
using StravaSegmentSniper.Data.Entities.Athlete;
using StravaSegmentSniper.Data.Entities.Misc;
using StravaSegmentSniper.Data.Entities.Token;
using StravaSegmentSniper.Data.Entities.User;

namespace StravaSegmentSniperReact.Data
{
    public class StravaSegmentSniperDbContext : DbContext, IStravaSegmentSniperDbContext
    {     

        public DbSet<DetailedAthlete> DetailedAthletes { get; set; }
        public DbSet<SummaryActivity> SummaryActivities { get; set; }
        public DbSet<DetailedActivity> DetailedActivities { get; set; }
        public DbSet<Bike> Bikes { get; set; }
        public DbSet<Gear> Gear { get; set; }
        public DbSet<Map> Maps { get; set; }
        public DbSet<Achievement> Achievements { get; set; }
        public DbSet<AthleteSegmentStat> AthleteSegmentStats { get; set; }
        public DbSet<DetailedSegment> DetailedSegments { get; set; }
        public DbSet<DetailedSegmentEffort> DetailedSegmentEfforts { get; set; }
        public DbSet<EffortCount> EffortCounts { get; set; }
        public DbSet<LocalLegend> LocalLegends { get; set; }
        public DbSet<SummarySegment> SummarySegments { get; set; }
        public DbSet<Xom> Xoms { get; set; }
        public DbSet<Token> Tokens { get; set; }
        public DbSet<ConsoleAppUser> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|StravaSegmentSniperData.mdf;Initial Catalog=StravaSegmentSniperData;Trusted_Connection=True;MultipleActiveResultSets=true");
        }
        //protected override void OnModelCreating(ModelBuilder builder)
        //{
        //    base.OnModelCreating(builder);
        //    builder.ConfigurePersistedGrantContext(_operationalStoreOptions.Value);
        //}
    }
}