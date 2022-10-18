using Microsoft.EntityFrameworkCore.Migrations;

namespace Tocatu_v2.Migrations
{
    public partial class Tocatu_v2ContextTocatuContext_6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Nombre",
                table: "Eventos");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Nombre",
                table: "Eventos",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
