#nullable disable

using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace VoceaUniversitatiiMigrations
{
    /// <inheritdoc />
    public partial class CreatedDepartments : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Faculties",
                newName: "FullName");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Faculties",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "CreatedByid",
                table: "Faculties",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                table: "Faculties",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "DeletedByid",
                table: "Faculties",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "Faculties",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "UpdatedByid",
                table: "Faculties",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FullName = table.Column<string>(type: "text", nullable: false),
                    FacultyId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Departments_Faculties_FacultyId",
                        column: x => x.FacultyId,
                        principalTable: "Faculties",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FullName = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Faculties_CreatedByid",
                table: "Faculties",
                column: "CreatedByid");

            migrationBuilder.CreateIndex(
                name: "IX_Faculties_DeletedByid",
                table: "Faculties",
                column: "DeletedByid");

            migrationBuilder.CreateIndex(
                name: "IX_Faculties_UpdatedByid",
                table: "Faculties",
                column: "UpdatedByid");

            migrationBuilder.CreateIndex(
                name: "IX_Departments_FacultyId",
                table: "Departments",
                column: "FacultyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Faculties_User_CreatedByid",
                table: "Faculties",
                column: "CreatedByid",
                principalTable: "User",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_Faculties_User_DeletedByid",
                table: "Faculties",
                column: "DeletedByid",
                principalTable: "User",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_Faculties_User_UpdatedByid",
                table: "Faculties",
                column: "UpdatedByid",
                principalTable: "User",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Faculties_User_CreatedByid",
                table: "Faculties");

            migrationBuilder.DropForeignKey(
                name: "FK_Faculties_User_DeletedByid",
                table: "Faculties");

            migrationBuilder.DropForeignKey(
                name: "FK_Faculties_User_UpdatedByid",
                table: "Faculties");

            migrationBuilder.DropTable(
                name: "Departments");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropIndex(
                name: "IX_Faculties_CreatedByid",
                table: "Faculties");

            migrationBuilder.DropIndex(
                name: "IX_Faculties_DeletedByid",
                table: "Faculties");

            migrationBuilder.DropIndex(
                name: "IX_Faculties_UpdatedByid",
                table: "Faculties");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Faculties");

            migrationBuilder.DropColumn(
                name: "CreatedByid",
                table: "Faculties");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                table: "Faculties");

            migrationBuilder.DropColumn(
                name: "DeletedByid",
                table: "Faculties");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "Faculties");

            migrationBuilder.DropColumn(
                name: "UpdatedByid",
                table: "Faculties");

            migrationBuilder.RenameColumn(
                name: "FullName",
                table: "Faculties",
                newName: "Name");
        }
    }
}
