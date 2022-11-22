using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KodalibApi.Data.Migrations
{
    public partial class AddStringImdbIdToActor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "actors_imdb_id",
                table: "character");

            migrationBuilder.AddColumn<string>(
                name: "actors_imdb_id",
                table: "actors",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "actors_imdb_id",
                table: "actors");

            migrationBuilder.AddColumn<int>(
                name: "actors_imdb_id",
                table: "character",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }
    }
}
