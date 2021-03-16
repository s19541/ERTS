using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ErtsModel.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LolTeams",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false, comment: "Id"),
                    Name = table.Column<string>(type: "text", nullable: false, comment: "Name"),
                    GameType = table.Column<string>(type: "text", nullable: false, comment: "Game type")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LolTeams", x => x.Id);
                },
                comment: "Team");

            migrationBuilder.CreateTable(
                name: "LolGamesStats",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false, comment: "Id"),
                    StartTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, comment: "Start time"),
                    EndTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, comment: "End time"),
                    BlueTeamId = table.Column<long>(type: "bigint", nullable: true),
                    RedTeamId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LolGamesStats", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LolGamesStats_LolTeams_BlueTeamId",
                        column: x => x.BlueTeamId,
                        principalTable: "LolTeams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LolGamesStats_LolTeams_RedTeamId",
                        column: x => x.RedTeamId,
                        principalTable: "LolTeams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                },
                comment: "Lol game stats");

            migrationBuilder.CreateTable(
                name: "Players",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false, comment: "Id"),
                    Name = table.Column<string>(type: "text", nullable: true, comment: "Name"),
                    Surname = table.Column<string>(type: "text", nullable: true, comment: "Surname"),
                    Nick = table.Column<string>(type: "text", nullable: false, comment: "Nickname"),
                    TeamId = table.Column<long>(type: "bigint", nullable: false, comment: "Team ID")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Players", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Players_LolTeams_TeamId",
                        column: x => x.TeamId,
                        principalTable: "LolTeams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "Players");

            migrationBuilder.CreateIndex(
                name: "IX_LolGamesStats_BlueTeamId",
                table: "LolGamesStats",
                column: "BlueTeamId");

            migrationBuilder.CreateIndex(
                name: "IX_LolGamesStats_RedTeamId",
                table: "LolGamesStats",
                column: "RedTeamId");

            migrationBuilder.CreateIndex(
                name: "IX_Players_TeamId",
                table: "Players",
                column: "TeamId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LolGamesStats");

            migrationBuilder.DropTable(
                name: "Players");

            migrationBuilder.DropTable(
                name: "LolTeams");
        }
    }
}
