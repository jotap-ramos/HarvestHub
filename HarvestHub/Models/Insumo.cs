using System.ComponentModel.DataAnnotations;

namespace HarvestHub.Models;

public class Insumo
{
    [Key]
    public int Id { get; set; }
    [Required, MaxLength(45)]
    public string Tipo { get; set; }
    [Required, MaxLength(45)]
    public string Codigo { get; set; }
    [Required, MaxLength(45)]
    public string Volume { get; set; }
    [Required]
    public decimal Custo { get; set; }
    [MaxLength(100)]
    public string? Descricao { get; set; }
    [Required, MaxLength(45)]
    public string Marca { get; set; }
    public string GerenteDeProducaoCrea { get; set; }
    public GerenteDeProducao GerenteDeProducao { get; set; }
}