using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HarvestHub.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contrato_Fornecedor_FornecedorId",
                table: "Contrato");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Patrimonio",
                table: "Patrimonio");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Fornecedor",
                table: "Fornecedor");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Contrato",
                table: "Contrato");

            migrationBuilder.RenameTable(
                name: "Patrimonio",
                newName: "Patrimonios");

            migrationBuilder.RenameTable(
                name: "Fornecedor",
                newName: "Fornecedores");

            migrationBuilder.RenameTable(
                name: "Contrato",
                newName: "Contratos");

            migrationBuilder.RenameIndex(
                name: "IX_Contrato_FornecedorId",
                table: "Contratos",
                newName: "IX_Contratos_FornecedorId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Patrimonios",
                table: "Patrimonios",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Fornecedores",
                table: "Fornecedores",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Contratos",
                table: "Contratos",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Contratos_Fornecedores_FornecedorId",
                table: "Contratos",
                column: "FornecedorId",
                principalTable: "Fornecedores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contratos_Fornecedores_FornecedorId",
                table: "Contratos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Patrimonios",
                table: "Patrimonios");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Fornecedores",
                table: "Fornecedores");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Contratos",
                table: "Contratos");

            migrationBuilder.RenameTable(
                name: "Patrimonios",
                newName: "Patrimonio");

            migrationBuilder.RenameTable(
                name: "Fornecedores",
                newName: "Fornecedor");

            migrationBuilder.RenameTable(
                name: "Contratos",
                newName: "Contrato");

            migrationBuilder.RenameIndex(
                name: "IX_Contratos_FornecedorId",
                table: "Contrato",
                newName: "IX_Contrato_FornecedorId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Patrimonio",
                table: "Patrimonio",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Fornecedor",
                table: "Fornecedor",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Contrato",
                table: "Contrato",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Contrato_Fornecedor_FornecedorId",
                table: "Contrato",
                column: "FornecedorId",
                principalTable: "Fornecedor",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
