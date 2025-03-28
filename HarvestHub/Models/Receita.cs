using System.ComponentModel.DataAnnotations;

namespace HarvestHub.Models;

public class Receita
{
    [Key]
    public int Id { get; set; }
    [Required, MaxLength(45)]
    public required string Tipo { get; set; }
    [Required]
    public decimal Valor { get; set; }
    [Required]
    public DateTime DataRegistro { get; set; }
    public int ContadorFuncionarioId { get; set; }
    public required Contador Contador { get; set; }
}