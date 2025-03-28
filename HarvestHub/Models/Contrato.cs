using System.ComponentModel.DataAnnotations;

namespace HarvestHub.Models;

namespace HarvestHub.Models
{
    public class Contrato
    {
        [Key]
        public int Id { get; set; }
        [Required, MaxLength(20)]
        public string Telefone { get; set; }
        [Required]
        [StringLength(11)]
        public string? NumeroContrato { get; set; }
        [Required]
        public DateTime DataInicio { get; set; }
        [Required]
        public DateTime DataFim { get; set; }
        public decimal ValorTotal { get; set; }
        
        public int FuncionarioId { get; set; }
        public Funcionario Funcionario { get; set; }
        public int FornecedorId { get; set; }
        public Fornecedor? Fornecedor { get; set; }
    }
}