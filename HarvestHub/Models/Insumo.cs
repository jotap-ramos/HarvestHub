using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HarvestHub.Models
{
    [Table("INSUMO")]
    public class Insumo
    {
        [Key]
        public int IdInsumo { get; set; }

        [Required]
        [StringLength(45)]
        public string TipoInsumo { get; set; }  = "";

        [Required]
        [StringLength(45)]
        public string CodInsumo { get; set; }  = "";

        [Required]
        [StringLength(45)]
        public string Volume { get; set; }  = "";

        [Required]
        public decimal Custo { get; set; }

        [StringLength(100)]
        public string? Descricao { get; set; }

        [Required]
        [StringLength(45)]
        public string Marca { get; set; } = "";

        [Required]
        [StringLength(9)]
        public string GerenteDeProducaoCrea { get; set; } = "";
    }
}