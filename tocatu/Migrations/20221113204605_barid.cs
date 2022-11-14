using Microsoft.EntityFrameworkCore.Migrations;

namespace tocatu.Migrations
{
    public partial class barid : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BandaId",
                table: "Eventos");

            migrationBuilder.AddColumn<int>(
                name: "BarId",
                table: "Eventos",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BarId",
                table: "Eventos");

            migrationBuilder.AddColumn<int>(
                name: "BandaId",
                table: "Eventos",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
