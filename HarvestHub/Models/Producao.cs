using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HarvestHub.Models
{
    [Table("PRODUCAO")]
    public class Producao
    {
        [Key]
        public int IdProducao { get; set; }

        [Required]
        [StringLength(20)]
        public string Tipo { get; set; } = "";

        [Required]
        public decimal Custo { get; set; }

        [Required]
        [StringLength(20)]
        public string Volume { get; set; }  = "";
    }
}
