using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HarvestHub.Models
{
    [Table("RECEITA")]
    public class Receita
    {
        [Key]
        [Column("idRECEITA")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [Column("TIPO")]
        [StringLength(45)]
        public string Tipo { get; set; }

        [Required]
        [Column(TypeName = "decimal(10,2)")]
        public decimal Valor { get; set; }

        [Required]
        [Column("DATA_REGISTRO", TypeName = "DATE")] // Alinhado com o PostgreSQL
        public DateTime DataRegistro { get; set; }

        [Required]
        [Column("CONTADOR_FUNCIONARIO_idFUNCIONARIO")] // Nome da coluna corrigido
        public int ContadorFuncionarioId { get; set; }

        [ForeignKey("ContadorFuncionarioId")]
        public virtual Contador Contador { get; set; }
    }
}