using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Nutra.API.Migrations
{
    /// <inheritdoc />
    public partial class RemoveNivelReference : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Desafios_Niveis_IdNivel",
                table: "Desafios");

            migrationBuilder.DropIndex(
                name: "IX_Desafios_IdNivel",
                table: "Desafios");

            migrationBuilder.DropColumn(
                name: "IdNivel",
                table: "Desafios");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdNivel",
                table: "Desafios",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Desafios_IdNivel",
                table: "Desafios",
                column: "IdNivel");

            migrationBuilder.AddForeignKey(
                name: "FK_Desafios_Niveis_IdNivel",
                table: "Desafios",
                column: "IdNivel",
                principalTable: "Niveis",
                principalColumn: "Id");
        }
    }
}
