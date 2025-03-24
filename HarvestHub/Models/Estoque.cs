using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HarvestHub.Models
{
    [Table("ESTOQUE")]
    public class Estoque
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("idLOCAL")]
        public int IdLocal { get; set; }

        [Required]
        [StringLength(45)]
        [Column("NOME")]
        public required string Nome { get; set; }

        [Required]
        [StringLength(45)]
        [Column("LOCAL")]
        public required string Local { get; set; }

        [Required]
        [Column("INSUMO_idINSUMO")] // Nome da coluna igual ao script
        public int InsumoId { get; set; }

        [ForeignKey("InsumoId")]
        public virtual Insumo Insumo { get; set; }
    }
}