using System.ComponentModel.DataAnnotations;

namespace HarvestHub.Models;

public class GerenteDeProducao
{
    [Key]
    public int FuncionarioId { get; set; }
    [Required, MaxLength(9)]
    public required string CREA { get; set; }
    public required Funcionario Funcionario { get; set; }
    public ICollection<Patrimonio>? Patrimonios { get; set; }
    public ICollection<Insumo>? Insumos { get; set; }
}