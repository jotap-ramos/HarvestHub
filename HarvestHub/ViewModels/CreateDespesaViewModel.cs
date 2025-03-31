using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HarvestHub.ViewModels;

public class CreateDespesaViewModel
{
    [Required(ErrorMessage = "O tipo da despesa é obrigatório.")]
    [StringLength(45, ErrorMessage = "O tipo não pode exceder 45 caracteres.")]
    public required string Tipo { get; set; }

    [Required(ErrorMessage = "O valor é obrigatório.")]
    [Range(0.01, double.MaxValue, ErrorMessage = "O valor deve ser maior que zero.")]
    [Column(TypeName = "DECIMAL(10, 2)")]
    public decimal Valor { get; set; }

    [DataType(DataType.Date)]
    [DisplayName("Data de Registro")]
    public DateTime DataRegistro { get; set; } = DateTime.UtcNow;

    private DateTime _dataPagamento;
    [Required, DataType(DataType.Date), Column(TypeName = "date"), DisplayName("Data de Pagamento")]
    public required DateTime DataPagamento
    {
        get => _dataPagamento;
        set => _dataPagamento = DateTime.SpecifyKind(value, DateTimeKind.Utc);
    }
}