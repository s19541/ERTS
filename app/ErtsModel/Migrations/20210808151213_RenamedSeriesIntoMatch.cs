using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace ErtsModel.Migrations
{
    public partial class RenamedSeriesIntoMatch : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Games_Series_SeriesId",
                table: "Games");

            migrationBuilder.DropTable(
                name: "Series");

            migrationBuilder.DropColumn(
                name: "GamesPlayed",
                table: "TournamentTeams");

            migrationBuilder.DropColumn(
                name: "SeriesLost",
                table: "TournamentTeams");

            migrationBuilder.DropColumn(
                name: "SeriesPlayed",
                table: "TournamentTeams");

            migrationBuilder.DropColumn(
                name: "SeriesWon",
                table: "TournamentTeams");

            migrationBuilder.RenameColumn(
                name: "SeriesId",
                table: "Games",
                newName: "MatchId");

            migrationBuilder.RenameIndex(
                name: "IX_Games_SeriesId",
                table: "Games",
                newName: "IX_Games_MatchId");

            migrationBuilder.AddColumn<int>(
                name: "MatchesLost",
                table: "TournamentTeams",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                comment: "MatchesLost");

            migrationBuilder.AddColumn<int>(
                name: "MatchesWon",
                table: "TournamentTeams",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                comment: "MatchesWon");

            migrationBuilder.CreateTable(
                name: "Matches",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false, comment: "Id")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    StartTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, comment: "Start time"),
                    EndTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, comment: "End time"),
                    Team1Id = table.Column<long>(type: "bigint", nullable: true),
                    Team2Id = table.Column<long>(type: "bigint", nullable: true),
                    tournamentId = table.Column<long>(type: "bigint", nullable: true),
                    StreamUrl = table.Column<string>(type: "text", nullable: true, comment: "Stream url")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Matches", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Matches_Teams_Team1Id",
                        column: x => x.Team1Id,
                        principalTable: "Teams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Matches_Teams_Team2Id",
                        column: x => x.Team2Id,
                        principalTable: "Teams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Matches_Tournaments_tournamentId",
                        column: x => x.tournamentId,
                        principalTable: "Tournaments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                },
                comment: "Lol game stats");

            migrationBuilder.CreateIndex(
                name: "IX_Matches_Team1Id",
                table: "Matches",
                column: "Team1Id");

            migrationBuilder.CreateIndex(
                name: "IX_Matches_Team2Id",
                table: "Matches",
                column: "Team2Id");

            migrationBuilder.CreateIndex(
                name: "IX_Matches_tournamentId",
                table: "Matches",
                column: "tournamentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Games_Matches_MatchId",
                table: "Games",
                column: "MatchId",
                principalTable: "Matches",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Games_Matches_MatchId",
                table: "Games");

            migrationBuilder.DropTable(
                name: "Matches");

            migrationBuilder.DropColumn(
                name: "MatchesLost",
                table: "TournamentTeams");

            migrationBuilder.DropColumn(
                name: "MatchesWon",
                table: "TournamentTeams");

            migrationBuilder.RenameColumn(
                name: "MatchId",
                table: "Games",
                newName: "SeriesId");

            migrationBuilder.RenameIndex(
                name: "IX_Games_MatchId",
                table: "Games",
                newName: "IX_Games_SeriesId");

            migrationBuilder.AddColumn<int>(
                name: "GamesPlayed",
                table: "TournamentTeams",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                comment: "GamesPlayed");

            migrationBuilder.AddColumn<int>(
                name: "SeriesLost",
                table: "TournamentTeams",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                comment: "SeriessLost");

            migrationBuilder.AddColumn<int>(
                name: "SeriesPlayed",
                table: "TournamentTeams",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                comment: "SeriesPlayed");

            migrationBuilder.AddColumn<int>(
                name: "SeriesWon",
                table: "TournamentTeams",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                comment: "SeriesWon");

            migrationBuilder.CreateTable(
                name: "Series",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false, comment: "Id")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    BlueTeamId = table.Column<long>(type: "bigint", nullable: true),
                    EndTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, comment: "End time"),
                    RedTeamId = table.Column<long>(type: "bigint", nullable: true),
                    StartTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, comment: "Start time"),
                    StreamUrl = table.Column<string>(type: "text", nullable: true, comment: "Stream url"),
                    tournamentId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Series", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Series_Teams_BlueTeamId",
                        column: x => x.BlueTeamId,
                        principalTable: "Teams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Series_Teams_RedTeamId",
                        column: x => x.RedTeamId,
                        principalTable: "Teams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Series_Tournaments_tournamentId",
                        column: x => x.tournamentId,
                        principalTable: "Tournaments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                },
                comment: "Lol game stats");

            migrationBuilder.CreateIndex(
                name: "IX_Series_BlueTeamId",
                table: "Series",
                column: "BlueTeamId");

            migrationBuilder.CreateIndex(
                name: "IX_Series_RedTeamId",
                table: "Series",
                column: "RedTeamId");

            migrationBuilder.CreateIndex(
                name: "IX_Series_tournamentId",
                table: "Series",
                column: "tournamentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Games_Series_SeriesId",
                table: "Games",
                column: "SeriesId",
                principalTable: "Series",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
