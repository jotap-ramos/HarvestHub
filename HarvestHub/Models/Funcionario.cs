using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HarvestHub.Models;

public class Funcionario
{
    [Key]
    public int Id { get; set; }
    [Required, MaxLength(45)]
    public required string Nome { get; set; }
    [Required]
    [DataType(DataType.Currency)]
    [Column(TypeName = "DECIMAL(10, 2)")]
    public decimal Salario { get; set; }
    private DateTime _dataAdmissao;
    [Required, DataType(DataType.Date), Column(TypeName = "date"), DisplayName("Data de Admissao")]
    public required DateTime DataAdmissao
    {
        get => _dataAdmissao;
        set => _dataAdmissao = DateTime.SpecifyKind(value, DateTimeKind.Utc);
    }
    [Required, MaxLength(11)]
    public required string CPF { get; set; }
    private DateTime _dataNascimento;
    [Required, DataType(DataType.Date), Column(TypeName = "date"), DisplayName("Data de Nascimento")]
    public required DateTime DataNascimento
    {
        get => _dataNascimento;
        set => _dataNascimento = DateTime.SpecifyKind(value, DateTimeKind.Utc);
    }
    [Required]
    public short Status { get; set; }

    public GerenteDeProducao? GerenteDeProducao { get; set; }
    public RecursosHumanos? RecursosHumanos { get; set; }
    public Contador? Contador { get; set; }
    public required ICollection<Contrato> Contratos { get; set; }
}
