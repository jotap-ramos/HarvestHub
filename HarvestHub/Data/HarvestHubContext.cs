
using HarvestHub.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace HarvestHub.Data
{
    public class HarvestHubContext : DbContext
    {
        public HarvestHubContext(DbContextOptions<HarvestHubContext> options) : base(options) { }
        public DbSet<Patrimonio> Patrimonios { get; set; }
        public DbSet<Fornecedor> Fornecedores { get; set; }
        public DbSet<Contrato> Contratos { get; set; }
        public DbSet<Producao> Producoes { get; set; }
        public DbSet<Insumo> Insumos { get; set; }
    }
}
