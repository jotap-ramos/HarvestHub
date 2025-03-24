using System;
using System.Collections.Generic;

namespace HarvestHub.Models;

public partial class Producao
{
    public int Idproducao { get; set; }

    public string Tipo { get; set; } = null!;

    public decimal Custo { get; set; }

    public string Volume { get; set; } = null!;
}
