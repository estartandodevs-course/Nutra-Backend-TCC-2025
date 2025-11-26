using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Nutra.API.Migrations
{
    /// <inheritdoc />
    public partial class RecreateUsuarioFKs : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Recria as FKs para Usuarios
            migrationBuilder.AddForeignKey(
                name: "FK_Progressos_Usuarios_IdUsuario",
                table: "Progressos",
                column: "IdUsuario",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Registros_Usuarios_IdUsuario",
                table: "Registros",
                column: "IdUsuario",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Respostas_Usuarios_IdUsuario",
                table: "Respostas",
                column: "IdUsuario",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // Remove as FKs caso precise reverter
            migrationBuilder.DropForeignKey(
                name: "FK_Progressos_Usuarios_IdUsuario",
                table: "Progressos");

            migrationBuilder.DropForeignKey(
                name: "FK_Registros_Usuarios_IdUsuario",
                table: "Registros");

            migrationBuilder.DropForeignKey(
                name: "FK_Respostas_Usuarios_IdUsuario",
                table: "Respostas");
        }
    }
}