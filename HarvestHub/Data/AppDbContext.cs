using Microsoft.EntityFrameworkCore;
using HarvestHub.Models;

namespace HarvestHub.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Despesa> Despesas { get; set; }
        public DbSet<Receita> Receitas { get; set; }
        public DbSet<Estoque> Estoques { get; set; }
        public DbSet<Contador> Contadores { get; set; }
        public DbSet<Insumo> Insumos { get; set; }

        // Adicione DbSet<T> para cada entidade que deseja mapear no banco de dados
        // Exemplo:
        // public DbSet<Produto> Produtos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configurações adicionais de mapeamento podem ser feitas aqui
            // Exemplo:
            // modelBuilder.Entity<Produto>().HasKey(p => p.Id);
        }
    }
}