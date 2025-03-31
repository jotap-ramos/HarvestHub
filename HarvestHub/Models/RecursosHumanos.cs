using System.ComponentModel.DataAnnotations;

namespace HarvestHub.Models;

public class RecursosHumanos
{
    [Key]
    public int FuncionarioId { get; set; }
    [Required, MaxLength(50)]
    public required string CRA { get; set; }
    public required Funcionario Funcionario { get; set; }


}
