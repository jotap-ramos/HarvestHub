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
        public decimal Valor { get; set; }
        
        [Required]
        public DateOnly DataAquisicao { get; set; }
        
        public required string GerenteDeProducaoCrea { get; set; }
        public required GerenteDeProducao GerenteDeProducao { get; set; }
    }
}