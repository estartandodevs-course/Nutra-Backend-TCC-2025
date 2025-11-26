using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Nutra.API.Migrations
{
    /// <inheritdoc />
    public partial class UpdateDesafiosTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PontuacaoNecessaria",
                table: "Desafios");

            migrationBuilder.RenameColumn(
                name: "Progresso",
                table: "Desafios",
                newName: "IdNivel");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Desafios_Niveis_IdNivel",
                table: "Desafios");

            migrationBuilder.DropIndex(
                name: "IX_Desafios_IdNivel",
                table: "Desafios");

            migrationBuilder.RenameColumn(
                name: "IdNivel",
                table: "Desafios",
                newName: "Progresso");

            migrationBuilder.AddColumn<int>(
                name: "PontuacaoNecessaria",
                table: "Desafios",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
