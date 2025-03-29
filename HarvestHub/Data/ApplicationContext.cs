using Microsoft.EntityFrameworkCore;

namespace HarvestHub.Data;

public class ApplicationContext(DbContextOptions<ApplicationContext> options) : DbContext(options)
{
    public DbSet<HarvestHub.Models.Contador> Contador { get; set; } = default!;
    public DbSet<HarvestHub.Models.Funcionario> Funcionario { get; set; } = default!;
}