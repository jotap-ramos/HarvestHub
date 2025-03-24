using System;
using System.Collections.Generic;

namespace HarvestHub.Models;

public partial class Estoque
{
    public int Idlocal { get; set; }

    public string Nome { get; set; } = null!;

    public string Local { get; set; } = null!;

    public int InsumoIdinsumo { get; set; }

    public virtual Insumo InsumoIdinsumoNavigation { get; set; } = null!;
}
