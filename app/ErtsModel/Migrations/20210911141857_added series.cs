using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace ErtsModel.Migrations
{
    public partial class addedseries : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tournaments_Leagues_LeagueId",
                table: "Tournaments");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "Surname",
                table: "Players");

            migrationBuilder.RenameColumn(
                name: "LeagueId",
                table: "Tournaments",
                newName: "SerieId");

            migrationBuilder.RenameIndex(
                name: "IX_Tournaments_LeagueId",
                table: "Tournaments",
                newName: "IX_Tournaments_SerieId");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "Players",
                type: "text",
                nullable: true,
                comment: "First Name");

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "Players",
                type: "text",
                nullable: true,
                comment: "Last Name");

            migrationBuilder.CreateTable(
                name: "Series",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false, comment: "Id")
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false, comment: "Name"),
                    StartTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, comment: "Start time"),
                    EndTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, comment: "End time"),
                    LeagueId = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Series", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Series_Leagues_LeagueId",
                        column: x => x.LeagueId,
                        principalTable: "Leagues",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                },
                comment: "Serie");

            migrationBuilder.CreateIndex(
                name: "IX_Series_LeagueId",
                table: "Series",
                column: "LeagueId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tournaments_Series_SerieId",
                table: "Tournaments",
                column: "SerieId",
                principalTable: "Series",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tournaments_Series_SerieId",
                table: "Tournaments");

            migrationBuilder.DropTable(
                name: "Series");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "Players");

            migrationBuilder.RenameColumn(
                name: "SerieId",
                table: "Tournaments",
                newName: "LeagueId");

            migrationBuilder.RenameIndex(
                name: "IX_Tournaments_SerieId",
                table: "Tournaments",
                newName: "IX_Tournaments_LeagueId");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Players",
                type: "text",
                nullable: true,
                comment: "Name");

            migrationBuilder.AddColumn<string>(
                name: "Surname",
                table: "Players",
                type: "text",
                nullable: true,
                comment: "Surname");

            migrationBuilder.AddForeignKey(
                name: "FK_Tournaments_Leagues_LeagueId",
                table: "Tournaments",
                column: "LeagueId",
                principalTable: "Leagues",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
