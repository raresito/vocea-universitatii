using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace vocea_universitatii.Migrations
{
    /// <inheritdoc />
    public partial class AddedStudentCohortDataSeeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Cohorts",
                columns: new[] { "Id", "CohortName" },
                values: new object[,]
                {
                    { 1L, "Subgrupa" },
                    { 2L, "Grupa" },
                    { 3L, "Serie" },
                    { 4L, "An" }
                });

            migrationBuilder.InsertData(
                table: "StudyYears",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1L, "Anul I - Licență" },
                    { 2L, "Anul II - Licență" },
                    { 3L, "Anul III - Licență" },
                    { 4L, "Anul IV - Licență" },
                    { 5L, "Anul I - Master" },
                    { 6L, "Anul II - Master" },
                    { 7L, "Doctorat" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Cohorts",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Cohorts",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "Cohorts",
                keyColumn: "Id",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "Cohorts",
                keyColumn: "Id",
                keyValue: 4L);

            migrationBuilder.DeleteData(
                table: "StudyYears",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "StudyYears",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "StudyYears",
                keyColumn: "Id",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "StudyYears",
                keyColumn: "Id",
                keyValue: 4L);

            migrationBuilder.DeleteData(
                table: "StudyYears",
                keyColumn: "Id",
                keyValue: 5L);

            migrationBuilder.DeleteData(
                table: "StudyYears",
                keyColumn: "Id",
                keyValue: 6L);

            migrationBuilder.DeleteData(
                table: "StudyYears",
                keyColumn: "Id",
                keyValue: 7L);
        }
    }
}
