using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace vocea_universitatii.Migrations
{
    /// <inheritdoc />
    public partial class AddedActivityStudentCohort : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ActivityStudentCohorts",
                columns: table => new
                {
                    ActivityId = table.Column<long>(type: "bigint", nullable: false),
                    StudentCohortId = table.Column<long>(type: "bigint", nullable: false),
                    ActivityDisciplineId = table.Column<long>(type: "bigint", nullable: false),
                    ActivityTypeId = table.Column<long>(type: "bigint", nullable: false),
                    ActivityTeacherId = table.Column<long>(type: "bigint", nullable: false),
                    CreatedByid = table.Column<int>(type: "integer", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedByid = table.Column<int>(type: "integer", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DeletedByid = table.Column<int>(type: "integer", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActivityStudentCohorts", x => new { x.ActivityId, x.StudentCohortId });
                    table.ForeignKey(
                        name: "FK_ActivityStudentCohorts_Activities_ActivityDisciplineId_Acti~",
                        columns: x => new { x.ActivityDisciplineId, x.ActivityTypeId, x.ActivityTeacherId },
                        principalTable: "Activities",
                        principalColumns: new[] { "DisciplineId", "ActivityTypeId", "TeacherId" },
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ActivityStudentCohorts_StudentCohorts_StudentCohortId",
                        column: x => x.StudentCohortId,
                        principalTable: "StudentCohorts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ActivityStudentCohorts_User_CreatedByid",
                        column: x => x.CreatedByid,
                        principalTable: "User",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_ActivityStudentCohorts_User_DeletedByid",
                        column: x => x.DeletedByid,
                        principalTable: "User",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_ActivityStudentCohorts_User_UpdatedByid",
                        column: x => x.UpdatedByid,
                        principalTable: "User",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ActivityStudentCohorts_ActivityDisciplineId_ActivityTypeId_~",
                table: "ActivityStudentCohorts",
                columns: new[] { "ActivityDisciplineId", "ActivityTypeId", "ActivityTeacherId" });

            migrationBuilder.CreateIndex(
                name: "IX_ActivityStudentCohorts_CreatedByid",
                table: "ActivityStudentCohorts",
                column: "CreatedByid");

            migrationBuilder.CreateIndex(
                name: "IX_ActivityStudentCohorts_DeletedByid",
                table: "ActivityStudentCohorts",
                column: "DeletedByid");

            migrationBuilder.CreateIndex(
                name: "IX_ActivityStudentCohorts_StudentCohortId",
                table: "ActivityStudentCohorts",
                column: "StudentCohortId");

            migrationBuilder.CreateIndex(
                name: "IX_ActivityStudentCohorts_UpdatedByid",
                table: "ActivityStudentCohorts",
                column: "UpdatedByid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ActivityStudentCohorts");
        }
    }
}
