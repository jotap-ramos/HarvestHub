using System;
using System.Collections.Generic;

namespace HarvestHub.Models;

public partial class Contrato
{
    public int Idcontrato { get; set; }

    public string Telefone { get; set; } = null!;

    public DateOnly DataInicio { get; set; }

    public int FuncionarioIdfuncionario { get; set; }

    public virtual Funcionario FuncionarioIdfuncionarioNavigation { get; set; } = null!;
}
