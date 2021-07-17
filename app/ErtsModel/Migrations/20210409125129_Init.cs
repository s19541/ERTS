using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace ErtsModel.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Leagues",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false, comment: "Id")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false, comment: "Name"),
                    ImageUrl = table.Column<string>(type: "text", nullable: true, comment: "Image url"),
                    GameType = table.Column<string>(type: "text", nullable: false, comment: "Game type"),
                    Url = table.Column<string>(type: "text", nullable: true, comment: "Url")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Leagues", x => x.Id);
                },
                comment: "League");

            migrationBuilder.CreateTable(
                name: "LolChampions",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false, comment: "Id")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false, comment: "Name"),
                    ImageUrl = table.Column<string>(type: "text", nullable: true, comment: "Image url")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LolChampions", x => x.Id);
                },
                comment: "Lol Champion");

            migrationBuilder.CreateTable(
                name: "LolItems",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false, comment: "Id")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false, comment: "Name"),
                    ImageUrl = table.Column<string>(type: "text", nullable: true, comment: "Image url"),
                    IsTrinket = table.Column<bool>(type: "boolean", nullable: false, comment: "Is trinket")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LolItems", x => x.Id);
                },
                comment: "Lol Item");

            migrationBuilder.CreateTable(
                name: "LolSpells",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false, comment: "Id")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false, comment: "Name"),
                    ImageUrl = table.Column<string>(type: "text", nullable: true, comment: "Image url")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LolSpells", x => x.Id);
                },
                comment: "Lol Spell");

            migrationBuilder.CreateTable(
                name: "Teams",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false, comment: "Id")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false, comment: "Name"),
                    GameType = table.Column<string>(type: "text", nullable: false, comment: "Game type"),
                    ImageUrl = table.Column<string>(type: "text", nullable: true, comment: "Image url"),
                    Acronym = table.Column<string>(type: "text", nullable: true, comment: "Acronym")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Teams", x => x.Id);
                },
                comment: "Team");

            migrationBuilder.CreateTable(
                name: "Tournaments",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false, comment: "Id")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false, comment: "Name"),
                    StartTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, comment: "Start time"),
                    EndTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, comment: "End time"),
                    LeagueId = table.Column<long>(type: "bigint", nullable: true),
                    PrizePool = table.Column<double>(type: "double precision", nullable: false, comment: "Prize pool")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tournaments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tournaments_Leagues_LeagueId",
                        column: x => x.LeagueId,
                        principalTable: "Leagues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                },
                comment: "Tournament");

            migrationBuilder.CreateTable(
                name: "Players",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false, comment: "Id")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true, comment: "Name"),
                    Surname = table.Column<string>(type: "text", nullable: true, comment: "Surname"),
                    Nick = table.Column<string>(type: "text", nullable: false, comment: "Nickname"),
                    Nationality = table.Column<string>(type: "text", nullable: true, comment: "Nationality"),
                    TeamId = table.Column<long>(type: "bigint", nullable: false, comment: "Team ID")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Players", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Players_Teams_TeamId",
                        column: x => x.TeamId,
                        principalTable: "Teams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                },
                comment: "Players");

            migrationBuilder.CreateTable(
                name: "Series",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false, comment: "Id")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    StartTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, comment: "Start time"),
                    EndTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, comment: "End time"),
                    BlueTeamId = table.Column<long>(type: "bigint", nullable: true),
                    RedTeamId = table.Column<long>(type: "bigint", nullable: true),
                    tournamentId = table.Column<long>(type: "bigint", nullable: true),
                    StreamUrl = table.Column<string>(type: "text", nullable: true, comment: "Stream url")
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

            migrationBuilder.CreateTable(
                name: "TournamentTeams",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false, comment: "Id")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TeamId = table.Column<long>(type: "bigint", nullable: true),
                    TournamentId = table.Column<long>(type: "bigint", nullable: true),
                    GamesPlayed = table.Column<int>(type: "integer", nullable: false, comment: "GamesPlayed"),
                    GamesLost = table.Column<int>(type: "integer", nullable: false, comment: "GamesLost"),
                    GamesWon = table.Column<int>(type: "integer", nullable: false, comment: "GamesWon"),
                    SeriesPlayed = table.Column<int>(type: "integer", nullable: false, comment: "SeriesPlayed"),
                    SeriesWon = table.Column<int>(type: "integer", nullable: false, comment: "SeriesWon"),
                    SeriesLost = table.Column<int>(type: "integer", nullable: false, comment: "SeriessLost")
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

            migrationBuilder.CreateTable(
                name: "Games",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false, comment: "Id")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    StartTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, comment: "Start time"),
                    EndTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, comment: "End time"),
                    WinnerTeamId = table.Column<long>(type: "bigint", nullable: true),
                    SeriesId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Games", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Games_Series_SeriesId",
                        column: x => x.SeriesId,
                        principalTable: "Series",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Games_Teams_WinnerTeamId",
                        column: x => x.WinnerTeamId,
                        principalTable: "Teams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                },
                comment: "Game");

            migrationBuilder.CreateTable(
                name: "LolGamePlayers",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false, comment: "Id")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    GameId = table.Column<long>(type: "bigint", nullable: true),
                    LolGameId = table.Column<long>(type: "bigint", nullable: true),
                    Role = table.Column<int>(type: "integer", nullable: false, comment: "Role"),
                    ChampionId = table.Column<long>(type: "bigint", nullable: true),
                    Kills = table.Column<int>(type: "integer", nullable: false, comment: "Kills"),
                    Deaths = table.Column<int>(type: "integer", nullable: false, comment: "Deaths"),
                    Assists = table.Column<int>(type: "integer", nullable: false, comment: "Assists"),
                    GoldEarned = table.Column<int>(type: "integer", nullable: false, comment: "Gold earned"),
                    GoldSpent = table.Column<int>(type: "integer", nullable: false, comment: "Gold spent"),
                    LargestCriticalStrike = table.Column<int>(type: "integer", nullable: false, comment: "Largest critical strike"),
                    LargestKillingSpree = table.Column<int>(type: "integer", nullable: false, comment: "Largest killing spree"),
                    LargestMultiKill = table.Column<int>(type: "integer", nullable: false, comment: "Largest multi kill"),
                    Level = table.Column<int>(type: "integer", nullable: false, comment: "Level"),
                    MagicDamageDealt = table.Column<int>(type: "integer", nullable: false, comment: "Magic damage dealt"),
                    MagicDamageDealtToChamps = table.Column<int>(type: "integer", nullable: false, comment: "Magic damage dealt to champs"),
                    PhysicalDamageDealt = table.Column<int>(type: "integer", nullable: false, comment: "Physical damage dealt"),
                    PhysicalDamageDealtToChamps = table.Column<int>(type: "integer", nullable: false, comment: "Physical damage dealt to champs"),
                    TrueDamageDealt = table.Column<int>(type: "integer", nullable: false, comment: "True damage dealt"),
                    TrueDamageDealtToChamps = table.Column<int>(type: "integer", nullable: false, comment: "True damage dealt to champs"),
                    DamageDealt = table.Column<int>(type: "integer", nullable: false, comment: "Damage dealt"),
                    DamageDealtToChamps = table.Column<int>(type: "integer", nullable: false, comment: "Damage dealt to champs"),
                    DamageTaken = table.Column<int>(type: "integer", nullable: false, comment: "Damage taken"),
                    TotalHeal = table.Column<int>(type: "integer", nullable: false, comment: "Total heal"),
                    TotalTimeCrowdControlDealt = table.Column<int>(type: "integer", nullable: false, comment: "Total time crowd control dealt"),
                    WardsPlaced = table.Column<int>(type: "integer", nullable: false, comment: "Wards placed"),
                    WardsDestroyed = table.Column<int>(type: "integer", nullable: false, comment: "Wards destroyed"),
                    TurretsDestroyed = table.Column<int>(type: "integer", nullable: false, comment: "Turrets destroyed"),
                    InhibitorsDestroyed = table.Column<int>(type: "integer", nullable: false, comment: "Inhibitor destroyed"),
                    MinionsKilled = table.Column<int>(type: "integer", nullable: false, comment: "Minions killed"),
                    NeutralMinionsKilled = table.Column<int>(type: "integer", nullable: false, comment: "Neutral minions killed"),
                    EnemyNeutralMinionsKilled = table.Column<int>(type: "integer", nullable: false),
                    FirstBlood = table.Column<bool>(type: "boolean", nullable: false, comment: "First blood"),
                    FirstBloodAssist = table.Column<bool>(type: "boolean", nullable: false, comment: "Total blood assits"),
                    Spell1Id = table.Column<long>(type: "bigint", nullable: true),
                    Spell2Id = table.Column<long>(type: "bigint", nullable: true),
                    PlayerId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LolGamePlayers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LolGamePlayers_Games_LolGameId",
                        column: x => x.LolGameId,
                        principalTable: "Games",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LolGamePlayers_LolChampions_ChampionId",
                        column: x => x.ChampionId,
                        principalTable: "LolChampions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LolGamePlayers_LolSpells_Spell1Id",
                        column: x => x.Spell1Id,
                        principalTable: "LolSpells",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LolGamePlayers_LolSpells_Spell2Id",
                        column: x => x.Spell2Id,
                        principalTable: "LolSpells",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LolGamePlayers_Players_GameId",
                        column: x => x.GameId,
                        principalTable: "Players",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                },
                comment: "Player stats in game");

            migrationBuilder.CreateTable(
                name: "LolGameTeam",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false, comment: "Id")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TeamId = table.Column<long>(type: "bigint", nullable: true),
                    GameId = table.Column<long>(type: "bigint", nullable: true),
                    BaronKilled = table.Column<int>(type: "integer", nullable: false, comment: "Baron killed"),
                    MountainDrakeKilled = table.Column<int>(type: "integer", nullable: false, comment: "First inhibitor"),
                    InfernalDrakeKilled = table.Column<int>(type: "integer", nullable: false, comment: "Infernal drake killed"),
                    OceanDrakeKilled = table.Column<int>(type: "integer", nullable: false, comment: "Ocean drake killed"),
                    CloudDrakeKilled = table.Column<int>(type: "integer", nullable: false, comment: "Cloud drake killed"),
                    ElderDrakeKilled = table.Column<int>(type: "integer", nullable: false, comment: "Elder drake killed"),
                    HeraldKilled = table.Column<int>(type: "integer", nullable: false, comment: "Herald killed"),
                    GoldEarned = table.Column<int>(type: "integer", nullable: false, comment: "Gold earned"),
                    Kills = table.Column<int>(type: "integer", nullable: false, comment: "Kills"),
                    TurretDestroyed = table.Column<int>(type: "integer", nullable: false, comment: "Turret destroyed"),
                    Color = table.Column<int>(type: "integer", nullable: false, comment: "Color"),
                    Ban1Id = table.Column<long>(type: "bigint", nullable: true),
                    Ban2Id = table.Column<long>(type: "bigint", nullable: true),
                    Ban3Id = table.Column<long>(type: "bigint", nullable: true),
                    Ban4Id = table.Column<long>(type: "bigint", nullable: true),
                    Ban5Id = table.Column<long>(type: "bigint", nullable: true),
                    FirstBaron = table.Column<bool>(type: "boolean", nullable: false, comment: "First baron"),
                    FirstBlood = table.Column<bool>(type: "boolean", nullable: false, comment: "First blood"),
                    FirstDragon = table.Column<bool>(type: "boolean", nullable: false),
                    FirstTurret = table.Column<bool>(type: "boolean", nullable: false),
                    FirstInhibitor = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LolGameTeam", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LolGameTeam_Games_GameId",
                        column: x => x.GameId,
                        principalTable: "Games",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LolGameTeam_LolChampions_Ban1Id",
                        column: x => x.Ban1Id,
                        principalTable: "LolChampions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LolGameTeam_LolChampions_Ban2Id",
                        column: x => x.Ban2Id,
                        principalTable: "LolChampions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LolGameTeam_LolChampions_Ban3Id",
                        column: x => x.Ban3Id,
                        principalTable: "LolChampions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LolGameTeam_LolChampions_Ban4Id",
                        column: x => x.Ban4Id,
                        principalTable: "LolChampions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LolGameTeam_LolChampions_Ban5Id",
                        column: x => x.Ban5Id,
                        principalTable: "LolChampions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LolGameTeam_Teams_TeamId",
                        column: x => x.TeamId,
                        principalTable: "Teams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                },
                comment: "Team stats in game");

            migrationBuilder.CreateTable(
                name: "LolGamePlayerItems",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false, comment: "Id")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ItemId = table.Column<long>(type: "bigint", nullable: true),
                    GamePlayerId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LolGamePlayerItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LolGamePlayerItems_LolGamePlayers_GamePlayerId",
                        column: x => x.GamePlayerId,
                        principalTable: "LolGamePlayers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LolGamePlayerItems_LolItems_ItemId",
                        column: x => x.ItemId,
                        principalTable: "LolItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                },
                comment: "items of player in game");

            migrationBuilder.CreateIndex(
                name: "IX_Games_SeriesId",
                table: "Games",
                column: "SeriesId");

            migrationBuilder.CreateIndex(
                name: "IX_Games_WinnerTeamId",
                table: "Games",
                column: "WinnerTeamId");

            migrationBuilder.CreateIndex(
                name: "IX_LolGamePlayerItems_GamePlayerId",
                table: "LolGamePlayerItems",
                column: "GamePlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_LolGamePlayerItems_ItemId",
                table: "LolGamePlayerItems",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_LolGamePlayers_ChampionId",
                table: "LolGamePlayers",
                column: "ChampionId");

            migrationBuilder.CreateIndex(
                name: "IX_LolGamePlayers_GameId",
                table: "LolGamePlayers",
                column: "GameId");

            migrationBuilder.CreateIndex(
                name: "IX_LolGamePlayers_LolGameId",
                table: "LolGamePlayers",
                column: "LolGameId");

            migrationBuilder.CreateIndex(
                name: "IX_LolGamePlayers_Spell1Id",
                table: "LolGamePlayers",
                column: "Spell1Id");

            migrationBuilder.CreateIndex(
                name: "IX_LolGamePlayers_Spell2Id",
                table: "LolGamePlayers",
                column: "Spell2Id");

            migrationBuilder.CreateIndex(
                name: "IX_LolGameTeam_Ban1Id",
                table: "LolGameTeam",
                column: "Ban1Id");

            migrationBuilder.CreateIndex(
                name: "IX_LolGameTeam_Ban2Id",
                table: "LolGameTeam",
                column: "Ban2Id");

            migrationBuilder.CreateIndex(
                name: "IX_LolGameTeam_Ban3Id",
                table: "LolGameTeam",
                column: "Ban3Id");

            migrationBuilder.CreateIndex(
                name: "IX_LolGameTeam_Ban4Id",
                table: "LolGameTeam",
                column: "Ban4Id");

            migrationBuilder.CreateIndex(
                name: "IX_LolGameTeam_Ban5Id",
                table: "LolGameTeam",
                column: "Ban5Id");

            migrationBuilder.CreateIndex(
                name: "IX_LolGameTeam_GameId",
                table: "LolGameTeam",
                column: "GameId");

            migrationBuilder.CreateIndex(
                name: "IX_LolGameTeam_TeamId",
                table: "LolGameTeam",
                column: "TeamId");

            migrationBuilder.CreateIndex(
                name: "IX_Players_TeamId",
                table: "Players",
                column: "TeamId");

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

            migrationBuilder.CreateIndex(
                name: "IX_Tournaments_LeagueId",
                table: "Tournaments",
                column: "LeagueId");

            migrationBuilder.CreateIndex(
                name: "IX_TournamentTeams_TeamId",
                table: "TournamentTeams",
                column: "TeamId");

            migrationBuilder.CreateIndex(
                name: "IX_TournamentTeams_TournamentId",
                table: "TournamentTeams",
                column: "TournamentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LolGamePlayerItems");

            migrationBuilder.DropTable(
                name: "LolGameTeam");

            migrationBuilder.DropTable(
                name: "TournamentTeams");

            migrationBuilder.DropTable(
                name: "LolGamePlayers");

            migrationBuilder.DropTable(
                name: "LolItems");

            migrationBuilder.DropTable(
                name: "Games");

            migrationBuilder.DropTable(
                name: "LolChampions");

            migrationBuilder.DropTable(
                name: "LolSpells");

            migrationBuilder.DropTable(
                name: "Players");

            migrationBuilder.DropTable(
                name: "Series");

            migrationBuilder.DropTable(
                name: "Teams");

            migrationBuilder.DropTable(
                name: "Tournaments");

            migrationBuilder.DropTable(
                name: "Leagues");
        }
    }
}
