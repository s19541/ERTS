using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ErtsModel.Migrations
{
    public partial class Edit_Tournament_Remove_PrizePool : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PrizePool",
                table: "Tournaments");

            migrationBuilder.AlterColumn<DateTime>(
                name: "StartTime",
                table: "Tournaments",
                type: "timestamp without time zone",
                nullable: true,
                comment: "Start time",
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldComment: "Start time");

            migrationBuilder.AlterColumn<DateTime>(
                name: "EndTime",
                table: "Tournaments",
                type: "timestamp without time zone",
                nullable: true,
                comment: "End time",
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldComment: "End time");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "StartTime",
                table: "Tournaments",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                comment: "Start time",
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldNullable: true,
                oldComment: "Start time");

            migrationBuilder.AlterColumn<DateTime>(
                name: "EndTime",
                table: "Tournaments",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                comment: "End time",
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldNullable: true,
                oldComment: "End time");

            migrationBuilder.AddColumn<double>(
                name: "PrizePool",
                table: "Tournaments",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0,
                comment: "Prize pool");
        }
    }
}
