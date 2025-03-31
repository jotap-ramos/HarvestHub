using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HarvestHub.Models;

public class GerenteDeProducao
{
    [Key]
    public int FuncionarioId { get; set; }
    [Required, MaxLength(9)]
    public required string CREA { get; set; }
    
    [ForeignKey("FuncionarioId")]
    public required Funcionario Funcionario { get; set; }
    public required ICollection<Patrimonio> Patrimonios { get; set; }
    public required ICollection<Insumo> Insumos { get; set; }
}
