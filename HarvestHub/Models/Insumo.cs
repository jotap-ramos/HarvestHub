using System;
using System.Collections.Generic;

namespace HarvestHub.Models;

public partial class Insumo
{
    public int Idinsumo { get; set; }

    public string TipoInsumo { get; set; } = null!;

    public string CodInsumo { get; set; } = null!;

    public string Volume { get; set; } = null!;

    public decimal Custo { get; set; }

    public string? Descricao { get; set; }

    public string Marca { get; set; } = null!;

    public string GerenteDeProducaoCrea { get; set; } = null!;

    public virtual ICollection<Estoque> Estoques { get; set; } = new List<Estoque>();

    public virtual GerenteDeProducao GerenteDeProducaoCreaNavigation { get; set; } = null!;
}
