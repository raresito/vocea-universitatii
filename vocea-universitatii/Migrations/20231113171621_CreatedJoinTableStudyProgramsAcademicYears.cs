using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace vocea_universitatii.Migrations
{
    /// <inheritdoc />
    public partial class CreatedJoinTableStudyProgramsAcademicYears : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "StudyProgramAcademicYearEnrollments",
                columns: table => new
                {
                    AcademicYearId = table.Column<long>(type: "bigint", nullable: false),
                    StudyProgramId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudyProgramAcademicYearEnrollments", x => new { x.StudyProgramId, x.AcademicYearId });
                    table.ForeignKey(
                        name: "FK_StudyProgramAcademicYearEnrollments_AcademicYears_AcademicY~",
                        column: x => x.AcademicYearId,
                        principalTable: "AcademicYears",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudyProgramAcademicYearEnrollments_StudyPrograms_StudyProg~",
                        column: x => x.StudyProgramId,
                        principalTable: "StudyPrograms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_StudyProgramAcademicYearEnrollments_AcademicYearId",
                table: "StudyProgramAcademicYearEnrollments",
                column: "AcademicYearId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StudyProgramAcademicYearEnrollments");
        }
    }
}
