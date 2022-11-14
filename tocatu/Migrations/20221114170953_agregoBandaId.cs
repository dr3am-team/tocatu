using Microsoft.EntityFrameworkCore.Migrations;

namespace tocatu.Migrations
{
    public partial class agregoBandaId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BandaId",
                table: "Eventos",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BandaId",
                table: "Eventos");
        }
    }
}
