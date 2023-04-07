using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API_CRUD_FROTA.Migrations
{
    public partial class jointablesfinish : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OnibusId",
                table: "Onibus");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "OnibusId",
                table: "Onibus",
                type: "int",
                nullable: true);
        }
    }
}
