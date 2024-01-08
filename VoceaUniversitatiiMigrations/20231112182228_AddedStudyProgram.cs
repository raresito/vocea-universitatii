#nullable disable

using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace VoceaUniversitatiiMigrations
{
    /// <inheritdoc />
    public partial class AddedStudyProgram : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AcademicYears_User_CreatedByid",
                table: "AcademicYears");

            migrationBuilder.DropForeignKey(
                name: "FK_AcademicYears_User_DeletedByid",
                table: "AcademicYears");

            migrationBuilder.DropForeignKey(
                name: "FK_AcademicYears_User_UpdatedByid",
                table: "AcademicYears");

            migrationBuilder.DropIndex(
                name: "IX_AcademicYears_CreatedByid",
                table: "AcademicYears");

            migrationBuilder.DropIndex(
                name: "IX_AcademicYears_DeletedByid",
                table: "AcademicYears");

            migrationBuilder.DropIndex(
                name: "IX_AcademicYears_UpdatedByid",
                table: "AcademicYears");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "AcademicYears");

            migrationBuilder.DropColumn(
                name: "CreatedByid",
                table: "AcademicYears");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "AcademicYears");

            migrationBuilder.DropColumn(
                name: "DeletedByid",
                table: "AcademicYears");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "AcademicYears");

            migrationBuilder.DropColumn(
                name: "UpdatedByid",
                table: "AcademicYears");

            migrationBuilder.CreateTable(
                name: "StudyProgram",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FullName = table.Column<string>(type: "text", nullable: false),
                    Language = table.Column<int>(type: "integer", nullable: false),
                    FacultyId = table.Column<long>(type: "bigint", nullable: false),
                    CreatedByid = table.Column<int>(type: "integer", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedByid = table.Column<int>(type: "integer", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DeletedByid = table.Column<int>(type: "integer", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudyProgram", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StudyProgram_Faculties_FacultyId",
                        column: x => x.FacultyId,
                        principalTable: "Faculties",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudyProgram_User_CreatedByid",
                        column: x => x.CreatedByid,
                        principalTable: "User",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_StudyProgram_User_DeletedByid",
                        column: x => x.DeletedByid,
                        principalTable: "User",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_StudyProgram_User_UpdatedByid",
                        column: x => x.UpdatedByid,
                        principalTable: "User",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_StudyProgram_CreatedByid",
                table: "StudyProgram",
                column: "CreatedByid");

            migrationBuilder.CreateIndex(
                name: "IX_StudyProgram_DeletedByid",
                table: "StudyProgram",
                column: "DeletedByid");

            migrationBuilder.CreateIndex(
                name: "IX_StudyProgram_FacultyId",
                table: "StudyProgram",
                column: "FacultyId");

            migrationBuilder.CreateIndex(
                name: "IX_StudyProgram_UpdatedByid",
                table: "StudyProgram",
                column: "UpdatedByid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StudyProgram");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "AcademicYears",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "CreatedByid",
                table: "AcademicYears",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                table: "AcademicYears",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "DeletedByid",
                table: "AcademicYears",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "AcademicYears",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "UpdatedByid",
                table: "AcademicYears",
                type: "integer",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AcademicYears",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "CreatedAt", "CreatedByid", "DeletedAt", "DeletedByid", "UpdatedAt", "UpdatedByid" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null });

            migrationBuilder.UpdateData(
                table: "AcademicYears",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "CreatedAt", "CreatedByid", "DeletedAt", "DeletedByid", "UpdatedAt", "UpdatedByid" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null });

            migrationBuilder.UpdateData(
                table: "AcademicYears",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "CreatedAt", "CreatedByid", "DeletedAt", "DeletedByid", "UpdatedAt", "UpdatedByid" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null });

            migrationBuilder.CreateIndex(
                name: "IX_AcademicYears_CreatedByid",
                table: "AcademicYears",
                column: "CreatedByid");

            migrationBuilder.CreateIndex(
                name: "IX_AcademicYears_DeletedByid",
                table: "AcademicYears",
                column: "DeletedByid");

            migrationBuilder.CreateIndex(
                name: "IX_AcademicYears_UpdatedByid",
                table: "AcademicYears",
                column: "UpdatedByid");

            migrationBuilder.AddForeignKey(
                name: "FK_AcademicYears_User_CreatedByid",
                table: "AcademicYears",
                column: "CreatedByid",
                principalTable: "User",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_AcademicYears_User_DeletedByid",
                table: "AcademicYears",
                column: "DeletedByid",
                principalTable: "User",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_AcademicYears_User_UpdatedByid",
                table: "AcademicYears",
                column: "UpdatedByid",
                principalTable: "User",
                principalColumn: "id");
        }
    }
}
