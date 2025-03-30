using Microsoft.EntityFrameworkCore;
using HarvestHub.Models;

namespace HarvestHub.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Producao> Producoes { get; set; }
        public DbSet<Insumo> Insumos { get; set; }
    }
}