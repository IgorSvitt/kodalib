using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace KodalibApi.Data.Migrations
{
    public partial class AddSeries : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "series",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    kinopoisk_id = table.Column<string>(type: "text", nullable: true),
                    title = table.Column<string>(type: "text", nullable: false),
                    org_title = table.Column<string>(type: "text", nullable: true),
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
                    table.PrimaryKey("PK_series", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "character_series",
                columns: table => new
                {
                    series_id = table.Column<int>(type: "integer", nullable: false),
                    actors_id = table.Column<int>(type: "integer", nullable: false),
                    role = table.Column<string>(type: "text", nullable: true)
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
                    table.PrimaryKey("PK_director_series", x => new { x.series_id, x.director_id });
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
                name: "season",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    number_season = table.Column<short>(type: "smallint", nullable: false),
                    series_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_season", x => x.id);
                    table.ForeignKey(
                        name: "FK_season_series_series_id",
                        column: x => x.series_id,
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
                name: "episodes",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    number_episode = table.Column<short>(type: "smallint", nullable: false),
                    link = table.Column<string>(type: "text", nullable: false),
                    image = table.Column<string>(type: "text", nullable: false),
                    season_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_episodes", x => x.id);
                    table.ForeignKey(
                        name: "FK_episodes_season_season_id",
                        column: x => x.season_id,
                        principalTable: "season",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_character_series_actors_id",
                table: "character_series",
                column: "actors_id");

            migrationBuilder.CreateIndex(
                name: "IX_director_series_director_id",
                table: "director_series",
                column: "director_id");

            migrationBuilder.CreateIndex(
                name: "IX_episodes_season_id",
                table: "episodes",
                column: "season_id");

            migrationBuilder.CreateIndex(
                name: "IX_season_series_id",
                table: "season",
                column: "series_id");

            migrationBuilder.CreateIndex(
                name: "IX_series_countries_country_id",
                table: "series_countries",
                column: "country_id");

            migrationBuilder.CreateIndex(
                name: "IX_series_genres_genres_id",
                table: "series_genres",
                column: "genres_id");

            migrationBuilder.CreateIndex(
                name: "IX_writer_series_writer_id",
                table: "writer_series",
                column: "writer_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "character_series");

            migrationBuilder.DropTable(
                name: "director_series");

            migrationBuilder.DropTable(
                name: "episodes");

            migrationBuilder.DropTable(
                name: "series_countries");

            migrationBuilder.DropTable(
                name: "series_genres");

            migrationBuilder.DropTable(
                name: "writer_series");

            migrationBuilder.DropTable(
                name: "season");

            migrationBuilder.DropTable(
                name: "series");
        }
    }
}
