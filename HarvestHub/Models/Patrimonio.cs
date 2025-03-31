using System.ComponentModel.DataAnnotations;

namespace HarvestHub.Models
{
    public class Patrimonio
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string? Nome { get; set; }
        [Required]
        public string? Categoria { get; set; }
        [Required]
        [DataType(DataType.Currency)]
        public double Valor { get; set; }
        public DateOnly DataAquisicao { get; set; }

    }
}
