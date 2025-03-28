using System.ComponentModel.DataAnnotations;

namespace HarvestHub.Models;

public class Patrimonio
{
    [Key]
    public int Id { get; set; }
    [Required]
    public decimal Valor { get; set; }
    [Required]
    public DateTime DataAquisicao { get; set; }
    public required string GerenteDeProducaoCrea { get; set; }
    public required GerenteDeProducao GerenteDeProducao { get; set; }
}