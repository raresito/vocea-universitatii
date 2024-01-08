#nullable disable

using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace VoceaUniversitatiiMigrations
{
    /// <inheritdoc />
    public partial class FixLanguages : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Language",
                table: "StudyPrograms");

            migrationBuilder.AddColumn<long>(
                name: "LanguageId",
                table: "StudyPrograms",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateTable(
                name: "Language",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    LanguageName = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Language", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_StudyPrograms_LanguageId",
                table: "StudyPrograms",
                column: "LanguageId");

            migrationBuilder.AddForeignKey(
                name: "FK_StudyPrograms_Language_LanguageId",
                table: "StudyPrograms",
                column: "LanguageId",
                principalTable: "Language",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudyPrograms_Language_LanguageId",
                table: "StudyPrograms");

            migrationBuilder.DropTable(
                name: "Language");

            migrationBuilder.DropIndex(
                name: "IX_StudyPrograms_LanguageId",
                table: "StudyPrograms");

            migrationBuilder.DropColumn(
                name: "LanguageId",
                table: "StudyPrograms");

            migrationBuilder.AddColumn<int>(
                name: "Language",
                table: "StudyPrograms",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }
    }
}
