using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Nutra.API.Migrations
{
    /// <inheritdoc />
    public partial class UpdateRegrasDesafiosTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RegrasDesafios_Desafios_DesafiosId",
                table: "RegrasDesafios");

            migrationBuilder.DropIndex(
                name: "IX_RegrasDesafios_DesafiosId",
                table: "RegrasDesafios");

            migrationBuilder.DropColumn(
                name: "DesafiosId",
                table: "RegrasDesafios");

            migrationBuilder.CreateIndex(
                name: "IX_RegrasDesafios_IdDesafio",
                table: "RegrasDesafios",
                column: "IdDesafio");

            migrationBuilder.CreateIndex(
                name: "IX_RegrasDesafios_IdOpcao",
                table: "RegrasDesafios",
                column: "IdOpcao");

            migrationBuilder.AddForeignKey(
                name: "FK_RegrasDesafios_Desafios_IdDesafio",
                table: "RegrasDesafios",
                column: "IdDesafio",
                principalTable: "Desafios",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RegrasDesafios_Opcoes_IdOpcao",
                table: "RegrasDesafios",
                column: "IdOpcao",
                principalTable: "Opcoes",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RegrasDesafios_Desafios_IdDesafio",
                table: "RegrasDesafios");

            migrationBuilder.DropForeignKey(
                name: "FK_RegrasDesafios_Opcoes_IdOpcao",
                table: "RegrasDesafios");

            migrationBuilder.DropIndex(
                name: "IX_RegrasDesafios_IdDesafio",
                table: "RegrasDesafios");

            migrationBuilder.DropIndex(
                name: "IX_RegrasDesafios_IdOpcao",
                table: "RegrasDesafios");

            migrationBuilder.AddColumn<int>(
                name: "DesafiosId",
                table: "RegrasDesafios",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_RegrasDesafios_DesafiosId",
                table: "RegrasDesafios",
                column: "DesafiosId");

            migrationBuilder.AddForeignKey(
                name: "FK_RegrasDesafios_Desafios_DesafiosId",
                table: "RegrasDesafios",
                column: "DesafiosId",
                principalTable: "Desafios",
                principalColumn: "Id");
        }
    }
}
