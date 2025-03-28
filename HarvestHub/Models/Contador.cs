using System.ComponentModel.DataAnnotations;

namespace HarvestHub.Models;

public class Contador
{
    [Key]
    public int FuncionarioId { get; set; }
    [Required, MaxLength(15)]
    public string CRC { get; set; }
    public Funcionario Funcionario { get; set; }
    public ICollection<Receita>? Receitas { get; set; }
}