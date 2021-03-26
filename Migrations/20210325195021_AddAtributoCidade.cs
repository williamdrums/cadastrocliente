using Microsoft.EntityFrameworkCore.Migrations;

namespace CadastroCliente.Migrations
{
    public partial class AddAtributoCidade : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clientes_Enderecos_IdEnderecoId",
                table: "Clientes");

            migrationBuilder.DropForeignKey(
                name: "FK_Enderecos_Cidades_IdCidadeId",
                table: "Enderecos");

            migrationBuilder.RenameColumn(
                name: "IdCidadeId",
                table: "Enderecos",
                newName: "cidadeId");

            migrationBuilder.RenameIndex(
                name: "IX_Enderecos_IdCidadeId",
                table: "Enderecos",
                newName: "IX_Enderecos_cidadeId");

            migrationBuilder.RenameColumn(
                name: "IdEnderecoId",
                table: "Clientes",
                newName: "enderecoId");

            migrationBuilder.RenameIndex(
                name: "IX_Clientes_IdEnderecoId",
                table: "Clientes",
                newName: "IX_Clientes_enderecoId");

            migrationBuilder.AddColumn<int>(
                name: "IdCidade",
                table: "Enderecos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IdEndereco",
                table: "Clientes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Clientes_Enderecos_enderecoId",
                table: "Clientes",
                column: "enderecoId",
                principalTable: "Enderecos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Enderecos_Cidades_cidadeId",
                table: "Enderecos",
                column: "cidadeId",
                principalTable: "Cidades",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clientes_Enderecos_enderecoId",
                table: "Clientes");

            migrationBuilder.DropForeignKey(
                name: "FK_Enderecos_Cidades_cidadeId",
                table: "Enderecos");

            migrationBuilder.DropColumn(
                name: "IdCidade",
                table: "Enderecos");

            migrationBuilder.DropColumn(
                name: "IdEndereco",
                table: "Clientes");

            migrationBuilder.RenameColumn(
                name: "cidadeId",
                table: "Enderecos",
                newName: "IdCidadeId");

            migrationBuilder.RenameIndex(
                name: "IX_Enderecos_cidadeId",
                table: "Enderecos",
                newName: "IX_Enderecos_IdCidadeId");

            migrationBuilder.RenameColumn(
                name: "enderecoId",
                table: "Clientes",
                newName: "IdEnderecoId");

            migrationBuilder.RenameIndex(
                name: "IX_Clientes_enderecoId",
                table: "Clientes",
                newName: "IX_Clientes_IdEnderecoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Clientes_Enderecos_IdEnderecoId",
                table: "Clientes",
                column: "IdEnderecoId",
                principalTable: "Enderecos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Enderecos_Cidades_IdCidadeId",
                table: "Enderecos",
                column: "IdCidadeId",
                principalTable: "Cidades",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
