using System;
using System.Collections.Generic;

namespace HarvestHub.Models;

public partial class Fornecedor
{
    public int Id { get; set; }
    public string? Nome { get; set; }
    public string? CNPJ { get; set; }
    public string? Telefone { get; set; }
    public string? Email { get; set; }
    public List<Contrato>? Contratos { get; set; }
}
