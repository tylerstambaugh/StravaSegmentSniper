using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StravaSegmentSniper.Data.Migrations
{
    /// <inheritdoc />
    public partial class updatedConsoleAppUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tokens_Users_UserId",
                table: "Tokens");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_DetailedAthletes_DetailedAthleteId",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "ConsoleAppUsers");

            migrationBuilder.RenameIndex(
                name: "IX_Users_DetailedAthleteId",
                table: "ConsoleAppUsers",
                newName: "IX_ConsoleAppUsers_DetailedAthleteId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ConsoleAppUsers",
                table: "ConsoleAppUsers",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ConsoleAppUsers_DetailedAthletes_DetailedAthleteId",
                table: "ConsoleAppUsers",
                column: "DetailedAthleteId",
                principalTable: "DetailedAthletes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Tokens_ConsoleAppUsers_UserId",
                table: "Tokens",
                column: "UserId",
                principalTable: "ConsoleAppUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ConsoleAppUsers_DetailedAthletes_DetailedAthleteId",
                table: "ConsoleAppUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Tokens_ConsoleAppUsers_UserId",
                table: "Tokens");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ConsoleAppUsers",
                table: "ConsoleAppUsers");

            migrationBuilder.RenameTable(
                name: "ConsoleAppUsers",
                newName: "Users");

            migrationBuilder.RenameIndex(
                name: "IX_ConsoleAppUsers_DetailedAthleteId",
                table: "Users",
                newName: "IX_Users_DetailedAthleteId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Tokens_Users_UserId",
                table: "Tokens",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_DetailedAthletes_DetailedAthleteId",
                table: "Users",
                column: "DetailedAthleteId",
                principalTable: "DetailedAthletes",
                principalColumn: "Id");
        }
    }
}
