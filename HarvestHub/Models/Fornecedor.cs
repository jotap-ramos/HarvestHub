using System;
using System.Collections.Generic;

namespace HarvestHub.Models;

public partial class Fornecedor
{
    public int Idfornecedor { get; set; }

    public string NomeFornecedor { get; set; } = null!;

    public string CpfCnpj { get; set; } = null!;

    public string Telefone { get; set; } = null!;

    public string Email { get; set; } = null!;
}
