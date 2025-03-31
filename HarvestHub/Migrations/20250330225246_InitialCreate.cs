using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace HarvestHub.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Fornecedores",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nome = table.Column<string>(type: "text", nullable: true),
                    CNPJ = table.Column<string>(type: "text", nullable: true),
                    Telefone = table.Column<string>(type: "text", nullable: true),
                    Email = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fornecedores", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "INSUMO",
                columns: table => new
                {
                    IdInsumo = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TipoInsumo = table.Column<string>(type: "character varying(45)", maxLength: 45, nullable: false),
                    CodInsumo = table.Column<string>(type: "character varying(45)", maxLength: 45, nullable: false),
                    Volume = table.Column<string>(type: "character varying(45)", maxLength: 45, nullable: false),
                    Custo = table.Column<decimal>(type: "numeric", nullable: false),
                    Descricao = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    Marca = table.Column<string>(type: "character varying(45)", maxLength: 45, nullable: false),
                    GerenteDeProducaoCrea = table.Column<string>(type: "character varying(9)", maxLength: 9, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_INSUMO", x => x.IdInsumo);
                });

            migrationBuilder.CreateTable(
                name: "Patrimonios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nome = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Categoria = table.Column<string>(type: "text", nullable: false),
                    Valor = table.Column<double>(type: "double precision", nullable: false),
                    DataAquisicao = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patrimonios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PRODUCAO",
                columns: table => new
                {
                    IdProducao = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Tipo = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    Custo = table.Column<decimal>(type: "numeric", nullable: false),
                    Volume = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PRODUCAO", x => x.IdProducao);
                });

            migrationBuilder.CreateTable(
                name: "Contratos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    NumeroContrato = table.Column<string>(type: "character varying(11)", maxLength: 11, nullable: false),
                    DataInicio = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DataFim = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ValorTotal = table.Column<decimal>(type: "numeric", nullable: false),
                    FornecedorId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contratos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Contratos_Fornecedores_FornecedorId",
                        column: x => x.FornecedorId,
                        principalTable: "Fornecedores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Contratos_FornecedorId",
                table: "Contratos",
                column: "FornecedorId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Contratos");

            migrationBuilder.DropTable(
                name: "INSUMO");

            migrationBuilder.DropTable(
                name: "Patrimonios");

            migrationBuilder.DropTable(
                name: "PRODUCAO");

            migrationBuilder.DropTable(
                name: "Fornecedores");
        }
    }
}
