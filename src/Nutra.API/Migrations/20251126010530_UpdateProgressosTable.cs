using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Nutra.API.Migrations
{
    /// <inheritdoc />
    public partial class UpdateProgressosTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Ativo",
                table: "Progressos",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Ativo",
                table: "Progressos");
        }
    }
}
