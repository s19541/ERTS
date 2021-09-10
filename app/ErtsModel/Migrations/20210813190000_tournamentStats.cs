using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace ErtsModel.Migrations
{
    public partial class tournamentStats : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TournamentTeams");

            migrationBuilder.CreateTable(
                name: "LolTournamentPlayers",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false, comment: "Id")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PlayerId = table.Column<long>(type: "bigint", nullable: true),
                    TournamentId = table.Column<long>(type: "bigint", nullable: true),
                    AverageAssists = table.Column<double>(type: "double precision", nullable: false, comment: "AverageAssists"),
                    AverageDeaths = table.Column<double>(type: "double precision", nullable: false, comment: "AverageDeaths"),
                    AverageKills = table.Column<double>(type: "double precision", nullable: false, comment: "AverageKills"),
                    AverageMinionsKilled = table.Column<double>(type: "double precision", nullable: false, comment: "AverageMinionsKilled"),
                    ChampionId1 = table.Column<long>(type: "bigint", nullable: true),
                    ChampionId2 = table.Column<long>(type: "bigint", nullable: true),
                    ChampionId3 = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LolTournamentPlayers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LolTournamentPlayers_LolChampions_ChampionId1",
                        column: x => x.ChampionId1,
                        principalTable: "LolChampions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LolTournamentPlayers_LolChampions_ChampionId2",
                        column: x => x.ChampionId2,
                        principalTable: "LolChampions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LolTournamentPlayers_LolChampions_ChampionId3",
                        column: x => x.ChampionId3,
                        principalTable: "LolChampions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LolTournamentPlayers_Players_PlayerId",
                        column: x => x.PlayerId,
                        principalTable: "Players",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LolTournamentPlayers_Tournaments_TournamentId",
                        column: x => x.TournamentId,
                        principalTable: "Tournaments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                },
                comment: "Tournament to player");

            migrationBuilder.CreateTable(
                name: "LolTournamentTeams",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false, comment: "Id")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TeamId = table.Column<long>(type: "bigint", nullable: true),
                    TournamentId = table.Column<long>(type: "bigint", nullable: true),
                    GamesLost = table.Column<int>(type: "integer", nullable: false, comment: "GamesLost"),
                    GamesWon = table.Column<int>(type: "integer", nullable: false, comment: "GamesWon"),
                    MatchesWon = table.Column<int>(type: "integer", nullable: false, comment: "MatchesWon"),
                    MatchesLost = table.Column<int>(type: "integer", nullable: false, comment: "MatchesLost"),
                    AverageKills = table.Column<double>(type: "double precision", nullable: false, comment: "AverageKills"),
                    AverageDeaths = table.Column<double>(type: "double precision", nullable: false, comment: "AverageDeaths"),
                    AverageAssists = table.Column<double>(type: "double precision", nullable: false, comment: "AverageAssists"),
                    AverageGoldEarned = table.Column<double>(type: "double precision", nullable: false, comment: "AverageGoldEarned"),
                    AverageDragonKilled = table.Column<double>(type: "double precision", nullable: false, comment: "AverageDragonKilled"),
                    AverageHeraldKilled = table.Column<double>(type: "double precision", nullable: false, comment: "AverageHeraldKilled"),
                    AverageBaronKilled = table.Column<double>(type: "double precision", nullable: false, comment: "AverageBaronKilled"),
                    AverageTowerDestroyed = table.Column<double>(type: "double precision", nullable: false, comment: "AverageTowerDestroyed"),
                    ChampionId1 = table.Column<long>(type: "bigint", nullable: true),
                    ChampionId2 = table.Column<long>(type: "bigint", nullable: true),
                    ChampionId3 = table.Column<long>(type: "bigint", nullable: true),
                    ChampionId4 = table.Column<long>(type: "bigint", nullable: true),
                    ChampionId5 = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LolTournamentTeams", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LolTournamentTeams_LolChampions_ChampionId1",
                        column: x => x.ChampionId1,
                        principalTable: "LolChampions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LolTournamentTeams_LolChampions_ChampionId2",
                        column: x => x.ChampionId2,
                        principalTable: "LolChampions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LolTournamentTeams_LolChampions_ChampionId3",
                        column: x => x.ChampionId3,
                        principalTable: "LolChampions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LolTournamentTeams_LolChampions_ChampionId4",
                        column: x => x.ChampionId4,
                        principalTable: "LolChampions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LolTournamentTeams_LolChampions_ChampionId5",
                        column: x => x.ChampionId5,
                        principalTable: "LolChampions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LolTournamentTeams_Teams_TeamId",
                        column: x => x.TeamId,
                        principalTable: "Teams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LolTournamentTeams_Tournaments_TournamentId",
                        column: x => x.TournamentId,
                        principalTable: "Tournaments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                },
                comment: "Tournament to team");

            migrationBuilder.CreateIndex(
                name: "IX_LolTournamentPlayers_ChampionId1",
                table: "LolTournamentPlayers",
                column: "ChampionId1");

            migrationBuilder.CreateIndex(
                name: "IX_LolTournamentPlayers_ChampionId2",
                table: "LolTournamentPlayers",
                column: "ChampionId2");

            migrationBuilder.CreateIndex(
                name: "IX_LolTournamentPlayers_ChampionId3",
                table: "LolTournamentPlayers",
                column: "ChampionId3");

            migrationBuilder.CreateIndex(
                name: "IX_LolTournamentPlayers_PlayerId",
                table: "LolTournamentPlayers",
                column: "PlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_LolTournamentPlayers_TournamentId",
                table: "LolTournamentPlayers",
                column: "TournamentId");

            migrationBuilder.CreateIndex(
                name: "IX_LolTournamentTeams_ChampionId1",
                table: "LolTournamentTeams",
                column: "ChampionId1");

            migrationBuilder.CreateIndex(
                name: "IX_LolTournamentTeams_ChampionId2",
                table: "LolTournamentTeams",
                column: "ChampionId2");

            migrationBuilder.CreateIndex(
                name: "IX_LolTournamentTeams_ChampionId3",
                table: "LolTournamentTeams",
                column: "ChampionId3");

            migrationBuilder.CreateIndex(
                name: "IX_LolTournamentTeams_ChampionId4",
                table: "LolTournamentTeams",
                column: "ChampionId4");

            migrationBuilder.CreateIndex(
                name: "IX_LolTournamentTeams_ChampionId5",
                table: "LolTournamentTeams",
                column: "ChampionId5");

            migrationBuilder.CreateIndex(
                name: "IX_LolTournamentTeams_TeamId",
                table: "LolTournamentTeams",
                column: "TeamId");

            migrationBuilder.CreateIndex(
                name: "IX_LolTournamentTeams_TournamentId",
                table: "LolTournamentTeams",
                column: "TournamentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LolTournamentPlayers");

            migrationBuilder.DropTable(
                name: "LolTournamentTeams");

            migrationBuilder.CreateTable(
                name: "TournamentTeams",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false, comment: "Id")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    GamesLost = table.Column<int>(type: "integer", nullable: false, comment: "GamesLost"),
                    GamesWon = table.Column<int>(type: "integer", nullable: false, comment: "GamesWon"),
                    MatchesLost = table.Column<int>(type: "integer", nullable: false, comment: "MatchesLost"),
                    MatchesWon = table.Column<int>(type: "integer", nullable: false, comment: "MatchesWon"),
                    TeamId = table.Column<long>(type: "bigint", nullable: true),
                    TournamentId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TournamentTeams", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TournamentTeams_Teams_TeamId",
                        column: x => x.TeamId,
                        principalTable: "Teams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TournamentTeams_Tournaments_TournamentId",
                        column: x => x.TournamentId,
                        principalTable: "Tournaments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                },
                comment: "Tournament to team");

            migrationBuilder.CreateIndex(
                name: "IX_TournamentTeams_TeamId",
                table: "TournamentTeams",
                column: "TeamId");

            migrationBuilder.CreateIndex(
                name: "IX_TournamentTeams_TournamentId",
                table: "TournamentTeams",
                column: "TournamentId");
        }
    }
}
