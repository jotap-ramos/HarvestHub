using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HarvestHub.Models;

public class Patrimonio
{
    [Key]
    public int Id { get; set; }
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
    public required string GerenteDeProducaoCrea { get; set; }
    public required GerenteDeProducao GerenteDeProducao { get; set; }
}