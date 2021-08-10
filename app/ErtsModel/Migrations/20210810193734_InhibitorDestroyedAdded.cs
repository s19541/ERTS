using Microsoft.EntityFrameworkCore.Migrations;

namespace ErtsModel.Migrations
{
    public partial class InhibitorDestroyedAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "TurretDestroyed",
                table: "LolGameTeam",
                type: "integer",
                nullable: false,
                comment: "Inhibitor destroyed",
                oldClrType: typeof(int),
                oldType: "integer",
                oldComment: "Turret destroyed");

            migrationBuilder.AddColumn<int>(
                name: "InhibitorDestroyed",
                table: "LolGameTeam",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "InhibitorDestroyed",
                table: "LolGameTeam");

            migrationBuilder.AlterColumn<int>(
                name: "TurretDestroyed",
                table: "LolGameTeam",
                type: "integer",
                nullable: false,
                comment: "Turret destroyed",
                oldClrType: typeof(int),
                oldType: "integer",
                oldComment: "Inhibitor destroyed");
        }
    }
}
