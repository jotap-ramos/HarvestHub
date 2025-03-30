using System;
using System.Collections.Generic;

namespace HarvestHub.Models;

public partial class RecursosHumanos
{
    public int FuncionarioIdfuncionario { get; set; }

    public string Cra { get; set; } = null!;

    public virtual Funcionario FuncionarioIdfuncionarioNavigation { get; set; } = null!;
}
