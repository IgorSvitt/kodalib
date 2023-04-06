using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace KodalibApi.Dal.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "comments",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    comment = table.Column<string>(type: "text", nullable: false),
                    rate = table.Column<int>(type: "integer", nullable: false),
                    user = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_comments", x => x.id);
                });

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
                    poster = table.Column<string>(type: "text", nullable: true),
                    year = table.Column<short>(type: "smallint", nullable: true),
                    duration = table.Column<string>(type: "text", nullable: true),
                    plot = table.Column<string>(type: "text", nullable: true),
                    kinopoisk_rating = table.Column<string>(type: "text", nullable: true),
                    kodalib_rating = table.Column<string>(type: "text", nullable: true),
                    count_rate = table.Column<int>(type: "integer", nullable: false),
                    youtube_trailer = table.Column<string>(type: "text", nullable: true)
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
                    image = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_person", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "series",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    kinopoisk_id = table.Column<string>(type: "text", nullable: true),
                    title = table.Column<string>(type: "text", nullable: false),
                    poster = table.Column<string>(type: "text", nullable: true),
                    year = table.Column<short>(type: "smallint", nullable: true),
                    duration = table.Column<string>(type: "text", nullable: true),
                    plot = table.Column<string>(type: "text", nullable: true),
                    kinopoisk_rating = table.Column<string>(type: "text", nullable: true),
                    kodalib_rating = table.Column<string>(type: "text", nullable: true),
                    count_rate = table.Column<int>(type: "integer", nullable: false),
                    youtube_trailer = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_series", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "voiceover",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_voiceover", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "film_comment",
                columns: table => new
                {
                    film_id = table.Column<int>(type: "integer", nullable: false),
                    comment_id = table.Column<int>(type: "integer", nullable: false),
                    CommentsId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_film_comment", x => new { x.film_id, x.comment_id });
                    table.ForeignKey(
                        name: "FK_film_comment_comments_CommentsId",
                        column: x => x.CommentsId,
                        principalTable: "comments",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_film_comment_films_film_id",
                        column: x => x.film_id,
                        principalTable: "films",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "film_country",
                columns: table => new
                {
                    film_id = table.Column<int>(type: "integer", nullable: false),
                    country_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_film_country", x => new { x.film_id, x.country_id });
                    table.ForeignKey(
                        name: "FK_film_country_countries_country_id",
                        column: x => x.country_id,
                        principalTable: "countries",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_film_country_films_film_id",
                        column: x => x.film_id,
                        principalTable: "films",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "film_genre",
                columns: table => new
                {
                    film_id = table.Column<int>(type: "integer", nullable: false),
                    genre_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_film_genre", x => new { x.film_id, x.genre_id });
                    table.ForeignKey(
                        name: "FK_film_genre_films_film_id",
                        column: x => x.film_id,
                        principalTable: "films",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_film_genre_genres_genre_id",
                        column: x => x.genre_id,
                        principalTable: "genres",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "character",
                columns: table => new
                {
                    film_id = table.Column<int>(type: "integer", nullable: false),
                    actors_id = table.Column<int>(type: "integer", nullable: false)
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
                    table.PrimaryKey("PK_directors_films", x => new { x.director_id, x.film_id });
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
                name: "character_series",
                columns: table => new
                {
                    series_id = table.Column<int>(type: "integer", nullable: false),
                    actors_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_character_series", x => new { x.series_id, x.actors_id });
                    table.ForeignKey(
                        name: "FK_character_series_person_actors_id",
                        column: x => x.actors_id,
                        principalTable: "person",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_character_series_series_series_id",
                        column: x => x.series_id,
                        principalTable: "series",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "director_series",
                columns: table => new
                {
                    series_id = table.Column<int>(type: "integer", nullable: false),
                    director_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_director_series", x => new { x.director_id, x.series_id });
                    table.ForeignKey(
                        name: "FK_director_series_person_director_id",
                        column: x => x.director_id,
                        principalTable: "person",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_director_series_series_series_id",
                        column: x => x.series_id,
                        principalTable: "series",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "series_comment",
                columns: table => new
                {
                    film_id = table.Column<int>(type: "integer", nullable: false),
                    comment_id = table.Column<int>(type: "integer", nullable: false),
                    CommentsId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_series_comment", x => new { x.comment_id, x.film_id });
                    table.ForeignKey(
                        name: "FK_series_comment_comments_CommentsId",
                        column: x => x.CommentsId,
                        principalTable: "comments",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_series_comment_series_film_id",
                        column: x => x.film_id,
                        principalTable: "series",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "series_countries",
                columns: table => new
                {
                    series_id = table.Column<int>(type: "integer", nullable: false),
                    country_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_series_countries", x => new { x.series_id, x.country_id });
                    table.ForeignKey(
                        name: "FK_series_countries_countries_country_id",
                        column: x => x.country_id,
                        principalTable: "countries",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_series_countries_series_series_id",
                        column: x => x.series_id,
                        principalTable: "series",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "series_genres",
                columns: table => new
                {
                    series_id = table.Column<int>(type: "integer", nullable: false),
                    genres_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_series_genres", x => new { x.series_id, x.genres_id });
                    table.ForeignKey(
                        name: "FK_series_genres_genres_genres_id",
                        column: x => x.genres_id,
                        principalTable: "genres",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_series_genres_series_series_id",
                        column: x => x.series_id,
                        principalTable: "series",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "writer_series",
                columns: table => new
                {
                    series_id = table.Column<int>(type: "integer", nullable: false),
                    writer_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_writer_series", x => new { x.series_id, x.writer_id });
                    table.ForeignKey(
                        name: "FK_writer_series_person_writer_id",
                        column: x => x.writer_id,
                        principalTable: "person",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_writer_series_series_series_id",
                        column: x => x.series_id,
                        principalTable: "series",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "film_voiceover",
                columns: table => new
                {
                    film_id = table.Column<int>(type: "integer", nullable: false),
                    voiceover_id = table.Column<int>(type: "integer", nullable: false),
                    Link = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_film_voiceover", x => new { x.film_id, x.voiceover_id });
                    table.ForeignKey(
                        name: "FK_film_voiceover_films_film_id",
                        column: x => x.film_id,
                        principalTable: "films",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_film_voiceover_voiceover_voiceover_id",
                        column: x => x.voiceover_id,
                        principalTable: "voiceover",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "series_voiceover",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    series_id = table.Column<int>(type: "integer", nullable: false),
                    voiceover_id = table.Column<int>(type: "integer", nullable: false),
                    count_season = table.Column<int>(type: "integer", nullable: false),
                    count_episodes = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_series_voiceover", x => x.id);
                    table.ForeignKey(
                        name: "FK_series_voiceover_series_series_id",
                        column: x => x.series_id,
                        principalTable: "series",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_series_voiceover_voiceover_voiceover_id",
                        column: x => x.voiceover_id,
                        principalTable: "voiceover",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "season",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    voiceover_id = table.Column<int>(type: "integer", nullable: false),
                    number_season = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_season", x => x.id);
                    table.ForeignKey(
                        name: "FK_season_series_voiceover_voiceover_id",
                        column: x => x.voiceover_id,
                        principalTable: "series_voiceover",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "episodes",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    number_episode = table.Column<short>(type: "smallint", nullable: false),
                    link = table.Column<string>(type: "text", nullable: false),
                    image = table.Column<string>(type: "text", nullable: false),
                    season_id = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_episodes", x => x.id);
                    table.ForeignKey(
                        name: "FK_episodes_season_season_id",
                        column: x => x.season_id,
                        principalTable: "season",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_character_actors_id",
                table: "character",
                column: "actors_id");

            migrationBuilder.CreateIndex(
                name: "IX_character_series_actors_id",
                table: "character_series",
                column: "actors_id");

            migrationBuilder.CreateIndex(
                name: "IX_director_series_series_id",
                table: "director_series",
                column: "series_id");

            migrationBuilder.CreateIndex(
                name: "IX_directors_films_film_id",
                table: "directors_films",
                column: "film_id");

            migrationBuilder.CreateIndex(
                name: "IX_episodes_season_id",
                table: "episodes",
                column: "season_id");

            migrationBuilder.CreateIndex(
                name: "IX_film_comment_CommentsId",
                table: "film_comment",
                column: "CommentsId");

            migrationBuilder.CreateIndex(
                name: "IX_film_country_country_id",
                table: "film_country",
                column: "country_id");

            migrationBuilder.CreateIndex(
                name: "IX_film_genre_genre_id",
                table: "film_genre",
                column: "genre_id");

            migrationBuilder.CreateIndex(
                name: "IX_film_voiceover_voiceover_id",
                table: "film_voiceover",
                column: "voiceover_id");

            migrationBuilder.CreateIndex(
                name: "IX_season_voiceover_id",
                table: "season",
                column: "voiceover_id");

            migrationBuilder.CreateIndex(
                name: "IX_series_comment_CommentsId",
                table: "series_comment",
                column: "CommentsId");

            migrationBuilder.CreateIndex(
                name: "IX_series_comment_film_id",
                table: "series_comment",
                column: "film_id");

            migrationBuilder.CreateIndex(
                name: "IX_series_countries_country_id",
                table: "series_countries",
                column: "country_id");

            migrationBuilder.CreateIndex(
                name: "IX_series_genres_genres_id",
                table: "series_genres",
                column: "genres_id");

            migrationBuilder.CreateIndex(
                name: "IX_series_voiceover_series_id",
                table: "series_voiceover",
                column: "series_id");

            migrationBuilder.CreateIndex(
                name: "IX_series_voiceover_voiceover_id",
                table: "series_voiceover",
                column: "voiceover_id");

            migrationBuilder.CreateIndex(
                name: "IX_writer_series_writer_id",
                table: "writer_series",
                column: "writer_id");

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
                name: "character_series");

            migrationBuilder.DropTable(
                name: "director_series");

            migrationBuilder.DropTable(
                name: "directors_films");

            migrationBuilder.DropTable(
                name: "episodes");

            migrationBuilder.DropTable(
                name: "film_comment");

            migrationBuilder.DropTable(
                name: "film_country");

            migrationBuilder.DropTable(
                name: "film_genre");

            migrationBuilder.DropTable(
                name: "film_voiceover");

            migrationBuilder.DropTable(
                name: "series_comment");

            migrationBuilder.DropTable(
                name: "series_countries");

            migrationBuilder.DropTable(
                name: "series_genres");

            migrationBuilder.DropTable(
                name: "writer_series");

            migrationBuilder.DropTable(
                name: "writers_films");

            migrationBuilder.DropTable(
                name: "season");

            migrationBuilder.DropTable(
                name: "comments");

            migrationBuilder.DropTable(
                name: "countries");

            migrationBuilder.DropTable(
                name: "genres");

            migrationBuilder.DropTable(
                name: "films");

            migrationBuilder.DropTable(
                name: "person");

            migrationBuilder.DropTable(
                name: "series_voiceover");

            migrationBuilder.DropTable(
                name: "series");

            migrationBuilder.DropTable(
                name: "voiceover");
        }
    }
}
