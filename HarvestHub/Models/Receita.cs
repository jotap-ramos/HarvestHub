using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HarvestHub.Models;

public class Receita
{
    [Key]
    public int Id { get; set; }
    [Required, MaxLength(45)]
    public required string Tipo { get; set; }
    [Required]
    [DataType(DataType.Currency)]
    [Column(TypeName = "DECIMAL(10, 2)")]
    public decimal Valor { get; set; }
    private DateTime _dataRegistro;
    [Required, DataType(DataType.Date), Column(TypeName = "date"), DisplayName("Data de Registro")]
    public DateTime DataRegistro
    {
        get => _dataRegistro;
        set => _dataRegistro = DateTime.SpecifyKind(value, DateTimeKind.Utc);
    }
    public int ContadorFuncionarioId { get; set; }
    public required Contador? Contador { get; set; }
}