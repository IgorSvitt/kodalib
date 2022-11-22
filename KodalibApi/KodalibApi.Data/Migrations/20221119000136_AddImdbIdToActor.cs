using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KodalibApi.Data.Migrations
{
    public partial class AddImdbIdToActor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "actors_imdb_id",
                table: "character",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "actors_imdb_id",
                table: "character");
        }
    }
}
