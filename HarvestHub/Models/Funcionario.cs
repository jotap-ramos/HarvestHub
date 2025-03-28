using System.ComponentModel.DataAnnotations;

namespace HarvestHub.Models;

public class Funcionario
{
    [Key]
    public int Id { get; set; }
    [Required, MaxLength(45)]
    public string Nome { get; set; }
    [Required]
    public decimal Salario { get; set; }
    [Required]
    public DateTime DataAdmissao { get; set; }
    [Required, MaxLength(11)]
    public string CPF { get; set; }
    [Required]
    public DateTime DataNascimento { get; set; }
    [Required]
    public short Status { get; set; }

    public GerenteDeProducao? GerenteDeProducao { get; set; }
    public RecursosHumanos? RecursosHumanos { get; set; }
    public Contador? Contador { get; set; }
    public ICollection<Contrato>? Contratos { get; set; }
}