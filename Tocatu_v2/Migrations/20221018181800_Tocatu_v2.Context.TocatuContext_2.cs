using Microsoft.EntityFrameworkCore.Migrations;

namespace Tocatu_v2.Migrations
{
    public partial class Tocatu_v2ContextTocatuContext_2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Eventos_Banda_BandaId",
                table: "Eventos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Banda",
                table: "Banda");

            migrationBuilder.RenameTable(
                name: "Banda",
                newName: "Usuarios");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Usuarios",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Usuarios",
                table: "Usuarios",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Eventos_Usuarios_BandaId",
                table: "Eventos",
                column: "BandaId",
                principalTable: "Usuarios",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Eventos_Usuarios_BandaId",
                table: "Eventos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Usuarios",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Usuarios");

            migrationBuilder.RenameTable(
                name: "Usuarios",
                newName: "Banda");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Banda",
                table: "Banda",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Eventos_Banda_BandaId",
                table: "Eventos",
                column: "BandaId",
                principalTable: "Banda",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
