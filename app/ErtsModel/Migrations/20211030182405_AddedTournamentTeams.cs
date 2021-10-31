using Microsoft.EntityFrameworkCore.Migrations;

namespace ErtsModel.Migrations
{
    public partial class AddedTournamentTeams : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LolGameTeam_Games_GameId",
                table: "LolGameTeam");

            migrationBuilder.DropForeignKey(
                name: "FK_LolGameTeam_LolChampions_Ban1Id",
                table: "LolGameTeam");

            migrationBuilder.DropForeignKey(
                name: "FK_LolGameTeam_LolChampions_Ban2Id",
                table: "LolGameTeam");

            migrationBuilder.DropForeignKey(
                name: "FK_LolGameTeam_LolChampions_Ban3Id",
                table: "LolGameTeam");

            migrationBuilder.DropForeignKey(
                name: "FK_LolGameTeam_LolChampions_Ban4Id",
                table: "LolGameTeam");

            migrationBuilder.DropForeignKey(
                name: "FK_LolGameTeam_LolChampions_Ban5Id",
                table: "LolGameTeam");

            migrationBuilder.DropForeignKey(
                name: "FK_LolGameTeam_Teams_TeamId",
                table: "LolGameTeam");

            migrationBuilder.DropForeignKey(
                name: "FK_LolTournamentTeams_LolChampions_ChampionId1",
                table: "LolTournamentTeams");

            migrationBuilder.DropForeignKey(
                name: "FK_LolTournamentTeams_LolChampions_ChampionId2",
                table: "LolTournamentTeams");

            migrationBuilder.DropForeignKey(
                name: "FK_LolTournamentTeams_LolChampions_ChampionId3",
                table: "LolTournamentTeams");

            migrationBuilder.DropForeignKey(
                name: "FK_LolTournamentTeams_LolChampions_ChampionId4",
                table: "LolTournamentTeams");

            migrationBuilder.DropForeignKey(
                name: "FK_LolTournamentTeams_LolChampions_ChampionId5",
                table: "LolTournamentTeams");

            migrationBuilder.DropForeignKey(
                name: "FK_LolTournamentTeams_Teams_TeamId",
                table: "LolTournamentTeams");

            migrationBuilder.DropForeignKey(
                name: "FK_LolTournamentTeams_Tournaments_TournamentId",
                table: "LolTournamentTeams");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LolGameTeam",
                table: "LolGameTeam");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LolTournamentTeams",
                table: "LolTournamentTeams");

            migrationBuilder.RenameTable(
                name: "LolGameTeam",
                newName: "LolGameTeams");

            migrationBuilder.RenameTable(
                name: "LolTournamentTeams",
                newName: "TournamentTeams");

            migrationBuilder.RenameIndex(
                name: "IX_LolGameTeam_TeamId",
                table: "LolGameTeams",
                newName: "IX_LolGameTeams_TeamId");

            migrationBuilder.RenameIndex(
                name: "IX_LolGameTeam_GameId",
                table: "LolGameTeams",
                newName: "IX_LolGameTeams_GameId");

            migrationBuilder.RenameIndex(
                name: "IX_LolGameTeam_Ban5Id",
                table: "LolGameTeams",
                newName: "IX_LolGameTeams_Ban5Id");

            migrationBuilder.RenameIndex(
                name: "IX_LolGameTeam_Ban4Id",
                table: "LolGameTeams",
                newName: "IX_LolGameTeams_Ban4Id");

            migrationBuilder.RenameIndex(
                name: "IX_LolGameTeam_Ban3Id",
                table: "LolGameTeams",
                newName: "IX_LolGameTeams_Ban3Id");

            migrationBuilder.RenameIndex(
                name: "IX_LolGameTeam_Ban2Id",
                table: "LolGameTeams",
                newName: "IX_LolGameTeams_Ban2Id");

            migrationBuilder.RenameIndex(
                name: "IX_LolGameTeam_Ban1Id",
                table: "LolGameTeams",
                newName: "IX_LolGameTeams_Ban1Id");

            migrationBuilder.RenameIndex(
                name: "IX_LolTournamentTeams_TournamentId",
                table: "TournamentTeams",
                newName: "IX_TournamentTeams_TournamentId");

            migrationBuilder.RenameIndex(
                name: "IX_LolTournamentTeams_TeamId",
                table: "TournamentTeams",
                newName: "IX_TournamentTeams_TeamId");

            migrationBuilder.RenameIndex(
                name: "IX_LolTournamentTeams_ChampionId5",
                table: "TournamentTeams",
                newName: "IX_TournamentTeams_ChampionId5");

            migrationBuilder.RenameIndex(
                name: "IX_LolTournamentTeams_ChampionId4",
                table: "TournamentTeams",
                newName: "IX_TournamentTeams_ChampionId4");

            migrationBuilder.RenameIndex(
                name: "IX_LolTournamentTeams_ChampionId3",
                table: "TournamentTeams",
                newName: "IX_TournamentTeams_ChampionId3");

            migrationBuilder.RenameIndex(
                name: "IX_LolTournamentTeams_ChampionId2",
                table: "TournamentTeams",
                newName: "IX_TournamentTeams_ChampionId2");

            migrationBuilder.RenameIndex(
                name: "IX_LolTournamentTeams_ChampionId1",
                table: "TournamentTeams",
                newName: "IX_TournamentTeams_ChampionId1");

            migrationBuilder.AlterColumn<double>(
                name: "AverageTowerDestroyed",
                table: "TournamentTeams",
                type: "double precision",
                nullable: true,
                comment: "AverageTowerDestroyed",
                oldClrType: typeof(double),
                oldType: "double precision",
                oldComment: "AverageTowerDestroyed");

            migrationBuilder.AlterColumn<double>(
                name: "AverageKills",
                table: "TournamentTeams",
                type: "double precision",
                nullable: true,
                comment: "AverageKills",
                oldClrType: typeof(double),
                oldType: "double precision",
                oldComment: "AverageKills");

            migrationBuilder.AlterColumn<double>(
                name: "AverageHeraldKilled",
                table: "TournamentTeams",
                type: "double precision",
                nullable: true,
                comment: "AverageHeraldKilled",
                oldClrType: typeof(double),
                oldType: "double precision",
                oldComment: "AverageHeraldKilled");

            migrationBuilder.AlterColumn<double>(
                name: "AverageGoldEarned",
                table: "TournamentTeams",
                type: "double precision",
                nullable: true,
                comment: "AverageGoldEarned",
                oldClrType: typeof(double),
                oldType: "double precision",
                oldComment: "AverageGoldEarned");

            migrationBuilder.AlterColumn<double>(
                name: "AverageDragonKilled",
                table: "TournamentTeams",
                type: "double precision",
                nullable: true,
                comment: "AverageDragonKilled",
                oldClrType: typeof(double),
                oldType: "double precision",
                oldComment: "AverageDragonKilled");

            migrationBuilder.AlterColumn<double>(
                name: "AverageDeaths",
                table: "TournamentTeams",
                type: "double precision",
                nullable: true,
                comment: "AverageDeaths",
                oldClrType: typeof(double),
                oldType: "double precision",
                oldComment: "AverageDeaths");

            migrationBuilder.AlterColumn<double>(
                name: "AverageBaronKilled",
                table: "TournamentTeams",
                type: "double precision",
                nullable: true,
                comment: "AverageBaronKilled",
                oldClrType: typeof(double),
                oldType: "double precision",
                oldComment: "AverageBaronKilled");

            migrationBuilder.AlterColumn<double>(
                name: "AverageAssists",
                table: "TournamentTeams",
                type: "double precision",
                nullable: true,
                comment: "AverageAssists",
                oldClrType: typeof(double),
                oldType: "double precision",
                oldComment: "AverageAssists");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "TournamentTeams",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LolGameTeams",
                table: "LolGameTeams",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TournamentTeams",
                table: "TournamentTeams",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_LolGameTeams_Games_GameId",
                table: "LolGameTeams",
                column: "GameId",
                principalTable: "Games",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_LolGameTeams_LolChampions_Ban1Id",
                table: "LolGameTeams",
                column: "Ban1Id",
                principalTable: "LolChampions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_LolGameTeams_LolChampions_Ban2Id",
                table: "LolGameTeams",
                column: "Ban2Id",
                principalTable: "LolChampions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_LolGameTeams_LolChampions_Ban3Id",
                table: "LolGameTeams",
                column: "Ban3Id",
                principalTable: "LolChampions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_LolGameTeams_LolChampions_Ban4Id",
                table: "LolGameTeams",
                column: "Ban4Id",
                principalTable: "LolChampions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_LolGameTeams_LolChampions_Ban5Id",
                table: "LolGameTeams",
                column: "Ban5Id",
                principalTable: "LolChampions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_LolGameTeams_Teams_TeamId",
                table: "LolGameTeams",
                column: "TeamId",
                principalTable: "Teams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TournamentTeams_LolChampions_ChampionId1",
                table: "TournamentTeams",
                column: "ChampionId1",
                principalTable: "LolChampions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TournamentTeams_LolChampions_ChampionId2",
                table: "TournamentTeams",
                column: "ChampionId2",
                principalTable: "LolChampions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TournamentTeams_LolChampions_ChampionId3",
                table: "TournamentTeams",
                column: "ChampionId3",
                principalTable: "LolChampions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TournamentTeams_LolChampions_ChampionId4",
                table: "TournamentTeams",
                column: "ChampionId4",
                principalTable: "LolChampions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TournamentTeams_LolChampions_ChampionId5",
                table: "TournamentTeams",
                column: "ChampionId5",
                principalTable: "LolChampions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TournamentTeams_Teams_TeamId",
                table: "TournamentTeams",
                column: "TeamId",
                principalTable: "Teams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TournamentTeams_Tournaments_TournamentId",
                table: "TournamentTeams",
                column: "TournamentId",
                principalTable: "Tournaments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LolGameTeams_Games_GameId",
                table: "LolGameTeams");

            migrationBuilder.DropForeignKey(
                name: "FK_LolGameTeams_LolChampions_Ban1Id",
                table: "LolGameTeams");

            migrationBuilder.DropForeignKey(
                name: "FK_LolGameTeams_LolChampions_Ban2Id",
                table: "LolGameTeams");

            migrationBuilder.DropForeignKey(
                name: "FK_LolGameTeams_LolChampions_Ban3Id",
                table: "LolGameTeams");

            migrationBuilder.DropForeignKey(
                name: "FK_LolGameTeams_LolChampions_Ban4Id",
                table: "LolGameTeams");

            migrationBuilder.DropForeignKey(
                name: "FK_LolGameTeams_LolChampions_Ban5Id",
                table: "LolGameTeams");

            migrationBuilder.DropForeignKey(
                name: "FK_LolGameTeams_Teams_TeamId",
                table: "LolGameTeams");

            migrationBuilder.DropForeignKey(
                name: "FK_TournamentTeams_LolChampions_ChampionId1",
                table: "TournamentTeams");

            migrationBuilder.DropForeignKey(
                name: "FK_TournamentTeams_LolChampions_ChampionId2",
                table: "TournamentTeams");

            migrationBuilder.DropForeignKey(
                name: "FK_TournamentTeams_LolChampions_ChampionId3",
                table: "TournamentTeams");

            migrationBuilder.DropForeignKey(
                name: "FK_TournamentTeams_LolChampions_ChampionId4",
                table: "TournamentTeams");

            migrationBuilder.DropForeignKey(
                name: "FK_TournamentTeams_LolChampions_ChampionId5",
                table: "TournamentTeams");

            migrationBuilder.DropForeignKey(
                name: "FK_TournamentTeams_Teams_TeamId",
                table: "TournamentTeams");

            migrationBuilder.DropForeignKey(
                name: "FK_TournamentTeams_Tournaments_TournamentId",
                table: "TournamentTeams");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LolGameTeams",
                table: "LolGameTeams");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TournamentTeams",
                table: "TournamentTeams");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "TournamentTeams");

            migrationBuilder.RenameTable(
                name: "LolGameTeams",
                newName: "LolGameTeam");

            migrationBuilder.RenameTable(
                name: "TournamentTeams",
                newName: "LolTournamentTeams");

            migrationBuilder.RenameIndex(
                name: "IX_LolGameTeams_TeamId",
                table: "LolGameTeam",
                newName: "IX_LolGameTeam_TeamId");

            migrationBuilder.RenameIndex(
                name: "IX_LolGameTeams_GameId",
                table: "LolGameTeam",
                newName: "IX_LolGameTeam_GameId");

            migrationBuilder.RenameIndex(
                name: "IX_LolGameTeams_Ban5Id",
                table: "LolGameTeam",
                newName: "IX_LolGameTeam_Ban5Id");

            migrationBuilder.RenameIndex(
                name: "IX_LolGameTeams_Ban4Id",
                table: "LolGameTeam",
                newName: "IX_LolGameTeam_Ban4Id");

            migrationBuilder.RenameIndex(
                name: "IX_LolGameTeams_Ban3Id",
                table: "LolGameTeam",
                newName: "IX_LolGameTeam_Ban3Id");

            migrationBuilder.RenameIndex(
                name: "IX_LolGameTeams_Ban2Id",
                table: "LolGameTeam",
                newName: "IX_LolGameTeam_Ban2Id");

            migrationBuilder.RenameIndex(
                name: "IX_LolGameTeams_Ban1Id",
                table: "LolGameTeam",
                newName: "IX_LolGameTeam_Ban1Id");

            migrationBuilder.RenameIndex(
                name: "IX_TournamentTeams_TournamentId",
                table: "LolTournamentTeams",
                newName: "IX_LolTournamentTeams_TournamentId");

            migrationBuilder.RenameIndex(
                name: "IX_TournamentTeams_TeamId",
                table: "LolTournamentTeams",
                newName: "IX_LolTournamentTeams_TeamId");

            migrationBuilder.RenameIndex(
                name: "IX_TournamentTeams_ChampionId5",
                table: "LolTournamentTeams",
                newName: "IX_LolTournamentTeams_ChampionId5");

            migrationBuilder.RenameIndex(
                name: "IX_TournamentTeams_ChampionId4",
                table: "LolTournamentTeams",
                newName: "IX_LolTournamentTeams_ChampionId4");

            migrationBuilder.RenameIndex(
                name: "IX_TournamentTeams_ChampionId3",
                table: "LolTournamentTeams",
                newName: "IX_LolTournamentTeams_ChampionId3");

            migrationBuilder.RenameIndex(
                name: "IX_TournamentTeams_ChampionId2",
                table: "LolTournamentTeams",
                newName: "IX_LolTournamentTeams_ChampionId2");

            migrationBuilder.RenameIndex(
                name: "IX_TournamentTeams_ChampionId1",
                table: "LolTournamentTeams",
                newName: "IX_LolTournamentTeams_ChampionId1");

            migrationBuilder.AlterColumn<double>(
                name: "AverageTowerDestroyed",
                table: "LolTournamentTeams",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0,
                comment: "AverageTowerDestroyed",
                oldClrType: typeof(double),
                oldType: "double precision",
                oldNullable: true,
                oldComment: "AverageTowerDestroyed");

            migrationBuilder.AlterColumn<double>(
                name: "AverageKills",
                table: "LolTournamentTeams",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0,
                comment: "AverageKills",
                oldClrType: typeof(double),
                oldType: "double precision",
                oldNullable: true,
                oldComment: "AverageKills");

            migrationBuilder.AlterColumn<double>(
                name: "AverageHeraldKilled",
                table: "LolTournamentTeams",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0,
                comment: "AverageHeraldKilled",
                oldClrType: typeof(double),
                oldType: "double precision",
                oldNullable: true,
                oldComment: "AverageHeraldKilled");

            migrationBuilder.AlterColumn<double>(
                name: "AverageGoldEarned",
                table: "LolTournamentTeams",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0,
                comment: "AverageGoldEarned",
                oldClrType: typeof(double),
                oldType: "double precision",
                oldNullable: true,
                oldComment: "AverageGoldEarned");

            migrationBuilder.AlterColumn<double>(
                name: "AverageDragonKilled",
                table: "LolTournamentTeams",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0,
                comment: "AverageDragonKilled",
                oldClrType: typeof(double),
                oldType: "double precision",
                oldNullable: true,
                oldComment: "AverageDragonKilled");

            migrationBuilder.AlterColumn<double>(
                name: "AverageDeaths",
                table: "LolTournamentTeams",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0,
                comment: "AverageDeaths",
                oldClrType: typeof(double),
                oldType: "double precision",
                oldNullable: true,
                oldComment: "AverageDeaths");

            migrationBuilder.AlterColumn<double>(
                name: "AverageBaronKilled",
                table: "LolTournamentTeams",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0,
                comment: "AverageBaronKilled",
                oldClrType: typeof(double),
                oldType: "double precision",
                oldNullable: true,
                oldComment: "AverageBaronKilled");

            migrationBuilder.AlterColumn<double>(
                name: "AverageAssists",
                table: "LolTournamentTeams",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0,
                comment: "AverageAssists",
                oldClrType: typeof(double),
                oldType: "double precision",
                oldNullable: true,
                oldComment: "AverageAssists");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LolGameTeam",
                table: "LolGameTeam",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LolTournamentTeams",
                table: "LolTournamentTeams",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_LolGameTeam_Games_GameId",
                table: "LolGameTeam",
                column: "GameId",
                principalTable: "Games",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_LolGameTeam_LolChampions_Ban1Id",
                table: "LolGameTeam",
                column: "Ban1Id",
                principalTable: "LolChampions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_LolGameTeam_LolChampions_Ban2Id",
                table: "LolGameTeam",
                column: "Ban2Id",
                principalTable: "LolChampions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_LolGameTeam_LolChampions_Ban3Id",
                table: "LolGameTeam",
                column: "Ban3Id",
                principalTable: "LolChampions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_LolGameTeam_LolChampions_Ban4Id",
                table: "LolGameTeam",
                column: "Ban4Id",
                principalTable: "LolChampions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_LolGameTeam_LolChampions_Ban5Id",
                table: "LolGameTeam",
                column: "Ban5Id",
                principalTable: "LolChampions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_LolGameTeam_Teams_TeamId",
                table: "LolGameTeam",
                column: "TeamId",
                principalTable: "Teams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_LolTournamentTeams_LolChampions_ChampionId1",
                table: "LolTournamentTeams",
                column: "ChampionId1",
                principalTable: "LolChampions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_LolTournamentTeams_LolChampions_ChampionId2",
                table: "LolTournamentTeams",
                column: "ChampionId2",
                principalTable: "LolChampions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_LolTournamentTeams_LolChampions_ChampionId3",
                table: "LolTournamentTeams",
                column: "ChampionId3",
                principalTable: "LolChampions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_LolTournamentTeams_LolChampions_ChampionId4",
                table: "LolTournamentTeams",
                column: "ChampionId4",
                principalTable: "LolChampions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_LolTournamentTeams_LolChampions_ChampionId5",
                table: "LolTournamentTeams",
                column: "ChampionId5",
                principalTable: "LolChampions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_LolTournamentTeams_Teams_TeamId",
                table: "LolTournamentTeams",
                column: "TeamId",
                principalTable: "Teams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_LolTournamentTeams_Tournaments_TournamentId",
                table: "LolTournamentTeams",
                column: "TournamentId",
                principalTable: "Tournaments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
