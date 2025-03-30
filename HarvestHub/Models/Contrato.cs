using System.ComponentModel.DataAnnotations;

namespace HarvestHub.Models
{
    public class Contrato
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(11)]
        public string? NumeroContrato { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }
        public decimal ValorTotal { get; set; }
        public int FornecedorId { get; set; }
        public Fornecedor? Fornecedor { get; set; }
    }
}
