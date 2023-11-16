using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace vocea_universitatii.Migrations
{
    /// <inheritdoc />
    public partial class UpdataedDisciplinesOptionals : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "ParentDisciplineId",
                table: "Disciplines",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Disciplines_ParentDisciplineId",
                table: "Disciplines",
                column: "ParentDisciplineId");

            migrationBuilder.AddForeignKey(
                name: "FK_Disciplines_Disciplines_ParentDisciplineId",
                table: "Disciplines",
                column: "ParentDisciplineId",
                principalTable: "Disciplines",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Disciplines_Disciplines_ParentDisciplineId",
                table: "Disciplines");

            migrationBuilder.DropIndex(
                name: "IX_Disciplines_ParentDisciplineId",
                table: "Disciplines");

            migrationBuilder.DropColumn(
                name: "ParentDisciplineId",
                table: "Disciplines");
        }
    }
}
