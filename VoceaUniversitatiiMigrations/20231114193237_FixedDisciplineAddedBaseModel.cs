#nullable disable

using Microsoft.EntityFrameworkCore.Migrations;

namespace VoceaUniversitatiiMigrations
{
    /// <inheritdoc />
    public partial class FixedDisciplineAddedBaseModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Disciplines",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "CreatedByid",
                table: "Disciplines",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                table: "Disciplines",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "DeletedByid",
                table: "Disciplines",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "Disciplines",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "UpdatedByid",
                table: "Disciplines",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Disciplines_CreatedByid",
                table: "Disciplines",
                column: "CreatedByid");

            migrationBuilder.CreateIndex(
                name: "IX_Disciplines_DeletedByid",
                table: "Disciplines",
                column: "DeletedByid");

            migrationBuilder.CreateIndex(
                name: "IX_Disciplines_UpdatedByid",
                table: "Disciplines",
                column: "UpdatedByid");

            migrationBuilder.AddForeignKey(
                name: "FK_Disciplines_User_CreatedByid",
                table: "Disciplines",
                column: "CreatedByid",
                principalTable: "User",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_Disciplines_User_DeletedByid",
                table: "Disciplines",
                column: "DeletedByid",
                principalTable: "User",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_Disciplines_User_UpdatedByid",
                table: "Disciplines",
                column: "UpdatedByid",
                principalTable: "User",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Disciplines_User_CreatedByid",
                table: "Disciplines");

            migrationBuilder.DropForeignKey(
                name: "FK_Disciplines_User_DeletedByid",
                table: "Disciplines");

            migrationBuilder.DropForeignKey(
                name: "FK_Disciplines_User_UpdatedByid",
                table: "Disciplines");

            migrationBuilder.DropIndex(
                name: "IX_Disciplines_CreatedByid",
                table: "Disciplines");

            migrationBuilder.DropIndex(
                name: "IX_Disciplines_DeletedByid",
                table: "Disciplines");

            migrationBuilder.DropIndex(
                name: "IX_Disciplines_UpdatedByid",
                table: "Disciplines");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Disciplines");

            migrationBuilder.DropColumn(
                name: "CreatedByid",
                table: "Disciplines");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "Disciplines");

            migrationBuilder.DropColumn(
                name: "DeletedByid",
                table: "Disciplines");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "Disciplines");

            migrationBuilder.DropColumn(
                name: "UpdatedByid",
                table: "Disciplines");
        }
    }
}
