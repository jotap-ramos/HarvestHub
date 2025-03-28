using System.ComponentModel.DataAnnotations;

namespace HarvestHub.Models;

public class Contrato
{
    [Key]
    public int Id { get; set; }
    [Required, MaxLength(20)]
    public required string Telefone { get; set; }
    [Required]
    public DateTime DataInicio { get; set; }
    public int FuncionarioId { get; set; }
    public required Funcionario Funcionario { get; set; }
}