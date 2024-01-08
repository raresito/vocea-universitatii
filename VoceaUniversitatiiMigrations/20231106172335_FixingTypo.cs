#nullable disable

using Microsoft.EntityFrameworkCore.Migrations;

namespace VoceaUniversitatiiMigrations
{
    /// <inheritdoc />
    public partial class FixingTypo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DepartmentTeacher_Teacher_Teachersid",
                table: "DepartmentTeacher");

            migrationBuilder.DropForeignKey(
                name: "FK_Teacher_User_CreatedByid",
                table: "Teacher");

            migrationBuilder.DropForeignKey(
                name: "FK_Teacher_User_DeletedByid",
                table: "Teacher");

            migrationBuilder.DropForeignKey(
                name: "FK_Teacher_User_UpdatedByid",
                table: "Teacher");

            migrationBuilder.DropForeignKey(
                name: "FK_TeacherDepartmentMembership_Teacher_TeacherId",
                table: "TeacherDepartmentMembership");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Teacher",
                table: "Teacher");

            migrationBuilder.RenameTable(
                name: "Teacher",
                newName: "Teachers");

            migrationBuilder.RenameColumn(
                name: "Teachersid",
                table: "DepartmentTeacher",
                newName: "TeachersId");

            migrationBuilder.RenameIndex(
                name: "IX_DepartmentTeacher_Teachersid",
                table: "DepartmentTeacher",
                newName: "IX_DepartmentTeacher_TeachersId");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Teachers",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_Teacher_UpdatedByid",
                table: "Teachers",
                newName: "IX_Teachers_UpdatedByid");

            migrationBuilder.RenameIndex(
                name: "IX_Teacher_DeletedByid",
                table: "Teachers",
                newName: "IX_Teachers_DeletedByid");

            migrationBuilder.RenameIndex(
                name: "IX_Teacher_CreatedByid",
                table: "Teachers",
                newName: "IX_Teachers_CreatedByid");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Teachers",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "Teachers",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "Teachers",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Teachers",
                table: "Teachers",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_DepartmentTeacher_Teachers_TeachersId",
                table: "DepartmentTeacher",
                column: "TeachersId",
                principalTable: "Teachers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TeacherDepartmentMembership_Teachers_TeacherId",
                table: "TeacherDepartmentMembership",
                column: "TeacherId",
                principalTable: "Teachers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Teachers_User_CreatedByid",
                table: "Teachers",
                column: "CreatedByid",
                principalTable: "User",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_Teachers_User_DeletedByid",
                table: "Teachers",
                column: "DeletedByid",
                principalTable: "User",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_Teachers_User_UpdatedByid",
                table: "Teachers",
                column: "UpdatedByid",
                principalTable: "User",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DepartmentTeacher_Teachers_TeachersId",
                table: "DepartmentTeacher");

            migrationBuilder.DropForeignKey(
                name: "FK_TeacherDepartmentMembership_Teachers_TeacherId",
                table: "TeacherDepartmentMembership");

            migrationBuilder.DropForeignKey(
                name: "FK_Teachers_User_CreatedByid",
                table: "Teachers");

            migrationBuilder.DropForeignKey(
                name: "FK_Teachers_User_DeletedByid",
                table: "Teachers");

            migrationBuilder.DropForeignKey(
                name: "FK_Teachers_User_UpdatedByid",
                table: "Teachers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Teachers",
                table: "Teachers");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Teachers");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "Teachers");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "Teachers");

            migrationBuilder.RenameTable(
                name: "Teachers",
                newName: "Teacher");

            migrationBuilder.RenameColumn(
                name: "TeachersId",
                table: "DepartmentTeacher",
                newName: "Teachersid");

            migrationBuilder.RenameIndex(
                name: "IX_DepartmentTeacher_TeachersId",
                table: "DepartmentTeacher",
                newName: "IX_DepartmentTeacher_Teachersid");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Teacher",
                newName: "id");

            migrationBuilder.RenameIndex(
                name: "IX_Teachers_UpdatedByid",
                table: "Teacher",
                newName: "IX_Teacher_UpdatedByid");

            migrationBuilder.RenameIndex(
                name: "IX_Teachers_DeletedByid",
                table: "Teacher",
                newName: "IX_Teacher_DeletedByid");

            migrationBuilder.RenameIndex(
                name: "IX_Teachers_CreatedByid",
                table: "Teacher",
                newName: "IX_Teacher_CreatedByid");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Teacher",
                table: "Teacher",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_DepartmentTeacher_Teacher_Teachersid",
                table: "DepartmentTeacher",
                column: "Teachersid",
                principalTable: "Teacher",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Teacher_User_CreatedByid",
                table: "Teacher",
                column: "CreatedByid",
                principalTable: "User",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_Teacher_User_DeletedByid",
                table: "Teacher",
                column: "DeletedByid",
                principalTable: "User",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_Teacher_User_UpdatedByid",
                table: "Teacher",
                column: "UpdatedByid",
                principalTable: "User",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_TeacherDepartmentMembership_Teacher_TeacherId",
                table: "TeacherDepartmentMembership",
                column: "TeacherId",
                principalTable: "Teacher",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
