using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace vocea_universitatii.Migrations
{
    /// <inheritdoc />
    public partial class AddedStudentCohortTableAndCohortsAndStudyYearTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cohorts",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CohortName = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cohorts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StudyYears",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudyYears", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "StudentCohorts",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    AcademicYearId = table.Column<long>(type: "bigint", nullable: false),
                    StudyProgramId = table.Column<long>(type: "bigint", nullable: false),
                    StudyYearId = table.Column<long>(type: "bigint", nullable: false),
                    Size = table.Column<int>(type: "integer", nullable: false),
                    CohortTypeId = table.Column<long>(type: "bigint", nullable: false),
                    ParentStudentCohortId = table.Column<long>(type: "bigint", nullable: false),
                    CreatedByid = table.Column<int>(type: "integer", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedByid = table.Column<int>(type: "integer", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DeletedByid = table.Column<int>(type: "integer", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentCohorts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StudentCohorts_AcademicYears_AcademicYearId",
                        column: x => x.AcademicYearId,
                        principalTable: "AcademicYears",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentCohorts_Cohorts_CohortTypeId",
                        column: x => x.CohortTypeId,
                        principalTable: "Cohorts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentCohorts_StudentCohorts_ParentStudentCohortId",
                        column: x => x.ParentStudentCohortId,
                        principalTable: "StudentCohorts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentCohorts_StudyPrograms_StudyProgramId",
                        column: x => x.StudyProgramId,
                        principalTable: "StudyPrograms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentCohorts_StudyYears_StudyYearId",
                        column: x => x.StudyYearId,
                        principalTable: "StudyYears",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentCohorts_User_CreatedByid",
                        column: x => x.CreatedByid,
                        principalTable: "User",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_StudentCohorts_User_DeletedByid",
                        column: x => x.DeletedByid,
                        principalTable: "User",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_StudentCohorts_User_UpdatedByid",
                        column: x => x.UpdatedByid,
                        principalTable: "User",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_StudentCohorts_AcademicYearId",
                table: "StudentCohorts",
                column: "AcademicYearId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentCohorts_CohortTypeId",
                table: "StudentCohorts",
                column: "CohortTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentCohorts_CreatedByid",
                table: "StudentCohorts",
                column: "CreatedByid");

            migrationBuilder.CreateIndex(
                name: "IX_StudentCohorts_DeletedByid",
                table: "StudentCohorts",
                column: "DeletedByid");

            migrationBuilder.CreateIndex(
                name: "IX_StudentCohorts_ParentStudentCohortId",
                table: "StudentCohorts",
                column: "ParentStudentCohortId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentCohorts_StudyProgramId",
                table: "StudentCohorts",
                column: "StudyProgramId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentCohorts_StudyYearId",
                table: "StudentCohorts",
                column: "StudyYearId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentCohorts_UpdatedByid",
                table: "StudentCohorts",
                column: "UpdatedByid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StudentCohorts");

            migrationBuilder.DropTable(
                name: "Cohorts");

            migrationBuilder.DropTable(
                name: "StudyYears");
        }
    }
}
