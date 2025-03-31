using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HarvestHub.ViewModels;

public class CreateInsumoViewModel
{
    [Required, MaxLength(45)]
    public string Tipo { get; set; }  = "";

    [Required, MaxLength(45)]
    public string Codigo { get; set; }  = "";

    [Required, MaxLength(45)]
    public string Volume { get; set; }  = "";

    [Required]
    [DataType(DataType.Currency)]
    [Column(TypeName = "DECIMAL(10, 2)")]
    public decimal Custo { get; set; }

    [MaxLength(100)]
    public string? Descricao { get; set; }

    [Required, MaxLength(45)]
    public required string Marca { get; set; } = "";
    
    [Required]
    [StringLength(9)]
    public required string Crea { get; set; } = "";
}