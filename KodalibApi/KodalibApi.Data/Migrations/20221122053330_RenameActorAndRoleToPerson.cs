using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace KodalibApi.Data.Migrations
{
    public partial class RenameActorAndRoleToPerson : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "roles",
                table: "actors");

            migrationBuilder.RenameColumn(
                name: "actors_imdb_id",
                table: "actors",
                newName: "person_imdb_id");

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
                        name: "FK_role_person_actors_person_id",
                        column: x => x.person_id,
                        principalTable: "actors",
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
                name: "IX_role_person_role_id",
                table: "role_person",
                column: "role_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "role_person");

            migrationBuilder.DropTable(
                name: "role");

            migrationBuilder.RenameColumn(
                name: "person_imdb_id",
                table: "actors",
                newName: "actors_imdb_id");

            migrationBuilder.AddColumn<string>(
                name: "roles",
                table: "actors",
                type: "text",
                nullable: true);
        }
    }
}
