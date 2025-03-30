using System;
using System.Collections.Generic;

namespace HarvestHub.Models;

public partial class Funcionario
{
    public int Idfuncionario { get; set; }

    public string Nome { get; set; } = null!;

    public decimal Salario { get; set; }

    public DateOnly DataAdmissao { get; set; }

    public string Cpf { get; set; } = null!;

    public DateOnly DataNascimento { get; set; }

    public short Status { get; set; }

    public virtual Contador? Contador { get; set; }

    public virtual ICollection<Contrato> Contratos { get; set; } = new List<Contrato>();

    public virtual GerenteDeProducao? GerenteDeProducao { get; set; }

    public virtual RecursosHumanos? RecursosHumanos { get; set; }
}
