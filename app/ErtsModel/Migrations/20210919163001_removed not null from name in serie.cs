using Microsoft.EntityFrameworkCore.Migrations;

namespace ErtsModel.Migrations
{
    public partial class removednotnullfromnameinserie : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Series",
                type: "text",
                nullable: true,
                comment: "Name",
                oldClrType: typeof(string),
                oldType: "text",
                oldComment: "Name");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Series",
                type: "text",
                nullable: false,
                defaultValue: "",
                comment: "Name",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true,
                oldComment: "Name");
        }
    }
}
