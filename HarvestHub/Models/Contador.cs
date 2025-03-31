using System.ComponentModel.DataAnnotations;

namespace HarvestHub.Models;

public class Contador
{
    [Key]
    public int FuncionarioId { get; set; }
    [Required, MaxLength(15)]
    public required string CRC { get; set; }
    public required Funcionario Funcionario { get; set; }
    public required ICollection<Receita> Receitas { get; set; }
}
