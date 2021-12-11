using Microsoft.EntityFrameworkCore.Migrations;

namespace ErtsModel.Migrations
{
    public partial class AddedNumberOfGames : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "NumberOfGames",
                table: "Matches",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                comment: "Number of games");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NumberOfGames",
                table: "Matches");
        }
    }
}
