using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace vocea_universitatii.Migrations
{
    /// <inheritdoc />
    public partial class MadeSomePropertiesRequiredAndUnique : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CNP",
                table: "Teachers");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "TeacherTitles",
                type: "text",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ActivityTypes_Name",
                table: "ActivityTypes",
                column: "Name",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ActivityTypes_Name",
                table: "ActivityTypes");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "TeacherTitles",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddColumn<long>(
                name: "CNP",
                table: "Teachers",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);
        }
    }
}
