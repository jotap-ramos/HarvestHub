using System.ComponentModel.DataAnnotations;

namespace HarvestHub.ViewModels;

public class EditFornecedorViewModel
{
    public required string Nome { get; set; }
    [Required, StringLength(14)]
    public required string CNPJ { get; set; }
    public required string Telefone { get; set; }
    public required string Email { get; set; }
}