using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HarvestHub.Models;

public class Contrato
{
    [Key]
    public int Id { get; set; }
    [Required, MaxLength(20)]
    public required string Telefone { get; set; }
    private DateTime _dataInicio;
    [Required, DataType(DataType.Date), Column(TypeName = "date"), DisplayName("Data de Inicio")]
    public DateTime DataInicio
    {
        get => _dataInicio;
        set => _dataInicio = DateTime.SpecifyKind(value, DateTimeKind.Utc);
    }
    public int FuncionarioId { get; set; }
    public required Funcionario Funcionario { get; set; }
}