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
        [DataType(DataType.Currency)]
        [Column(TypeName = "DECIMAL(10, 2)")]
        public decimal Custo { get; set; }

        [StringLength(100)]
        public string? Descricao { get; set; }

        [Required, MaxLength(45)]
        public required string Marca { get; set; } = "";

        [Required]
        [StringLength(9)]
        public required string GerenteDeProducaoCrea { get; set; } = "";
        public required GerenteDeProducao GerenteDeProducao { get; set; }
    }
}