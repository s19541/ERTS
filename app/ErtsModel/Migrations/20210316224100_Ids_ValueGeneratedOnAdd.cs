using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace ErtsModel.Migrations
{
    public partial class Ids_ValueGeneratedOnAdd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<long>(
                name: "Id",
                table: "Teams",
                type: "bigint",
                nullable: false,
                comment: "Id",
                oldClrType: typeof(long),
                oldType: "bigint",
                oldComment: "Id")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<long>(
                name: "Id",
                table: "Players",
                type: "bigint",
                nullable: false,
                comment: "Id",
                oldClrType: typeof(long),
                oldType: "bigint",
                oldComment: "Id")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<long>(
                name: "Id",
                table: "LolGamesStats",
                type: "bigint",
                nullable: false,
                comment: "Id",
                oldClrType: typeof(long),
                oldType: "bigint",
                oldComment: "Id")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<long>(
                name: "Id",
                table: "Teams",
                type: "bigint",
                nullable: false,
                comment: "Id",
                oldClrType: typeof(long),
                oldType: "bigint",
                oldComment: "Id")
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<long>(
                name: "Id",
                table: "Players",
                type: "bigint",
                nullable: false,
                comment: "Id",
                oldClrType: typeof(long),
                oldType: "bigint",
                oldComment: "Id")
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<long>(
                name: "Id",
                table: "LolGamesStats",
                type: "bigint",
                nullable: false,
                comment: "Id",
                oldClrType: typeof(long),
                oldType: "bigint",
                oldComment: "Id")
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);
        }
    }
}
