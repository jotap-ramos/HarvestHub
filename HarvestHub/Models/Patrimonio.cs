using System;
using System.Collections.Generic;

namespace HarvestHub.Models;

public partial class Patrimonio
{
    public int Idpatrimonio { get; set; }

    public decimal Valor { get; set; }

    public DateOnly DataAquisicao { get; set; }

    public string GerenteDeProducaoCrea { get; set; } = null!;

    public virtual GerenteDeProducao GerenteDeProducaoCreaNavigation { get; set; } = null!;
}
