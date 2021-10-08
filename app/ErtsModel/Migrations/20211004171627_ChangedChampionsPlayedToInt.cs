using Microsoft.EntityFrameworkCore.Migrations;

namespace ErtsModel.Migrations
{
    public partial class ChangedChampionsPlayedToInt : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "ChampionsPlayed",
                table: "LolTournamentPlayers",
                type: "integer",
                nullable: false,
                comment: "ChampionPlayed",
                oldClrType: typeof(double),
                oldType: "double precision",
                oldComment: "ChampionPlayed");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "ChampionsPlayed",
                table: "LolTournamentPlayers",
                type: "double precision",
                nullable: false,
                comment: "ChampionPlayed",
                oldClrType: typeof(int),
                oldType: "integer",
                oldComment: "ChampionPlayed");
        }
    }
}
