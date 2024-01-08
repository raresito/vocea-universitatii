#nullable disable

using Microsoft.EntityFrameworkCore.Migrations;

namespace VoceaUniversitatiiMigrations
{
    /// <inheritdoc />
    public partial class TeachersFix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudyProgram_Faculties_FacultyId",
                table: "StudyProgram");

            migrationBuilder.DropForeignKey(
                name: "FK_StudyProgram_User_CreatedByid",
                table: "StudyProgram");

            migrationBuilder.DropForeignKey(
                name: "FK_StudyProgram_User_DeletedByid",
                table: "StudyProgram");

            migrationBuilder.DropForeignKey(
                name: "FK_StudyProgram_User_UpdatedByid",
                table: "StudyProgram");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StudyProgram",
                table: "StudyProgram");

            migrationBuilder.RenameTable(
                name: "StudyProgram",
                newName: "StudyPrograms");

            migrationBuilder.RenameIndex(
                name: "IX_StudyProgram_UpdatedByid",
                table: "StudyPrograms",
                newName: "IX_StudyPrograms_UpdatedByid");

            migrationBuilder.RenameIndex(
                name: "IX_StudyProgram_FacultyId",
                table: "StudyPrograms",
                newName: "IX_StudyPrograms_FacultyId");

            migrationBuilder.RenameIndex(
                name: "IX_StudyProgram_DeletedByid",
                table: "StudyPrograms",
                newName: "IX_StudyPrograms_DeletedByid");

            migrationBuilder.RenameIndex(
                name: "IX_StudyProgram_CreatedByid",
                table: "StudyPrograms",
                newName: "IX_StudyPrograms_CreatedByid");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StudyPrograms",
                table: "StudyPrograms",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_StudyPrograms_Faculties_FacultyId",
                table: "StudyPrograms",
                column: "FacultyId",
                principalTable: "Faculties",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StudyPrograms_User_CreatedByid",
                table: "StudyPrograms",
                column: "CreatedByid",
                principalTable: "User",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_StudyPrograms_User_DeletedByid",
                table: "StudyPrograms",
                column: "DeletedByid",
                principalTable: "User",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_StudyPrograms_User_UpdatedByid",
                table: "StudyPrograms",
                column: "UpdatedByid",
                principalTable: "User",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudyPrograms_Faculties_FacultyId",
                table: "StudyPrograms");

            migrationBuilder.DropForeignKey(
                name: "FK_StudyPrograms_User_CreatedByid",
                table: "StudyPrograms");

            migrationBuilder.DropForeignKey(
                name: "FK_StudyPrograms_User_DeletedByid",
                table: "StudyPrograms");

            migrationBuilder.DropForeignKey(
                name: "FK_StudyPrograms_User_UpdatedByid",
                table: "StudyPrograms");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StudyPrograms",
                table: "StudyPrograms");

            migrationBuilder.RenameTable(
                name: "StudyPrograms",
                newName: "StudyProgram");

            migrationBuilder.RenameIndex(
                name: "IX_StudyPrograms_UpdatedByid",
                table: "StudyProgram",
                newName: "IX_StudyProgram_UpdatedByid");

            migrationBuilder.RenameIndex(
                name: "IX_StudyPrograms_FacultyId",
                table: "StudyProgram",
                newName: "IX_StudyProgram_FacultyId");

            migrationBuilder.RenameIndex(
                name: "IX_StudyPrograms_DeletedByid",
                table: "StudyProgram",
                newName: "IX_StudyProgram_DeletedByid");

            migrationBuilder.RenameIndex(
                name: "IX_StudyPrograms_CreatedByid",
                table: "StudyProgram",
                newName: "IX_StudyProgram_CreatedByid");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StudyProgram",
                table: "StudyProgram",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_StudyProgram_Faculties_FacultyId",
                table: "StudyProgram",
                column: "FacultyId",
                principalTable: "Faculties",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StudyProgram_User_CreatedByid",
                table: "StudyProgram",
                column: "CreatedByid",
                principalTable: "User",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_StudyProgram_User_DeletedByid",
                table: "StudyProgram",
                column: "DeletedByid",
                principalTable: "User",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_StudyProgram_User_UpdatedByid",
                table: "StudyProgram",
                column: "UpdatedByid",
                principalTable: "User",
                principalColumn: "id");
        }
    }
}
