using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StravaSegmentSniper.Data.Migrations
{
    /// <inheritdoc />
    public partial class updatingFkeys : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StravaApiTokens_DetailedAthletes_DetailedAthleteId",
                table: "StravaApiTokens");

            migrationBuilder.DropIndex(
                name: "IX_StravaApiTokens_DetailedAthleteId",
                table: "StravaApiTokens");

            migrationBuilder.DropColumn(
                name: "DetailedAthleteId",
                table: "StravaApiTokens");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DetailedAthleteId",
                table: "StravaApiTokens",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_StravaApiTokens_DetailedAthleteId",
                table: "StravaApiTokens",
                column: "DetailedAthleteId");

            migrationBuilder.AddForeignKey(
                name: "FK_StravaApiTokens_DetailedAthletes_DetailedAthleteId",
                table: "StravaApiTokens",
                column: "DetailedAthleteId",
                principalTable: "DetailedAthletes",
                principalColumn: "Id");
        }
    }
}
