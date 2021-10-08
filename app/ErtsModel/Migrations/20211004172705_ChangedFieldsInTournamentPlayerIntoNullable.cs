using Microsoft.EntityFrameworkCore.Migrations;

namespace ErtsModel.Migrations
{
    public partial class ChangedFieldsInTournamentPlayerIntoNullable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "MinionsPerMinute",
                table: "LolTournamentPlayers",
                type: "double precision",
                nullable: true,
                comment: "MinionsPerMinute",
                oldClrType: typeof(double),
                oldType: "double precision",
                oldComment: "MinionsPerMinute");

            migrationBuilder.AlterColumn<double>(
                name: "KillParticipation",
                table: "LolTournamentPlayers",
                type: "double precision",
                nullable: true,
                comment: "KillParticipation",
                oldClrType: typeof(double),
                oldType: "double precision",
                oldComment: "KillParticipation");

            migrationBuilder.AlterColumn<double>(
                name: "GoldPerMinute",
                table: "LolTournamentPlayers",
                type: "double precision",
                nullable: true,
                comment: "GoldPerMinute",
                oldClrType: typeof(double),
                oldType: "double precision",
                oldComment: "GoldPerMinute");

            migrationBuilder.AlterColumn<double>(
                name: "DamageShare",
                table: "LolTournamentPlayers",
                type: "double precision",
                nullable: true,
                comment: "DamageShare",
                oldClrType: typeof(double),
                oldType: "double precision",
                oldComment: "DamageShare");

            migrationBuilder.AlterColumn<double>(
                name: "AverageMinionsKilled",
                table: "LolTournamentPlayers",
                type: "double precision",
                nullable: true,
                comment: "AverageMinionsKilled",
                oldClrType: typeof(double),
                oldType: "double precision",
                oldComment: "AverageMinionsKilled");

            migrationBuilder.AlterColumn<double>(
                name: "AverageKills",
                table: "LolTournamentPlayers",
                type: "double precision",
                nullable: true,
                comment: "AverageKills",
                oldClrType: typeof(double),
                oldType: "double precision",
                oldComment: "AverageKills");

            migrationBuilder.AlterColumn<double>(
                name: "AverageDeaths",
                table: "LolTournamentPlayers",
                type: "double precision",
                nullable: true,
                comment: "AverageDeaths",
                oldClrType: typeof(double),
                oldType: "double precision",
                oldComment: "AverageDeaths");

            migrationBuilder.AlterColumn<double>(
                name: "AverageAssists",
                table: "LolTournamentPlayers",
                type: "double precision",
                nullable: true,
                comment: "AverageAssists",
                oldClrType: typeof(double),
                oldType: "double precision",
                oldComment: "AverageAssists");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "MinionsPerMinute",
                table: "LolTournamentPlayers",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0,
                comment: "MinionsPerMinute",
                oldClrType: typeof(double),
                oldType: "double precision",
                oldNullable: true,
                oldComment: "MinionsPerMinute");

            migrationBuilder.AlterColumn<double>(
                name: "KillParticipation",
                table: "LolTournamentPlayers",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0,
                comment: "KillParticipation",
                oldClrType: typeof(double),
                oldType: "double precision",
                oldNullable: true,
                oldComment: "KillParticipation");

            migrationBuilder.AlterColumn<double>(
                name: "GoldPerMinute",
                table: "LolTournamentPlayers",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0,
                comment: "GoldPerMinute",
                oldClrType: typeof(double),
                oldType: "double precision",
                oldNullable: true,
                oldComment: "GoldPerMinute");

            migrationBuilder.AlterColumn<double>(
                name: "DamageShare",
                table: "LolTournamentPlayers",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0,
                comment: "DamageShare",
                oldClrType: typeof(double),
                oldType: "double precision",
                oldNullable: true,
                oldComment: "DamageShare");

            migrationBuilder.AlterColumn<double>(
                name: "AverageMinionsKilled",
                table: "LolTournamentPlayers",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0,
                comment: "AverageMinionsKilled",
                oldClrType: typeof(double),
                oldType: "double precision",
                oldNullable: true,
                oldComment: "AverageMinionsKilled");

            migrationBuilder.AlterColumn<double>(
                name: "AverageKills",
                table: "LolTournamentPlayers",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0,
                comment: "AverageKills",
                oldClrType: typeof(double),
                oldType: "double precision",
                oldNullable: true,
                oldComment: "AverageKills");

            migrationBuilder.AlterColumn<double>(
                name: "AverageDeaths",
                table: "LolTournamentPlayers",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0,
                comment: "AverageDeaths",
                oldClrType: typeof(double),
                oldType: "double precision",
                oldNullable: true,
                oldComment: "AverageDeaths");

            migrationBuilder.AlterColumn<double>(
                name: "AverageAssists",
                table: "LolTournamentPlayers",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0,
                comment: "AverageAssists",
                oldClrType: typeof(double),
                oldType: "double precision",
                oldNullable: true,
                oldComment: "AverageAssists");
        }
    }
}
