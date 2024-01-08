#nullable disable

using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace VoceaUniversitatiiMigrations
{
    /// <inheritdoc />
    public partial class AddedEvaluationMethod : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "EvaluationMethodId",
                table: "Disciplines",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<bool>(
                name: "Facultativ",
                table: "Disciplines",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "EvaluationMethods",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    CreatedByid = table.Column<int>(type: "integer", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedByid = table.Column<int>(type: "integer", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DeletedByid = table.Column<int>(type: "integer", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EvaluationMethods", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EvaluationMethods_User_CreatedByid",
                        column: x => x.CreatedByid,
                        principalTable: "User",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_EvaluationMethods_User_DeletedByid",
                        column: x => x.DeletedByid,
                        principalTable: "User",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_EvaluationMethods_User_UpdatedByid",
                        column: x => x.UpdatedByid,
                        principalTable: "User",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Disciplines_EvaluationMethodId",
                table: "Disciplines",
                column: "EvaluationMethodId");

            migrationBuilder.CreateIndex(
                name: "IX_EvaluationMethods_CreatedByid",
                table: "EvaluationMethods",
                column: "CreatedByid");

            migrationBuilder.CreateIndex(
                name: "IX_EvaluationMethods_DeletedByid",
                table: "EvaluationMethods",
                column: "DeletedByid");

            migrationBuilder.CreateIndex(
                name: "IX_EvaluationMethods_UpdatedByid",
                table: "EvaluationMethods",
                column: "UpdatedByid");

            migrationBuilder.AddForeignKey(
                name: "FK_Disciplines_EvaluationMethods_EvaluationMethodId",
                table: "Disciplines",
                column: "EvaluationMethodId",
                principalTable: "EvaluationMethods",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Disciplines_EvaluationMethods_EvaluationMethodId",
                table: "Disciplines");

            migrationBuilder.DropTable(
                name: "EvaluationMethods");

            migrationBuilder.DropIndex(
                name: "IX_Disciplines_EvaluationMethodId",
                table: "Disciplines");

            migrationBuilder.DropColumn(
                name: "EvaluationMethodId",
                table: "Disciplines");

            migrationBuilder.DropColumn(
                name: "Facultativ",
                table: "Disciplines");
        }
    }
}
