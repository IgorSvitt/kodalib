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
                    kinopoisk_id = table.Column<string>(type: "text", nullable: true),
                    title = table.Column<string>(type: "text", nullable: false),
                    org_title = table.Column<string>(type: "text", nullable: true),
                    link_video = table.Column<string>(type: "text", nullable: false),
                    poster = table.Column<string>(type: "text", nullable: true),
                    year = table.Column<short>(type: "smallint", nullable: true),
                    duration = table.Column<string>(type: "text", nullable: true),
                    plot = table.Column<string>(type: "text", nullable: true),
                    kinopoisk_rating = table.Column<string>(type: "text", nullable: true),
                    kodalib_rating = table.Column<string>(type: "text", nullable: true),
                    youtube_trailer = table.Column<string>(type: "text", nullable: true),
                    ThumbnailUrl = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_films", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "genres",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_genres", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "person",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    person_kinopoisk_id = table.Column<string>(type: "text", nullable: true),
                    name = table.Column<string>(type: "text", nullable: true),
                    image = table.Column<string>(type: "text", nullable: true),
                    summary = table.Column<string>(type: "text", nullable: true),
                    birth_date = table.Column<string>(type: "text", nullable: true),
                    death_date = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_person", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "role",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_role", x => x.id);
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

            migrationBuilder.CreateTable(
                name: "films_genres",
                columns: table => new
                {
                    films_id = table.Column<int>(type: "integer", nullable: false),
                    genres_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_films_genres", x => new { x.films_id, x.genres_id });
                    table.ForeignKey(
                        name: "FK_films_genres_films_films_id",
                        column: x => x.films_id,
                        principalTable: "films",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_films_genres_genres_genres_id",
                        column: x => x.genres_id,
                        principalTable: "genres",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
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
                        name: "FK_character_films_film_id",
                        column: x => x.film_id,
                        principalTable: "films",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_character_person_actors_id",
                        column: x => x.actors_id,
                        principalTable: "person",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "directors_films",
                columns: table => new
                {
                    film_id = table.Column<int>(type: "integer", nullable: false),
                    director_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_directors_films", x => new { x.film_id, x.director_id });
                    table.ForeignKey(
                        name: "FK_directors_films_films_film_id",
                        column: x => x.film_id,
                        principalTable: "films",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_directors_films_person_director_id",
                        column: x => x.director_id,
                        principalTable: "person",
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
                        name: "FK_top_actors_films_film_id",
                        column: x => x.film_id,
                        principalTable: "films",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_top_actors_person_actors_id",
                        column: x => x.actors_id,
                        principalTable: "person",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "writers_films",
                columns: table => new
                {
                    film_id = table.Column<int>(type: "integer", nullable: false),
                    writer_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_writers_films", x => new { x.film_id, x.writer_id });
                    table.ForeignKey(
                        name: "FK_writers_films_films_film_id",
                        column: x => x.film_id,
                        principalTable: "films",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_writers_films_person_writer_id",
                        column: x => x.writer_id,
                        principalTable: "person",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "role_person",
                columns: table => new
                {
                    person_id = table.Column<int>(type: "integer", nullable: false),
                    role_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_role_person", x => new { x.person_id, x.role_id });
                    table.ForeignKey(
                        name: "FK_role_person_person_person_id",
                        column: x => x.person_id,
                        principalTable: "person",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_role_person_role_role_id",
                        column: x => x.role_id,
                        principalTable: "role",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_character_actors_id",
                table: "character",
                column: "actors_id");

            migrationBuilder.CreateIndex(
                name: "IX_directors_films_director_id",
                table: "directors_films",
                column: "director_id");

            migrationBuilder.CreateIndex(
                name: "IX_films_countries_country_id",
                table: "films_countries",
                column: "country_id");

            migrationBuilder.CreateIndex(
                name: "IX_films_genres_genres_id",
                table: "films_genres",
                column: "genres_id");

            migrationBuilder.CreateIndex(
                name: "IX_role_person_role_id",
                table: "role_person",
                column: "role_id");

            migrationBuilder.CreateIndex(
                name: "IX_top_actors_actors_id",
                table: "top_actors",
                column: "actors_id");

            migrationBuilder.CreateIndex(
                name: "IX_writers_films_writer_id",
                table: "writers_films",
                column: "writer_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "character");

            migrationBuilder.DropTable(
                name: "directors_films");

            migrationBuilder.DropTable(
                name: "films_countries");

            migrationBuilder.DropTable(
                name: "films_genres");

            migrationBuilder.DropTable(
                name: "role_person");

            migrationBuilder.DropTable(
                name: "top_actors");

            migrationBuilder.DropTable(
                name: "writers_films");

            migrationBuilder.DropTable(
                name: "countries");

            migrationBuilder.DropTable(
                name: "genres");

            migrationBuilder.DropTable(
                name: "role");

            migrationBuilder.DropTable(
                name: "films");

            migrationBuilder.DropTable(
                name: "person");
        }
    }
}
