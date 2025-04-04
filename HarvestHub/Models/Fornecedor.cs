using System.ComponentModel.DataAnnotations;

namespace HarvestHub.Models;

public class Fornecedor
{
    [Key]
    public int Id { get; set; }
    
    public required string Nome { get; set; }
    [Required, StringLength(14)]
    public required string CNPJ { get; set; }
    public required string Telefone { get; set; }
    public required string Email { get; set; }
    public List<Contrato> Contratos { get; set; } = new();
}
