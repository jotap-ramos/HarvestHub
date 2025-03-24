using System;
using System.Collections.Generic;

namespace HarvestHub.Models;

public partial class GerenteDeProducao
{
    public string Crea { get; set; } = null!;

    public int FuncionarioIdfuncionario { get; set; }

    public virtual Funcionario FuncionarioIdfuncionarioNavigation { get; set; } = null!;

    public virtual ICollection<Insumo> Insumos { get; set; } = new List<Insumo>();

    public virtual ICollection<Patrimonio> Patrimonios { get; set; } = new List<Patrimonio>();
}
