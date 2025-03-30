using Microsoft.EntityFrameworkCore;
using HarvestHub.Models;

namespace HarvestHub.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<Contador> Contadors { get; set; }
        public DbSet<Contrato> Contrato{ get; set; }
        public DbSet<Despesa> Despesas { get; set; }
        public DbSet<Estoque> Estoques{ get; set; }
        public DbSet<Fornecedor> Fornecedors{ get; set; }
        public DbSet<Funcionario> Funcionarios{ get; set; }
        public DbSet<GerenteDeProducao> GerenteDeProducaos{ get; set; }
        public DbSet<Insumo> Insumos { get; set; }
        public DbSet<Patrimonio> Patrimonios { get; set; }
        public DbSet<Producao> Producaos{ get; set; }
        public DbSet<Receita> Receitas { get; set; }
        public DbSet<RecursosHumanos> RecursosHumanos { get; set; }

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