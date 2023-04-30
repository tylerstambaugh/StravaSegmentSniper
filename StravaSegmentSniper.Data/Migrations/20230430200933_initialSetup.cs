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
            migrationBuilder.DropTable(
                name: "Tokens");

            migrationBuilder.DropTable(
                name: "ConsoleAppUsers");

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

            migrationBuilder.CreateIndex(
                name: "IX_StravaApiTokens_DetailedAthleteId",
                table: "StravaApiTokens",
                column: "DetailedAthleteId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StravaApiTokens");

            migrationBuilder.CreateTable(
                name: "ConsoleAppUsers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DetailedAthleteId = table.Column<int>(type: "int", nullable: true),
                    EmailAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StravaAthleteId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConsoleAppUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ConsoleAppUsers_DetailedAthletes_DetailedAthleteId",
                        column: x => x.DetailedAthleteId,
                        principalTable: "DetailedAthletes",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Tokens",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    AuthorizationToken = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ExpiresAt = table.Column<long>(type: "bigint", nullable: false),
                    ExpiresIn = table.Column<long>(type: "bigint", nullable: false),
                    RefreshToken = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tokens", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tokens_ConsoleAppUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "ConsoleAppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ConsoleAppUsers_DetailedAthleteId",
                table: "ConsoleAppUsers",
                column: "DetailedAthleteId");

            migrationBuilder.CreateIndex(
                name: "IX_Tokens_UserId",
                table: "Tokens",
                column: "UserId");
        }
    }
}
