using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace vocea_universitatii.Migrations
{
    /// <inheritdoc />
    public partial class ImplementedBaseModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "User",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                table: "User",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "User",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Departments",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "CreatedByid",
                table: "Departments",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                table: "Departments",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "DeletedByid",
                table: "Departments",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "Departments",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "UpdatedByid",
                table: "Departments",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Departments_CreatedByid",
                table: "Departments",
                column: "CreatedByid");

            migrationBuilder.CreateIndex(
                name: "IX_Departments_DeletedByid",
                table: "Departments",
                column: "DeletedByid");

            migrationBuilder.CreateIndex(
                name: "IX_Departments_UpdatedByid",
                table: "Departments",
                column: "UpdatedByid");

            migrationBuilder.AddForeignKey(
                name: "FK_Departments_User_CreatedByid",
                table: "Departments",
                column: "CreatedByid",
                principalTable: "User",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_Departments_User_DeletedByid",
                table: "Departments",
                column: "DeletedByid",
                principalTable: "User",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_Departments_User_UpdatedByid",
                table: "Departments",
                column: "UpdatedByid",
                principalTable: "User",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Departments_User_CreatedByid",
                table: "Departments");

            migrationBuilder.DropForeignKey(
                name: "FK_Departments_User_DeletedByid",
                table: "Departments");

            migrationBuilder.DropForeignKey(
                name: "FK_Departments_User_UpdatedByid",
                table: "Departments");

            migrationBuilder.DropIndex(
                name: "IX_Departments_CreatedByid",
                table: "Departments");

            migrationBuilder.DropIndex(
                name: "IX_Departments_DeletedByid",
                table: "Departments");

            migrationBuilder.DropIndex(
                name: "IX_Departments_UpdatedByid",
                table: "Departments");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "User");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "User");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "User");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Departments");

            migrationBuilder.DropColumn(
                name: "CreatedByid",
                table: "Departments");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "Departments");

            migrationBuilder.DropColumn(
                name: "DeletedByid",
                table: "Departments");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "Departments");

            migrationBuilder.DropColumn(
                name: "UpdatedByid",
                table: "Departments");
        }
    }
}
