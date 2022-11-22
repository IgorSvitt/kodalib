using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace KodalibApi.Data.Migrations
{
    public partial class AddActorsAndRelations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "actors",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false),
                    roles = table.Column<string>(type: "text", nullable: true),
                    image = table.Column<string>(type: "text", nullable: true),
                    summary = table.Column<string>(type: "text", nullable: true),
                    birth_date = table.Column<string>(type: "text", nullable: true),
                    death_date = table.Column<string>(type: "text", nullable: true),
                    height = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_actors", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "character",
                columns: table => new
                {
                    film_id = table.Column<int>(type: "integer", nullable: false),
                    actors_id = table.Column<int>(type: "integer", nullable: false),
                    role = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_character", x => new { x.film_id, x.actors_id });
                    table.ForeignKey(
                        name: "FK_character_actors_actors_id",
                        column: x => x.actors_id,
                        principalTable: "actors",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_character_films_film_id",
                        column: x => x.film_id,
                        principalTable: "films",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "top_actors",
                columns: table => new
                {
                    film_id = table.Column<int>(type: "integer", nullable: false),
                    actors_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_top_actors", x => new { x.film_id, x.actors_id });
                    table.ForeignKey(
                        name: "FK_top_actors_actors_actors_id",
                        column: x => x.actors_id,
                        principalTable: "actors",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_top_actors_films_film_id",
                        column: x => x.film_id,
                        principalTable: "films",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_character_actors_id",
                table: "character",
                column: "actors_id");

            migrationBuilder.CreateIndex(
                name: "IX_top_actors_actors_id",
                table: "top_actors",
                column: "actors_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "character");

            migrationBuilder.DropTable(
                name: "top_actors");

            migrationBuilder.DropTable(
                name: "actors");
        }
    }
}
