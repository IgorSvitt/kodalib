using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace KodalibApi.Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "countries",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_countries", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "films",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    imdb_id = table.Column<string>(type: "text", nullable: false),
                    title = table.Column<string>(type: "text", nullable: false),
                    poster = table.Column<string>(type: "text", nullable: true),
                    year = table.Column<short>(type: "smallint", nullable: true),
                    duration = table.Column<string>(type: "text", nullable: true),
                    plot = table.Column<string>(type: "text", nullable: true),
                    imdb_rating = table.Column<short>(type: "smallint", nullable: true),
                    kodalib_rating = table.Column<short>(type: "smallint", nullable: true),
                    budget = table.Column<string>(type: "text", nullable: true),
                    gross_worldwide = table.Column<string>(type: "text", nullable: true),
                    youtube_trailer = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_films", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "films_countries",
                columns: table => new
                {
                    films_id = table.Column<int>(type: "integer", nullable: false),
                    country_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_films_countries", x => new { x.films_id, x.country_id });
                    table.ForeignKey(
                        name: "FK_films_countries_countries_country_id",
                        column: x => x.country_id,
                        principalTable: "countries",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_films_countries_films_films_id",
                        column: x => x.films_id,
                        principalTable: "films",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_films_countries_country_id",
                table: "films_countries",
                column: "country_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "films_countries");

            migrationBuilder.DropTable(
                name: "countries");

            migrationBuilder.DropTable(
                name: "films");
        }
    }
}
