using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ErtsModel.Migrations
{
    public partial class addedapiIds : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ApiId",
                table: "Tournaments",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                comment: "ApiId");

            migrationBuilder.AddColumn<int>(
                name: "ApiId",
                table: "Teams",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                comment: "ApiId");

            migrationBuilder.AlterColumn<DateTime>(
                name: "StartTime",
                table: "Series",
                type: "timestamp without time zone",
                nullable: true,
                comment: "Start time",
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldComment: "Start time");

            migrationBuilder.AlterColumn<DateTime>(
                name: "EndTime",
                table: "Series",
                type: "timestamp without time zone",
                nullable: true,
                comment: "End time",
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldComment: "End time");

            migrationBuilder.AddColumn<int>(
                name: "ApiId",
                table: "Series",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                comment: "ApiId");

            migrationBuilder.AddColumn<int>(
                name: "ApiId",
                table: "Players",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                comment: "ApiId");

            migrationBuilder.AlterColumn<DateTime>(
                name: "StartTime",
                table: "Matches",
                type: "timestamp without time zone",
                nullable: true,
                comment: "Start time",
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldComment: "Start time");

            migrationBuilder.AlterColumn<DateTime>(
                name: "EndTime",
                table: "Matches",
                type: "timestamp without time zone",
                nullable: true,
                comment: "End time",
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldComment: "End time");

            migrationBuilder.AddColumn<int>(
                name: "ApiId",
                table: "Matches",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                comment: "ApiId");

            migrationBuilder.AddColumn<int>(
                name: "ApiId",
                table: "Leagues",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                comment: "ApiId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ApiId",
                table: "Tournaments");

            migrationBuilder.DropColumn(
                name: "ApiId",
                table: "Teams");

            migrationBuilder.DropColumn(
                name: "ApiId",
                table: "Series");

            migrationBuilder.DropColumn(
                name: "ApiId",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "ApiId",
                table: "Matches");

            migrationBuilder.DropColumn(
                name: "ApiId",
                table: "Leagues");

            migrationBuilder.AlterColumn<DateTime>(
                name: "StartTime",
                table: "Series",
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
                table: "Series",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                comment: "End time",
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldNullable: true,
                oldComment: "End time");

            migrationBuilder.AlterColumn<DateTime>(
                name: "StartTime",
                table: "Matches",
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
                table: "Matches",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                comment: "End time",
                oldClrType: typeof(DateTime),
                oldType: "timestamp without time zone",
                oldNullable: true,
                oldComment: "End time");
        }
    }
}
