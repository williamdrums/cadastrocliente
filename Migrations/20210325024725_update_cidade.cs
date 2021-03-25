using Microsoft.EntityFrameworkCore.Migrations;

namespace CadastroCliente.Migrations
{
    public partial class update_cidade : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cidades_Estados_IdEstadoId",
                table: "Cidades");

            migrationBuilder.RenameColumn(
                name: "IdEstadoId",
                table: "Cidades",
                newName: "EstadoId");

            migrationBuilder.RenameIndex(
                name: "IX_Cidades_IdEstadoId",
                table: "Cidades",
                newName: "IX_Cidades_EstadoId");

            migrationBuilder.AddColumn<int>(
                name: "IdEstado",
                table: "Cidades",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Cidades_Estados_EstadoId",
                table: "Cidades",
                column: "EstadoId",
                principalTable: "Estados",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cidades_Estados_EstadoId",
                table: "Cidades");

            migrationBuilder.DropColumn(
                name: "IdEstado",
                table: "Cidades");

            migrationBuilder.RenameColumn(
                name: "EstadoId",
                table: "Cidades",
                newName: "IdEstadoId");

            migrationBuilder.RenameIndex(
                name: "IX_Cidades_EstadoId",
                table: "Cidades",
                newName: "IX_Cidades_IdEstadoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cidades_Estados_IdEstadoId",
                table: "Cidades",
                column: "IdEstadoId",
                principalTable: "Estados",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
