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
    public string GerenteDeProducaoCrea { get; set; }
    public GerenteDeProducao GerenteDeProducao { get; set; }
}