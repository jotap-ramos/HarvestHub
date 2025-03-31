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
                name: "Despesas",
                columns: table => new
                {
                    Iddespesa = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Tipo = table.Column<string>(type: "text", nullable: false),
                    Valor = table.Column<decimal>(type: "numeric", nullable: false),
                    DataRegistro = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DataPagamento = table.Column<DateTime>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Despesas", x => x.Iddespesa);
                });

            migrationBuilder.CreateTable(
                name: "Fornecedores",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nome = table.Column<string>(type: "text", nullable: false),
                    CNPJ = table.Column<string>(type: "character varying(14)", maxLength: 14, nullable: false),
                    Telefone = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fornecedores", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Funcionario",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nome = table.Column<string>(type: "character varying(45)", maxLength: 45, nullable: false),
                    Salario = table.Column<decimal>(type: "numeric(10,2)", nullable: false),
                    DataAdmissao = table.Column<DateTime>(type: "date", nullable: false),
                    CPF = table.Column<string>(type: "character varying(11)", maxLength: 11, nullable: false),
                    DataNascimento = table.Column<DateTime>(type: "date", nullable: false),
                    Status = table.Column<short>(type: "smallint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Funcionario", x => x.Id);
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
                name: "Contador",
                columns: table => new
                {
                    FuncionarioId = table.Column<int>(type: "integer", nullable: false),
                    CRC = table.Column<string>(type: "character varying(15)", maxLength: 15, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contador", x => x.FuncionarioId);
                    table.ForeignKey(
                        name: "FK_Contador_Funcionario_FuncionarioId",
                        column: x => x.FuncionarioId,
                        principalTable: "Funcionario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Contratos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Telefone = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    NumeroContrato = table.Column<string>(type: "character varying(11)", maxLength: 11, nullable: false),
                    DataInicio = table.Column<DateTime>(type: "date", nullable: false),
                    DataFim = table.Column<DateTime>(type: "date", nullable: false),
                    ValorTotal = table.Column<decimal>(type: "numeric", nullable: false),
                    FuncionarioId = table.Column<int>(type: "integer", nullable: false),
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
                    table.ForeignKey(
                        name: "FK_Contratos_Funcionario_FuncionarioId",
                        column: x => x.FuncionarioId,
                        principalTable: "Funcionario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GerenteDeProducao",
                columns: table => new
                {
                    FuncionarioId = table.Column<int>(type: "integer", nullable: false),
                    CREA = table.Column<string>(type: "character varying(9)", maxLength: 9, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GerenteDeProducao", x => x.FuncionarioId);
                    table.ForeignKey(
                        name: "FK_GerenteDeProducao_Funcionario_FuncionarioId",
                        column: x => x.FuncionarioId,
                        principalTable: "Funcionario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RecursosHumanos",
                columns: table => new
                {
                    FuncionarioId = table.Column<int>(type: "integer", nullable: false),
                    CRA = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecursosHumanos", x => x.FuncionarioId);
                    table.ForeignKey(
                        name: "FK_RecursosHumanos_Funcionario_FuncionarioId",
                        column: x => x.FuncionarioId,
                        principalTable: "Funcionario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RECEITA",
                columns: table => new
                {
                    idRECEITA = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TIPO = table.Column<string>(type: "character varying(45)", maxLength: 45, nullable: false),
                    Valor = table.Column<decimal>(type: "numeric(10,2)", nullable: false),
                    DATA_REGISTRO = table.Column<DateTime>(type: "DATE", nullable: false),
                    CONTADOR_FUNCIONARIO_idFUNCIONARIO = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RECEITA", x => x.idRECEITA);
                    table.ForeignKey(
                        name: "FK_RECEITA_Contador_CONTADOR_FUNCIONARIO_idFUNCIONARIO",
                        column: x => x.CONTADOR_FUNCIONARIO_idFUNCIONARIO,
                        principalTable: "Contador",
                        principalColumn: "FuncionarioId",
                        onDelete: ReferentialAction.Cascade);
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
                    Custo = table.Column<decimal>(type: "numeric(10,2)", nullable: false),
                    Descricao = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    Marca = table.Column<string>(type: "character varying(45)", maxLength: 45, nullable: false),
                    GerenteDeProducaoId = table.Column<int>(type: "integer", maxLength: 9, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_INSUMO", x => x.IdInsumo);
                    table.ForeignKey(
                        name: "FK_INSUMO_GerenteDeProducao_GerenteDeProducaoId",
                        column: x => x.GerenteDeProducaoId,
                        principalTable: "GerenteDeProducao",
                        principalColumn: "FuncionarioId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Patrimonios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nome = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Categoria = table.Column<string>(type: "text", nullable: false),
                    Valor = table.Column<decimal>(type: "numeric(10,2)", nullable: false),
                    DataAquisicao = table.Column<DateTime>(type: "date", nullable: false),
                    GerenteDeProducaoId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patrimonios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Patrimonios_GerenteDeProducao_GerenteDeProducaoId",
                        column: x => x.GerenteDeProducaoId,
                        principalTable: "GerenteDeProducao",
                        principalColumn: "FuncionarioId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Estoque",
                columns: table => new
                {
                    Idlocal = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Nome = table.Column<string>(type: "text", nullable: false),
                    Local = table.Column<string>(type: "text", nullable: false),
                    InsumoId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estoque", x => x.Idlocal);
                    table.ForeignKey(
                        name: "FK_Estoque_INSUMO_InsumoId",
                        column: x => x.InsumoId,
                        principalTable: "INSUMO",
                        principalColumn: "IdInsumo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Contratos_FornecedorId",
                table: "Contratos",
                column: "FornecedorId");

            migrationBuilder.CreateIndex(
                name: "IX_Contratos_FuncionarioId",
                table: "Contratos",
                column: "FuncionarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Estoque_InsumoId",
                table: "Estoque",
                column: "InsumoId");

            migrationBuilder.CreateIndex(
                name: "IX_INSUMO_GerenteDeProducaoId",
                table: "INSUMO",
                column: "GerenteDeProducaoId");

            migrationBuilder.CreateIndex(
                name: "IX_Patrimonios_GerenteDeProducaoId",
                table: "Patrimonios",
                column: "GerenteDeProducaoId");

            migrationBuilder.CreateIndex(
                name: "IX_RECEITA_CONTADOR_FUNCIONARIO_idFUNCIONARIO",
                table: "RECEITA",
                column: "CONTADOR_FUNCIONARIO_idFUNCIONARIO");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Contratos");

            migrationBuilder.DropTable(
                name: "Despesas");

            migrationBuilder.DropTable(
                name: "Estoque");

            migrationBuilder.DropTable(
                name: "Patrimonios");

            migrationBuilder.DropTable(
                name: "PRODUCAO");

            migrationBuilder.DropTable(
                name: "RECEITA");

            migrationBuilder.DropTable(
                name: "RecursosHumanos");

            migrationBuilder.DropTable(
                name: "Fornecedores");

            migrationBuilder.DropTable(
                name: "INSUMO");

            migrationBuilder.DropTable(
                name: "Contador");

            migrationBuilder.DropTable(
                name: "GerenteDeProducao");

            migrationBuilder.DropTable(
                name: "Funcionario");
        }
    }
}
