using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HarvestHub.ViewModels;

public class ContadorViewModel
{
    [Key]
    public int FuncionarioId { get; set; }
    [Required, MaxLength(45)]
    public required string Nome { get; set; }

    [Required, DataType(DataType.Currency), Column(TypeName = "decimal(10, 2)")]
    public decimal Salario { get; set; }

    [Required, DataType(DataType.Date)]
    public DateTime DataAdmissao { get; set; }

    [Required, MaxLength(11)]
    public required string CPF { get; set; }

    [Required, DataType(DataType.Date)]
    public DateTime DataNascimento { get; set; }

    [Required]
    public short Status { get; set; }
    
    [Required, MaxLength(15)]
    public required string CRC { get; set; }
}