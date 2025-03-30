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
                name: "Contrato",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Telefone = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    DataInicio = table.Column<DateTime>(type: "date", nullable: false),
                    FuncionarioId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contrato", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Contrato_Funcionario_FuncionarioId",
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
                name: "Receita",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Tipo = table.Column<string>(type: "character varying(45)", maxLength: 45, nullable: false),
                    Valor = table.Column<decimal>(type: "numeric(10,2)", nullable: false),
                    DataRegistro = table.Column<DateTime>(type: "date", nullable: false),
                    ContadorFuncionarioId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Receita", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Receita_Contador_ContadorFuncionarioId",
                        column: x => x.ContadorFuncionarioId,
                        principalTable: "Contador",
                        principalColumn: "FuncionarioId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Insumo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Tipo = table.Column<string>(type: "character varying(45)", maxLength: 45, nullable: false),
                    Codigo = table.Column<string>(type: "character varying(45)", maxLength: 45, nullable: false),
                    Volume = table.Column<string>(type: "character varying(45)", maxLength: 45, nullable: false),
                    Custo = table.Column<decimal>(type: "numeric(10,2)", nullable: false),
                    Descricao = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    Marca = table.Column<string>(type: "character varying(45)", maxLength: 45, nullable: false),
                    GerenteDeProducaoCrea = table.Column<string>(type: "text", nullable: false),
                    GerenteDeProducaoFuncionarioId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Insumo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Insumo_GerenteDeProducao_GerenteDeProducaoFuncionarioId",
                        column: x => x.GerenteDeProducaoFuncionarioId,
                        principalTable: "GerenteDeProducao",
                        principalColumn: "FuncionarioId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Patrimonio",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Valor = table.Column<decimal>(type: "numeric(10,2)", nullable: false),
                    DataAquisicao = table.Column<DateTime>(type: "date", nullable: false),
                    GerenteDeProducaoCrea = table.Column<string>(type: "text", nullable: false),
                    GerenteDeProducaoFuncionarioId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patrimonio", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Patrimonio_GerenteDeProducao_GerenteDeProducaoFuncionarioId",
                        column: x => x.GerenteDeProducaoFuncionarioId,
                        principalTable: "GerenteDeProducao",
                        principalColumn: "FuncionarioId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Contrato_FuncionarioId",
                table: "Contrato",
                column: "FuncionarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Insumo_GerenteDeProducaoFuncionarioId",
                table: "Insumo",
                column: "GerenteDeProducaoFuncionarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Patrimonio_GerenteDeProducaoFuncionarioId",
                table: "Patrimonio",
                column: "GerenteDeProducaoFuncionarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Receita_ContadorFuncionarioId",
                table: "Receita",
                column: "ContadorFuncionarioId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Contrato");

            migrationBuilder.DropTable(
                name: "Insumo");

            migrationBuilder.DropTable(
                name: "Patrimonio");

            migrationBuilder.DropTable(
                name: "Receita");

            migrationBuilder.DropTable(
                name: "RecursosHumanos");

            migrationBuilder.DropTable(
                name: "GerenteDeProducao");

            migrationBuilder.DropTable(
                name: "Contador");

            migrationBuilder.DropTable(
                name: "Funcionario");
        }
    }
}
