using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Nutra.API.Migrations
{
    /// <inheritdoc />
    public partial class AddProgressosTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Progressos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Completo = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    DataConclusao = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    QuantidadeAtual = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    IdUsuario = table.Column<int>(type: "int", nullable: false),
                    IdDesafio = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "datetime(6)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Progressos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Progressos_Desafios_IdDesafio",
                        column: x => x.IdDesafio,
                        principalTable: "Desafios",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Progressos_Usuarios_IdUsuario",
                        column: x => x.IdUsuario,
                        principalTable: "Usuarios",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Progressos_IdDesafio",
                table: "Progressos",
                column: "IdDesafio");

            migrationBuilder.CreateIndex(
                name: "IX_Progressos_IdUsuario",
                table: "Progressos",
                column: "IdUsuario");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Progressos");
        }
    }
}
