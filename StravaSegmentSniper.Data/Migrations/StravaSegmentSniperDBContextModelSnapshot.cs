﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using StravaSegmentSniper.Data;

#nullable disable

namespace StravaSegmentSniper.Data.Migrations
{
    [DbContext(typeof(StravaSegmentSniperDbContext))]
    partial class StravaSegmentSniperDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Proxies:ChangeTracking", false)
                .HasAnnotation("Proxies:CheckEquality", false)
                .HasAnnotation("Proxies:LazyLoading", true)
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("StravaDataAnalyzerDataEF.Entities.Segment.Achievement", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<long>("DetailedSegementEffortId")
                        .HasColumnType("bigint");

                    b.Property<int>("DetailedSegmentEffortId")
                        .HasColumnType("int");

                    b.Property<int>("Rank")
                        .HasColumnType("int");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TypeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DetailedSegementEffortId");

                    b.ToTable("Achievements");
                });

            modelBuilder.Entity("StravaDataAnalyzerDataEF.Entities.Segment.AthleteSegmentStat", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("DetailedActivityId")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<int?>("DetailedSegmentId")
                        .HasColumnType("int");

                    b.Property<int?>("EffortCount")
                        .HasColumnType("int");

                    b.Property<string>("PrDate")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("PrElapsedTime")
                        .HasColumnType("int");

                    b.Property<long?>("StravaActivityId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("DetailedActivityId");

                    b.HasIndex("DetailedSegmentId");

                    b.ToTable("AthleteSegmentStats");
                });

            modelBuilder.Entity("StravaDataAnalyzerDataEF.Entities.Segment.DetailedSegment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AthleteCount")
                        .HasColumnType("int");

                    b.Property<double>("AverageGrade")
                        .HasColumnType("float");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Distance")
                        .HasColumnType("float");

                    b.Property<int>("EffortCount")
                        .HasColumnType("int");

                    b.Property<double>("ElevationHigh")
                        .HasColumnType("float");

                    b.Property<double>("ElevationLow")
                        .HasColumnType("float");

                    b.Property<int>("LocalLegendId")
                        .HasColumnType("int");

                    b.Property<double>("MaximumGrade")
                        .HasColumnType("float");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("StarCount")
                        .HasColumnType("int");

                    b.Property<bool>("Starred")
                        .HasColumnType("bit");

                    b.Property<long>("StravaSegmentId")
                        .HasColumnType("bigint");

                    b.Property<double>("TotalElevationGain")
                        .HasColumnType("float");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("LocalLegendId");

                    b.ToTable("DetailedSegments");
                });

            modelBuilder.Entity("StravaDataAnalyzerDataEF.Entities.Segment.DetailedSegmentEffort", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<int>("ActivityId")
                        .HasColumnType("int");

                    b.Property<int>("AthleteId")
                        .HasColumnType("int");

                    b.Property<double>("AverageHeartrate")
                        .HasColumnType("float");

                    b.Property<double>("AverageWatts")
                        .HasColumnType("float");

                    b.Property<long>("DetailedActivityId")
                        .HasColumnType("bigint");

                    b.Property<double>("Distance")
                        .HasColumnType("float");

                    b.Property<int>("ElapsedTime")
                        .HasColumnType("int");

                    b.Property<double>("MaxHeartrate")
                        .HasColumnType("float");

                    b.Property<int>("MovingTime")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("PrRank")
                        .HasColumnType("int");

                    b.Property<DateTime>("StartDateLocal")
                        .HasColumnType("datetime2");

                    b.Property<int>("SummarySegmentId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ActivityId");

                    b.HasIndex("AthleteId");

                    b.HasIndex("SummarySegmentId");

                    b.ToTable("DetailedSegmentEfforts");
                });

            modelBuilder.Entity("StravaDataAnalyzerDataEF.Entities.Segment.EffortCount", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Female")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Overall")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("EffortCounts");
                });

            modelBuilder.Entity("StravaDataAnalyzerDataEF.Entities.Segment.LocalLegend", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Destination")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("DetailedSegmentEffortId")
                        .HasColumnType("bigint");

                    b.Property<string>("EffortCount")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("EffortCountId")
                        .HasColumnType("int");

                    b.Property<string>("EffortDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Profile")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("StravaAthleteId")
                        .HasColumnType("bigint");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("DetailedSegmentEffortId");

                    b.HasIndex("EffortCountId");

                    b.ToTable("LocalLegends");
                });

            modelBuilder.Entity("StravaDataAnalyzerDataEF.Entities.Segment.SummarySegment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ActivityType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("AverageGrade")
                        .HasColumnType("float");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ClimbCategory")
                        .HasColumnType("int");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Distance")
                        .HasColumnType("float");

                    b.Property<double>("ElevationHigh")
                        .HasColumnType("float");

                    b.Property<double>("ElevationLow")
                        .HasColumnType("float");

                    b.Property<string>("ElevationProfile")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Hazardous")
                        .HasColumnType("bit");

                    b.Property<double>("MaximumGrade")
                        .HasColumnType("float");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Private")
                        .HasColumnType("bit");

                    b.Property<bool>("Starred")
                        .HasColumnType("bit");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("StravaSegmentID")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.ToTable("SummarySegments");
                });

            modelBuilder.Entity("StravaDataAnalyzerDataEF.Entities.Segment.Xom", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<long>("DetailedSegmentEffortId")
                        .HasColumnType("bigint");

                    b.Property<int?>("DetailedSegmentId")
                        .HasColumnType("int");

                    b.Property<string>("Kom")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Overall")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Qom")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("DetailedSegmentEffortId");

                    b.HasIndex("DetailedSegmentId");

                    b.ToTable("Xoms");
                });

            modelBuilder.Entity("StravaSegmentSniper.Data.Entities.Activity.DetailedActivity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("AchievementCount")
                        .HasColumnType("int");

                    b.Property<double?>("AverageSpeed")
                        .HasColumnType("float");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("DetailedAthleteId")
                        .HasColumnType("int");

                    b.Property<double?>("Distance")
                        .HasColumnType("float");

                    b.Property<int?>("ElapsedTime")
                        .HasColumnType("int");

                    b.Property<double?>("ElevHigh")
                        .HasColumnType("float");

                    b.Property<double?>("ElevLow")
                        .HasColumnType("float");

                    b.Property<bool?>("HasKudoed")
                        .HasColumnType("bit");

                    b.Property<double?>("MaxSpeed")
                        .HasColumnType("float");

                    b.Property<int?>("MovingTime")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("PrCount")
                        .HasColumnType("int");

                    b.Property<string>("SportType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<long>("StravaActivityId")
                        .HasColumnType("bigint");

                    b.Property<long>("StravaAthleteId")
                        .HasColumnType("bigint");

                    b.Property<double?>("TotalElevationGain")
                        .HasColumnType("float");

                    b.Property<string>("Type")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("DetailedAthleteId");

                    b.ToTable("DetailedActivities");
                });

            modelBuilder.Entity("StravaSegmentSniper.Data.Entities.Activity.SummaryActivity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("AchievementCount")
                        .HasColumnType("int");

                    b.Property<int>("AthleteId")
                        .HasColumnType("int");

                    b.Property<double?>("AverageSpeed")
                        .HasColumnType("float");

                    b.Property<int>("DetailedActivityId")
                        .HasColumnType("int");

                    b.Property<double?>("Distance")
                        .HasColumnType("float");

                    b.Property<int?>("ElapsedTime")
                        .HasColumnType("int");

                    b.Property<double?>("MaxSpeed")
                        .HasColumnType("float");

                    b.Property<int?>("MovingTime")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("PrCount")
                        .HasColumnType("int");

                    b.Property<DateTime?>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("StartDateLocal")
                        .HasColumnType("datetime2");

                    b.Property<int>("StravaAthleteId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AthleteId");

                    b.HasIndex("DetailedActivityId");

                    b.ToTable("SummaryActivities");
                });

            modelBuilder.Entity("StravaSegmentSniper.Data.Entities.Athlete.DetailedAthlete", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("AthleteType")
                        .HasColumnType("int");

                    b.Property<string>("Bio")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("DatePreference")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Firstname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("FollowerCount")
                        .HasColumnType("int");

                    b.Property<int?>("FriendCount")
                        .HasColumnType("int");

                    b.Property<string>("Lastname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MeasurementPreference")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("MutualFriendCount")
                        .HasColumnType("int");

                    b.Property<string>("Profile")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProfileMedium")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Sex")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("State")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("StravaAthleteId")
                        .HasColumnType("bigint");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double?>("Weight")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("DetailedAthletes");
                });

            modelBuilder.Entity("StravaSegmentSniper.Data.Entities.Misc.Bike", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<double>("ConvertedDistance")
                        .HasColumnType("float");

                    b.Property<int>("DetailedAthleteId")
                        .HasColumnType("int");

                    b.Property<int>("Distance")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nickname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Primary")
                        .HasColumnType("bit");

                    b.Property<bool>("Retired")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("DetailedAthleteId");

                    b.ToTable("Bikes");
                });

            modelBuilder.Entity("StravaSegmentSniper.Data.Entities.Misc.Gear", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<double>("ConvertedDistance")
                        .HasColumnType("float");

                    b.Property<int>("Distance")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nickname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Primary")
                        .HasColumnType("bit");

                    b.Property<bool>("Retired")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("Gear");
                });

            modelBuilder.Entity("StravaSegmentSniper.Data.Entities.Misc.Map", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Polyline")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SummaryPolyline")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Maps");
                });

            modelBuilder.Entity("StravaSegmentSniper.Data.Entities.Token.StravaApiToken", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("AuthorizationToken")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("ExpiresAt")
                        .HasColumnType("bigint");

                    b.Property<long>("ExpiresIn")
                        .HasColumnType("bigint");

                    b.Property<string>("RefreshToken")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("StravaApiTokens");
                });

            modelBuilder.Entity("StravaDataAnalyzerDataEF.Entities.Segment.Achievement", b =>
                {
                    b.HasOne("StravaDataAnalyzerDataEF.Entities.Segment.DetailedSegmentEffort", "DetailedSegementEffort")
                        .WithMany("Achievements")
                        .HasForeignKey("DetailedSegementEffortId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DetailedSegementEffort");
                });

            modelBuilder.Entity("StravaDataAnalyzerDataEF.Entities.Segment.AthleteSegmentStat", b =>
                {
                    b.HasOne("StravaSegmentSniper.Data.Entities.Activity.DetailedActivity", "DetailedActivity")
                        .WithMany()
                        .HasForeignKey("DetailedActivityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("StravaDataAnalyzerDataEF.Entities.Segment.DetailedSegment", null)
                        .WithMany("AthleteSegmentStats")
                        .HasForeignKey("DetailedSegmentId");

                    b.Navigation("DetailedActivity");
                });

            modelBuilder.Entity("StravaDataAnalyzerDataEF.Entities.Segment.DetailedSegment", b =>
                {
                    b.HasOne("StravaDataAnalyzerDataEF.Entities.Segment.LocalLegend", "LocalLegend")
                        .WithMany()
                        .HasForeignKey("LocalLegendId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("LocalLegend");
                });

            modelBuilder.Entity("StravaDataAnalyzerDataEF.Entities.Segment.DetailedSegmentEffort", b =>
                {
                    b.HasOne("StravaSegmentSniper.Data.Entities.Activity.DetailedActivity", "Activity")
                        .WithMany("SegmentEfforts")
                        .HasForeignKey("ActivityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("StravaSegmentSniper.Data.Entities.Athlete.DetailedAthlete", "DetailedAthlete")
                        .WithMany()
                        .HasForeignKey("AthleteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("StravaDataAnalyzerDataEF.Entities.Segment.SummarySegment", "Segment")
                        .WithMany()
                        .HasForeignKey("SummarySegmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Activity");

                    b.Navigation("DetailedAthlete");

                    b.Navigation("Segment");
                });

            modelBuilder.Entity("StravaDataAnalyzerDataEF.Entities.Segment.LocalLegend", b =>
                {
                    b.HasOne("StravaDataAnalyzerDataEF.Entities.Segment.DetailedSegmentEffort", "DetailedSegmentEffort")
                        .WithMany()
                        .HasForeignKey("DetailedSegmentEffortId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("StravaDataAnalyzerDataEF.Entities.Segment.EffortCount", "EffortCounts")
                        .WithMany()
                        .HasForeignKey("EffortCountId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DetailedSegmentEffort");

                    b.Navigation("EffortCounts");
                });

            modelBuilder.Entity("StravaDataAnalyzerDataEF.Entities.Segment.Xom", b =>
                {
                    b.HasOne("StravaDataAnalyzerDataEF.Entities.Segment.DetailedSegmentEffort", "DetailedSegmentEffort")
                        .WithMany()
                        .HasForeignKey("DetailedSegmentEffortId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("StravaDataAnalyzerDataEF.Entities.Segment.DetailedSegment", null)
                        .WithMany("Xoms")
                        .HasForeignKey("DetailedSegmentId");

                    b.Navigation("DetailedSegmentEffort");
                });

            modelBuilder.Entity("StravaSegmentSniper.Data.Entities.Activity.DetailedActivity", b =>
                {
                    b.HasOne("StravaSegmentSniper.Data.Entities.Athlete.DetailedAthlete", "Athlete")
                        .WithMany()
                        .HasForeignKey("DetailedAthleteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Athlete");
                });

            modelBuilder.Entity("StravaSegmentSniper.Data.Entities.Activity.SummaryActivity", b =>
                {
                    b.HasOne("StravaSegmentSniper.Data.Entities.Athlete.DetailedAthlete", "Athlete")
                        .WithMany()
                        .HasForeignKey("AthleteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("StravaSegmentSniper.Data.Entities.Activity.DetailedActivity", "DetailedActivity")
                        .WithMany()
                        .HasForeignKey("DetailedActivityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Athlete");

                    b.Navigation("DetailedActivity");
                });

            modelBuilder.Entity("StravaSegmentSniper.Data.Entities.Misc.Bike", b =>
                {
                    b.HasOne("StravaSegmentSniper.Data.Entities.Athlete.DetailedAthlete", "DetailedAthlete")
                        .WithMany("Bikes")
                        .HasForeignKey("DetailedAthleteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("DetailedAthlete");
                });

            modelBuilder.Entity("StravaDataAnalyzerDataEF.Entities.Segment.DetailedSegment", b =>
                {
                    b.Navigation("AthleteSegmentStats");

                    b.Navigation("Xoms");
                });

            modelBuilder.Entity("StravaDataAnalyzerDataEF.Entities.Segment.DetailedSegmentEffort", b =>
                {
                    b.Navigation("Achievements");
                });

            modelBuilder.Entity("StravaSegmentSniper.Data.Entities.Activity.DetailedActivity", b =>
                {
                    b.Navigation("SegmentEfforts");
                });

            modelBuilder.Entity("StravaSegmentSniper.Data.Entities.Athlete.DetailedAthlete", b =>
                {
                    b.Navigation("Bikes");
                });
#pragma warning restore 612, 618
        }
    }
}
