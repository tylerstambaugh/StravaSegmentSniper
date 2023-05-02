using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StravaSegmentSniper.Data.Migrations
{
    /// <inheritdoc />
    public partial class initialSetup : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DetailedAthletes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StravaAthleteId = table.Column<long>(type: "bigint", nullable: false),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Firstname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Lastname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Bio = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Sex = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Weight = table.Column<double>(type: "float", nullable: true),
                    ProfileMedium = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Profile = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FollowerCount = table.Column<int>(type: "int", nullable: true),
                    FriendCount = table.Column<int>(type: "int", nullable: true),
                    MutualFriendCount = table.Column<int>(type: "int", nullable: true),
                    AthleteType = table.Column<int>(type: "int", nullable: true),
                    DatePreference = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MeasurementPreference = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetailedAthletes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EffortCounts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Overall = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Female = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EffortCounts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Gear",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Primary = table.Column<bool>(type: "bit", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nickname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Retired = table.Column<bool>(type: "bit", nullable: false),
                    Distance = table.Column<int>(type: "int", nullable: false),
                    ConvertedDistance = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gear", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Maps",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Polyline = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SummaryPolyline = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Maps", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SummarySegments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StravaSegmentID = table.Column<long>(type: "bigint", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ActivityType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Distance = table.Column<double>(type: "float", nullable: false),
                    AverageGrade = table.Column<double>(type: "float", nullable: false),
                    MaximumGrade = table.Column<double>(type: "float", nullable: false),
                    ElevationHigh = table.Column<double>(type: "float", nullable: false),
                    ElevationLow = table.Column<double>(type: "float", nullable: false),
                    ClimbCategory = table.Column<int>(type: "int", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Private = table.Column<bool>(type: "bit", nullable: false),
                    Hazardous = table.Column<bool>(type: "bit", nullable: false),
                    Starred = table.Column<bool>(type: "bit", nullable: false),
                    ElevationProfile = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SummarySegments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Bikes",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    DetailedAthleteId = table.Column<int>(type: "int", nullable: false),
                    Primary = table.Column<bool>(type: "bit", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nickname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Retired = table.Column<bool>(type: "bit", nullable: false),
                    Distance = table.Column<int>(type: "int", nullable: false),
                    ConvertedDistance = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bikes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bikes_DetailedAthletes_DetailedAthleteId",
                        column: x => x.DetailedAthleteId,
                        principalTable: "DetailedAthletes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DetailedActivities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StravaActivityId = table.Column<long>(type: "bigint", nullable: false),
                    DetailedAthleteId = table.Column<int>(type: "int", nullable: false),
                    StravaAthleteId = table.Column<long>(type: "bigint", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Distance = table.Column<double>(type: "float", nullable: true),
                    MovingTime = table.Column<int>(type: "int", nullable: true),
                    ElapsedTime = table.Column<int>(type: "int", nullable: true),
                    TotalElevationGain = table.Column<double>(type: "float", nullable: true),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SportType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    AchievementCount = table.Column<int>(type: "int", nullable: true),
                    AverageSpeed = table.Column<double>(type: "float", nullable: true),
                    MaxSpeed = table.Column<double>(type: "float", nullable: true),
                    ElevHigh = table.Column<double>(type: "float", nullable: true),
                    ElevLow = table.Column<double>(type: "float", nullable: true),
                    PrCount = table.Column<int>(type: "int", nullable: true),
                    HasKudoed = table.Column<bool>(type: "bit", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetailedActivities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DetailedActivities_DetailedAthletes_DetailedAthleteId",
                        column: x => x.DetailedAthleteId,
                        principalTable: "DetailedAthletes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StravaApiTokens",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DetailedAthleteId = table.Column<int>(type: "int", nullable: true),
                    AuthorizationToken = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RefreshToken = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ExpiresAt = table.Column<long>(type: "bigint", nullable: false),
                    ExpiresIn = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StravaApiTokens", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StravaApiTokens_DetailedAthletes_DetailedAthleteId",
                        column: x => x.DetailedAthleteId,
                        principalTable: "DetailedAthletes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "DetailedSegmentEfforts",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SummarySegmentId = table.Column<int>(type: "int", nullable: false),
                    DetailedActivityId = table.Column<long>(type: "bigint", nullable: false),
                    ActivityId = table.Column<int>(type: "int", nullable: false),
                    AthleteId = table.Column<int>(type: "int", nullable: false),
                    ElapsedTime = table.Column<int>(type: "int", nullable: false),
                    MovingTime = table.Column<int>(type: "int", nullable: false),
                    StartDateLocal = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Distance = table.Column<double>(type: "float", nullable: false),
                    AverageWatts = table.Column<double>(type: "float", nullable: false),
                    AverageHeartrate = table.Column<double>(type: "float", nullable: false),
                    MaxHeartrate = table.Column<double>(type: "float", nullable: false),
                    PrRank = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetailedSegmentEfforts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DetailedSegmentEfforts_DetailedActivities_ActivityId",
                        column: x => x.ActivityId,
                        principalTable: "DetailedActivities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DetailedSegmentEfforts_DetailedAthletes_AthleteId",
                        column: x => x.AthleteId,
                        principalTable: "DetailedAthletes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_DetailedSegmentEfforts_SummarySegments_SummarySegmentId",
                        column: x => x.SummarySegmentId,
                        principalTable: "SummarySegments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "SummaryActivities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DetailedActivityId = table.Column<int>(type: "int", nullable: false),
                    StravaAthleteId = table.Column<int>(type: "int", nullable: false),
                    AthleteId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Distance = table.Column<double>(type: "float", nullable: true),
                    MovingTime = table.Column<int>(type: "int", nullable: true),
                    ElapsedTime = table.Column<int>(type: "int", nullable: true),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    StartDateLocal = table.Column<DateTime>(type: "datetime2", nullable: true),
                    AchievementCount = table.Column<int>(type: "int", nullable: true),
                    AverageSpeed = table.Column<double>(type: "float", nullable: true),
                    MaxSpeed = table.Column<double>(type: "float", nullable: true),
                    PrCount = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SummaryActivities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SummaryActivities_DetailedActivities_DetailedActivityId",
                        column: x => x.DetailedActivityId,
                        principalTable: "DetailedActivities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SummaryActivities_DetailedAthletes_AthleteId",
                        column: x => x.AthleteId,
                        principalTable: "DetailedAthletes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Achievements",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DetailedSegmentEffortId = table.Column<int>(type: "int", nullable: false),
                    DetailedSegementEffortId = table.Column<long>(type: "bigint", nullable: false),
                    TypeId = table.Column<int>(type: "int", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Rank = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Achievements", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Achievements_DetailedSegmentEfforts_DetailedSegementEffortId",
                        column: x => x.DetailedSegementEffortId,
                        principalTable: "DetailedSegmentEfforts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LocalLegends",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StravaAthleteId = table.Column<long>(type: "bigint", nullable: false),
                    DetailedSegmentEffortId = table.Column<long>(type: "bigint", nullable: false),
                    EffortCountId = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Profile = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EffortDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EffortCount = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Destination = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LocalLegends", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LocalLegends_DetailedSegmentEfforts_DetailedSegmentEffortId",
                        column: x => x.DetailedSegmentEffortId,
                        principalTable: "DetailedSegmentEfforts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LocalLegends_EffortCounts_EffortCountId",
                        column: x => x.EffortCountId,
                        principalTable: "EffortCounts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DetailedSegments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StravaSegmentId = table.Column<long>(type: "bigint", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Distance = table.Column<double>(type: "float", nullable: false),
                    AverageGrade = table.Column<double>(type: "float", nullable: false),
                    MaximumGrade = table.Column<double>(type: "float", nullable: false),
                    ElevationHigh = table.Column<double>(type: "float", nullable: false),
                    ElevationLow = table.Column<double>(type: "float", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Starred = table.Column<bool>(type: "bit", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TotalElevationGain = table.Column<double>(type: "float", nullable: false),
                    EffortCount = table.Column<int>(type: "int", nullable: false),
                    AthleteCount = table.Column<int>(type: "int", nullable: false),
                    StarCount = table.Column<int>(type: "int", nullable: false),
                    LocalLegendId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetailedSegments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DetailedSegments_LocalLegends_LocalLegendId",
                        column: x => x.LocalLegendId,
                        principalTable: "LocalLegends",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AthleteSegmentStats",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DetailedActivityId = table.Column<int>(type: "int", nullable: false),
                    StravaActivityId = table.Column<long>(type: "bigint", nullable: true),
                    PrElapsedTime = table.Column<int>(type: "int", nullable: true),
                    PrDate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EffortCount = table.Column<int>(type: "int", nullable: true),
                    DetailedSegmentId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AthleteSegmentStats", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AthleteSegmentStats_DetailedActivities_DetailedActivityId",
                        column: x => x.DetailedActivityId,
                        principalTable: "DetailedActivities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AthleteSegmentStats_DetailedSegments_DetailedSegmentId",
                        column: x => x.DetailedSegmentId,
                        principalTable: "DetailedSegments",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Xoms",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DetailedSegmentEffortId = table.Column<long>(type: "bigint", nullable: false),
                    Kom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Qom = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Overall = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DetailedSegmentId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Xoms", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Xoms_DetailedSegmentEfforts_DetailedSegmentEffortId",
                        column: x => x.DetailedSegmentEffortId,
                        principalTable: "DetailedSegmentEfforts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Xoms_DetailedSegments_DetailedSegmentId",
                        column: x => x.DetailedSegmentId,
                        principalTable: "DetailedSegments",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Achievements_DetailedSegementEffortId",
                table: "Achievements",
                column: "DetailedSegementEffortId");

            migrationBuilder.CreateIndex(
                name: "IX_AthleteSegmentStats_DetailedActivityId",
                table: "AthleteSegmentStats",
                column: "DetailedActivityId");

            migrationBuilder.CreateIndex(
                name: "IX_AthleteSegmentStats_DetailedSegmentId",
                table: "AthleteSegmentStats",
                column: "DetailedSegmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Bikes_DetailedAthleteId",
                table: "Bikes",
                column: "DetailedAthleteId");

            migrationBuilder.CreateIndex(
                name: "IX_DetailedActivities_DetailedAthleteId",
                table: "DetailedActivities",
                column: "DetailedAthleteId");

            migrationBuilder.CreateIndex(
                name: "IX_DetailedSegmentEfforts_ActivityId",
                table: "DetailedSegmentEfforts",
                column: "ActivityId");

            migrationBuilder.CreateIndex(
                name: "IX_DetailedSegmentEfforts_AthleteId",
                table: "DetailedSegmentEfforts",
                column: "AthleteId");

            migrationBuilder.CreateIndex(
                name: "IX_DetailedSegmentEfforts_SummarySegmentId",
                table: "DetailedSegmentEfforts",
                column: "SummarySegmentId");

            migrationBuilder.CreateIndex(
                name: "IX_DetailedSegments_LocalLegendId",
                table: "DetailedSegments",
                column: "LocalLegendId");

            migrationBuilder.CreateIndex(
                name: "IX_LocalLegends_DetailedSegmentEffortId",
                table: "LocalLegends",
                column: "DetailedSegmentEffortId");

            migrationBuilder.CreateIndex(
                name: "IX_LocalLegends_EffortCountId",
                table: "LocalLegends",
                column: "EffortCountId");

            migrationBuilder.CreateIndex(
                name: "IX_StravaApiTokens_DetailedAthleteId",
                table: "StravaApiTokens",
                column: "DetailedAthleteId");

            migrationBuilder.CreateIndex(
                name: "IX_SummaryActivities_AthleteId",
                table: "SummaryActivities",
                column: "AthleteId");

            migrationBuilder.CreateIndex(
                name: "IX_SummaryActivities_DetailedActivityId",
                table: "SummaryActivities",
                column: "DetailedActivityId");

            migrationBuilder.CreateIndex(
                name: "IX_Xoms_DetailedSegmentEffortId",
                table: "Xoms",
                column: "DetailedSegmentEffortId");

            migrationBuilder.CreateIndex(
                name: "IX_Xoms_DetailedSegmentId",
                table: "Xoms",
                column: "DetailedSegmentId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Achievements");

            migrationBuilder.DropTable(
                name: "AthleteSegmentStats");

            migrationBuilder.DropTable(
                name: "Bikes");

            migrationBuilder.DropTable(
                name: "Gear");

            migrationBuilder.DropTable(
                name: "Maps");

            migrationBuilder.DropTable(
                name: "StravaApiTokens");

            migrationBuilder.DropTable(
                name: "SummaryActivities");

            migrationBuilder.DropTable(
                name: "Xoms");

            migrationBuilder.DropTable(
                name: "DetailedSegments");

            migrationBuilder.DropTable(
                name: "LocalLegends");

            migrationBuilder.DropTable(
                name: "DetailedSegmentEfforts");

            migrationBuilder.DropTable(
                name: "EffortCounts");

            migrationBuilder.DropTable(
                name: "DetailedActivities");

            migrationBuilder.DropTable(
                name: "SummarySegments");

            migrationBuilder.DropTable(
                name: "DetailedAthletes");
        }
    }
}
