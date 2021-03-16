using Microsoft.EntityFrameworkCore.Migrations;

namespace ErtsModel.Migrations
{
    public partial class Change_LolTeams_To_Teams : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LolGamesStats_LolTeams_BlueTeamId",
                table: "LolGamesStats");

            migrationBuilder.DropForeignKey(
                name: "FK_LolGamesStats_LolTeams_RedTeamId",
                table: "LolGamesStats");

            migrationBuilder.DropForeignKey(
                name: "FK_Players_LolTeams_TeamId",
                table: "Players");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LolTeams",
                table: "LolTeams");

            migrationBuilder.RenameTable(
                name: "LolTeams",
                newName: "Teams");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Teams",
                table: "Teams",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_LolGamesStats_Teams_BlueTeamId",
                table: "LolGamesStats",
                column: "BlueTeamId",
                principalTable: "Teams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_LolGamesStats_Teams_RedTeamId",
                table: "LolGamesStats",
                column: "RedTeamId",
                principalTable: "Teams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Players_Teams_TeamId",
                table: "Players",
                column: "TeamId",
                principalTable: "Teams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LolGamesStats_Teams_BlueTeamId",
                table: "LolGamesStats");

            migrationBuilder.DropForeignKey(
                name: "FK_LolGamesStats_Teams_RedTeamId",
                table: "LolGamesStats");

            migrationBuilder.DropForeignKey(
                name: "FK_Players_Teams_TeamId",
                table: "Players");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Teams",
                table: "Teams");

            migrationBuilder.RenameTable(
                name: "Teams",
                newName: "LolTeams");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LolTeams",
                table: "LolTeams",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_LolGamesStats_LolTeams_BlueTeamId",
                table: "LolGamesStats",
                column: "BlueTeamId",
                principalTable: "LolTeams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_LolGamesStats_LolTeams_RedTeamId",
                table: "LolGamesStats",
                column: "RedTeamId",
                principalTable: "LolTeams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Players_LolTeams_TeamId",
                table: "Players",
                column: "TeamId",
                principalTable: "LolTeams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
