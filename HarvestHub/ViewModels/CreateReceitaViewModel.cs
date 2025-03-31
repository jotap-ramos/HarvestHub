using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HarvestHub.ViewModels;

public class CreateReceitaViewModel
{
    [Required(ErrorMessage = "O tipo da receita é obrigatório.")]
    [StringLength(45, ErrorMessage = "O tipo não pode exceder 45 caracteres.")]
    public required string Tipo { get; set; }

    [Required(ErrorMessage = "O valor é obrigatório.")]
    [Range(0.01, double.MaxValue, ErrorMessage = "O valor deve ser maior que zero.")]
    [Column(TypeName = "DECIMAL(10, 2)")]
    public decimal Valor { get; set; }

    [Required(ErrorMessage = "O ID do contador é obrigatório.")]
    [DisplayName("Nome do Contador")]
    public int ContadorFuncionarioId { get; set; }

    [DataType(DataType.Date)]
    [DisplayName("Data de Registro")]
    public DateTime DataRegistro { get; set; } = DateTime.UtcNow;
}