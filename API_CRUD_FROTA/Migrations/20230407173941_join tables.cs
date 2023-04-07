using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API_CRUD_FROTA.Migrations
{
    public partial class jointables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MotoristaId",
                table: "Onibus",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "OnibusId",
                table: "Onibus",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Onibus_MotoristaId",
                table: "Onibus",
                column: "MotoristaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Onibus_Motorista_MotoristaId",
                table: "Onibus",
                column: "MotoristaId",
                principalTable: "Motorista",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Onibus_Motorista_MotoristaId",
                table: "Onibus");

            migrationBuilder.DropIndex(
                name: "IX_Onibus_MotoristaId",
                table: "Onibus");

            migrationBuilder.DropColumn(
                name: "MotoristaId",
                table: "Onibus");

            migrationBuilder.DropColumn(
                name: "OnibusId",
                table: "Onibus");
        }
    }
}
