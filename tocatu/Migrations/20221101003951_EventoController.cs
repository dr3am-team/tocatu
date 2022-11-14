using Microsoft.EntityFrameworkCore.Migrations;

namespace tocatu.Migrations
{
    public partial class EventoController : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Eventos_Usuarios_BandaId",
                table: "Eventos");

            migrationBuilder.DropIndex(
                name: "IX_Eventos_BandaId",
                table: "Eventos");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Eventos_BandaId",
                table: "Eventos",
                column: "BandaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Eventos_Usuarios_BandaId",
                table: "Eventos",
                column: "BandaId",
                principalTable: "Usuarios",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
