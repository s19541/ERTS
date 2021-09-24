using Microsoft.EntityFrameworkCore.Migrations;

namespace ErtsModel.Migrations
{
    public partial class AddedApiIdToGame : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ApiId",
                table: "Games",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                comment: "ApiId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ApiId",
                table: "Games");
        }
    }
}
