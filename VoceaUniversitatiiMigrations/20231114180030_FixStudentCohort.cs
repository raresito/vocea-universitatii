#nullable disable

using Microsoft.EntityFrameworkCore.Migrations;

namespace VoceaUniversitatiiMigrations
{
    /// <inheritdoc />
    public partial class FixStudentCohort : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudentCohorts_StudentCohorts_ParentStudentCohortId",
                table: "StudentCohorts");

            migrationBuilder.AlterColumn<long>(
                name: "ParentStudentCohortId",
                table: "StudentCohorts",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "StudentCohorts",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_StudentCohorts_StudentCohorts_ParentStudentCohortId",
                table: "StudentCohorts",
                column: "ParentStudentCohortId",
                principalTable: "StudentCohorts",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudentCohorts_StudentCohorts_ParentStudentCohortId",
                table: "StudentCohorts");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "StudentCohorts");

            migrationBuilder.AlterColumn<long>(
                name: "ParentStudentCohortId",
                table: "StudentCohorts",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentCohorts_StudentCohorts_ParentStudentCohortId",
                table: "StudentCohorts",
                column: "ParentStudentCohortId",
                principalTable: "StudentCohorts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
