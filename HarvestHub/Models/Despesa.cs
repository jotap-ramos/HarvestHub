using System;
using System.Collections.Generic;

namespace HarvestHub.Models;

public partial class Despesa
{
    public int Iddespesa { get; set; }

    public string Tipo { get; set; } = null!;

    public decimal Valor { get; set; }

    public DateOnly DataRegistro { get; set; }

    public DateOnly? DataPagamento { get; set; }
}
