using Microsoft.EntityFrameworkCore.Migrations;

namespace tocatu.Migrations
{
    public partial class TocatuContextTocatuDBContext : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreUsuario = table.Column<string>(nullable: true),
                    Nombre = table.Column<string>(nullable: true),
                    Apellido = table.Column<string>(nullable: true),
                    Mail = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    Discriminator = table.Column<string>(nullable: false),
                    Estilo = table.Column<string>(nullable: true),
                    Direccion = table.Column<string>(nullable: true),
                    Capacidad = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "Eventos",
                columns: table => new
                {
                    EventId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(nullable: true),
                    Descripcion = table.Column<string>(nullable: true),
                    PrecioEntrada = table.Column<double>(nullable: false),
                    Dia = table.Column<string>(nullable: true),
                    Hora = table.Column<string>(nullable: true),
                    Capacidad = table.Column<int>(nullable: false),
                    Direccion = table.Column<string>(nullable: true),
                    BandaId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Eventos", x => x.EventId);
                    table.ForeignKey(
                        name: "FK_Eventos_Usuarios_BandaId",
                        column: x => x.BandaId,
                        principalTable: "Usuarios",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Eventos_BandaId",
                table: "Eventos",
                column: "BandaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Eventos");

            migrationBuilder.DropTable(
                name: "Usuarios");
        }
    }
}
