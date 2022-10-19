using Microsoft.EntityFrameworkCore.Migrations;

namespace Tocatu_v2.Migrations
{
    public partial class Tocatu_v2ContextTocatuContext_7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Estilo",
                table: "Usuarios",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Nombre",
                table: "Eventos",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Estilo",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "Nombre",
                table: "Eventos");
        }
    }
}
