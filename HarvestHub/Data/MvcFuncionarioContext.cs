using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using HarvestHub.Models;

namespace MvcFuncionario.Data
{
    public class MvcFuncionarioContext : DbContext
    {
        public MvcFuncionarioContext (DbContextOptions<MvcFuncionarioContext> options)
            : base(options)
        {
        }

        public DbSet<HarvestHub.Models.Funcionario> Funcionario { get; set; } = default!;
    }
}
