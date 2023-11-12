using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace vocea_universitatii.Migrations
{
    /// <inheritdoc />
    public partial class CreatedTeacherTitleEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "TeacherTitleId",
                table: "Teachers",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "TeacherTitles",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Title = table.Column<long>(type: "bigint", nullable: false),
                    CreatedByid = table.Column<int>(type: "integer", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedByid = table.Column<int>(type: "integer", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DeletedByid = table.Column<int>(type: "integer", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeacherTitles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TeacherTitles_User_CreatedByid",
                        column: x => x.CreatedByid,
                        principalTable: "User",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_TeacherTitles_User_DeletedByid",
                        column: x => x.DeletedByid,
                        principalTable: "User",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_TeacherTitles_User_UpdatedByid",
                        column: x => x.UpdatedByid,
                        principalTable: "User",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Teachers_TeacherTitleId",
                table: "Teachers",
                column: "TeacherTitleId");

            migrationBuilder.CreateIndex(
                name: "IX_TeacherTitles_CreatedByid",
                table: "TeacherTitles",
                column: "CreatedByid");

            migrationBuilder.CreateIndex(
                name: "IX_TeacherTitles_DeletedByid",
                table: "TeacherTitles",
                column: "DeletedByid");

            migrationBuilder.CreateIndex(
                name: "IX_TeacherTitles_UpdatedByid",
                table: "TeacherTitles",
                column: "UpdatedByid");

            migrationBuilder.AddForeignKey(
                name: "FK_Teachers_TeacherTitles_TeacherTitleId",
                table: "Teachers",
                column: "TeacherTitleId",
                principalTable: "TeacherTitles",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Teachers_TeacherTitles_TeacherTitleId",
                table: "Teachers");

            migrationBuilder.DropTable(
                name: "TeacherTitles");

            migrationBuilder.DropIndex(
                name: "IX_Teachers_TeacherTitleId",
                table: "Teachers");

            migrationBuilder.DropColumn(
                name: "TeacherTitleId",
                table: "Teachers");
        }
    }
}
