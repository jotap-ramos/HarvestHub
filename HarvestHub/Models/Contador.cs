using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HarvestHub.Models;

public class Contador
{
    [Key]
    public int FuncionarioId { get; set; }
    [Required, MaxLength(15)]
    public required string CRC { get; set; }
    
    [ForeignKey("FuncionarioId")]
    public required Funcionario Funcionario { get; set; }
    public required ICollection<Receita> Receitas { get; set; }
}
