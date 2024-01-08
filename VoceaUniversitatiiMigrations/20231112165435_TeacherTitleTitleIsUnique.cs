#nullable disable

using Microsoft.EntityFrameworkCore.Migrations;

namespace VoceaUniversitatiiMigrations
{
    /// <inheritdoc />
    public partial class TeacherTitleTitleIsUnique : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "TeacherTitles",
                type: "text",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.CreateIndex(
                name: "IX_TeacherTitles_Title",
                table: "TeacherTitles",
                column: "Title",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_TeacherTitles_Title",
                table: "TeacherTitles");

            migrationBuilder.AlterColumn<long>(
                name: "Title",
                table: "TeacherTitles",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);
        }
    }
}
