using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HarvestHub.Models
{
    [Table("DESPESA")]
    public class Despesa
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("idDESPESA")]
        public int IdDespesa { get; set; }

        [Required]
        [StringLength(45)]
        [Column("TIPO")]
        public string Tipo { get; set; } // Removido "required" (use [Required] para compatibilidade)

        [Required]
        [Column("VALOR", TypeName = "decimal(10,2)")] // Tipo igual ao PostgreSQL
        public decimal Valor { get; set; }

        [Required]
        [Column("DATA_REGISTRO", TypeName = "DATE")] // Tipo DATE (sem hora)
        public DateTime DataRegistro { get; set; }

        [Column("DATA_PAGAMENTO", TypeName = "DATE")] // Tipo DATE (nullable)
        public DateTime? DataPagamento { get; set; }
    }
}