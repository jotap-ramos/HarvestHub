using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HarvestHub.Models;

public class RecursosHumanos
{
    [Key]
    public int FuncionarioId { get; set; }
    [Required, MaxLength(50)]
    public required string CRA { get; set; }
    
    [ForeignKey("FuncionarioId")]
    public required Funcionario Funcionario { get; set; }


}
