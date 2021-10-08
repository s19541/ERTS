using Microsoft.EntityFrameworkCore.Migrations;

namespace ErtsModel.Migrations
{
    public partial class AddedNewFieldsToTournamentPlayer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "ChampionsPlayed",
                table: "LolTournamentPlayers",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0,
                comment: "ChampionPlayed");

            migrationBuilder.AddColumn<double>(
                name: "DamageShare",
                table: "LolTournamentPlayers",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0,
                comment: "DamageShare");

            migrationBuilder.AddColumn<double>(
                name: "GoldPerMinute",
                table: "LolTournamentPlayers",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0,
                comment: "GoldPerMinute");

            migrationBuilder.AddColumn<double>(
                name: "KillParticipation",
                table: "LolTournamentPlayers",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0,
                comment: "KillParticipation");

            migrationBuilder.AddColumn<double>(
                name: "MinionsPerMinute",
                table: "LolTournamentPlayers",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0,
                comment: "MinionsPerMinute");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ChampionsPlayed",
                table: "LolTournamentPlayers");

            migrationBuilder.DropColumn(
                name: "DamageShare",
                table: "LolTournamentPlayers");

            migrationBuilder.DropColumn(
                name: "GoldPerMinute",
                table: "LolTournamentPlayers");

            migrationBuilder.DropColumn(
                name: "KillParticipation",
                table: "LolTournamentPlayers");

            migrationBuilder.DropColumn(
                name: "MinionsPerMinute",
                table: "LolTournamentPlayers");
        }
    }
}
