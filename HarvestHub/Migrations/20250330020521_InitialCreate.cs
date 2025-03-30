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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "INSUMO");

            migrationBuilder.DropTable(
                name: "PRODUCAO");
        }
    }
}
