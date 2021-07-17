using Microsoft.EntityFrameworkCore.Migrations;

namespace ErtsModel.Migrations
{
    public partial class lolGamePlayerFixed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LolGamePlayers_Games_LolGameId",
                table: "LolGamePlayers");

            migrationBuilder.DropForeignKey(
                name: "FK_LolGamePlayers_Players_GameId",
                table: "LolGamePlayers");

            migrationBuilder.DropIndex(
                name: "IX_LolGamePlayers_LolGameId",
                table: "LolGamePlayers");

            migrationBuilder.DropColumn(
                name: "LolGameId",
                table: "LolGamePlayers");

            migrationBuilder.CreateIndex(
                name: "IX_LolGamePlayers_PlayerId",
                table: "LolGamePlayers",
                column: "PlayerId");

            migrationBuilder.AddForeignKey(
                name: "FK_LolGamePlayers_Games_GameId",
                table: "LolGamePlayers",
                column: "GameId",
                principalTable: "Games",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_LolGamePlayers_Players_PlayerId",
                table: "LolGamePlayers",
                column: "PlayerId",
                principalTable: "Players",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LolGamePlayers_Games_GameId",
                table: "LolGamePlayers");

            migrationBuilder.DropForeignKey(
                name: "FK_LolGamePlayers_Players_PlayerId",
                table: "LolGamePlayers");

            migrationBuilder.DropIndex(
                name: "IX_LolGamePlayers_PlayerId",
                table: "LolGamePlayers");

            migrationBuilder.AddColumn<long>(
                name: "LolGameId",
                table: "LolGamePlayers",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_LolGamePlayers_LolGameId",
                table: "LolGamePlayers",
                column: "LolGameId");

            migrationBuilder.AddForeignKey(
                name: "FK_LolGamePlayers_Games_LolGameId",
                table: "LolGamePlayers",
                column: "LolGameId",
                principalTable: "Games",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_LolGamePlayers_Players_GameId",
                table: "LolGamePlayers",
                column: "GameId",
                principalTable: "Players",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
