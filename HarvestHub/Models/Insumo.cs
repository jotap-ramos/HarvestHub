using System.ComponentModel.DataAnnotations;

namespace HarvestHub.Models;

public class Insumo
{
    [Key]
    public int Id { get; set; }
    [Required, MaxLength(45)]
    public required string Tipo { get; set; }
    [Required, MaxLength(45)]
    public required string Codigo { get; set; }
    [Required, MaxLength(45)]
    public required string Volume { get; set; }
    [Required]
    public decimal Custo { get; set; }
    [MaxLength(100)]
    public string? Descricao { get; set; }
    [Required, MaxLength(45)]
    public required string Marca { get; set; }
    public required string GerenteDeProducaoCrea { get; set; }
    public required GerenteDeProducao GerenteDeProducao { get; set; }
}