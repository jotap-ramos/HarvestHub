using System.ComponentModel.DataAnnotations;

namespace HarvestHub.Models
{
    public class Patrimonio
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string? Nome { get; set; }
        [Required]
        public string? Categoria { get; set; }
        [Required]
        public decimal? Valor { get; set; }

    }
}
