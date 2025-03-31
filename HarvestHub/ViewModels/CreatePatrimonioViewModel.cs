using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using HarvestHub.Models;

namespace HarvestHub.ViewModels;

public class CreatePatrimonioViewModel
{
    [Required]
    [StringLength(100)]
    public string? Nome { get; set; }
    [Required]
    public string? Categoria { get; set; }
        
    [Required]
    [DataType(DataType.Currency)]
    [Column(TypeName = "decimal(10, 2)")]
    public decimal Valor { get; set; }
        
    private DateTime _dataAquisicao;
    [Required, DataType(DataType.Date), Column(TypeName = "date"), DisplayName("Data de Aquisicao")]
    public DateTime DataAquisicao
    {
        get => _dataAquisicao;
        set => _dataAquisicao = DateTime.SpecifyKind(value, DateTimeKind.Utc);
    }
        
    [MaxLength(9)]
    public required string CREA { get; set; }
}