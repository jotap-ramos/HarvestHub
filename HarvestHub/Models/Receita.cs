using System;
using System.Collections.Generic;

namespace HarvestHub.Models;

public partial class Receita
{
    public int Idreceita { get; set; }

    public string Tipo { get; set; } = null!;

    public decimal Valor { get; set; }

    public DateOnly DataRegistro { get; set; }

    public int ContadorFuncionarioIdfuncionario { get; set; }

    public virtual Contador ContadorFuncionarioIdfuncionarioNavigation { get; set; } = null!;
}
