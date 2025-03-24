using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HarvestHub.Models;

[Table("RECEITA")]
public class Receita
{
    [Key]
    [Column("idRECEITA")]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    [Required, MaxLength(45)]
    [Column("TIPO")]
    public required string Tipo { get; set; }
    [Required]
    [DataType(DataType.Currency)]
    [Column(TypeName = "DECIMAL(10, 2)")]
    public decimal Valor { get; set; }
    private DateTime _dataRegistro;
    [Required, DataType(DataType.Date), Column("DATA_REGISTRO", TypeName = "DATE"), DisplayName("Data de Registro")]
    public DateTime DataRegistro
    {
        get => _dataRegistro;
        set => _dataRegistro = DateTime.SpecifyKind(value, DateTimeKind.Utc);
    }
    
    [Column("CONTADOR_FUNCIONARIO_idFUNCIONARIO")]
    public int ContadorFuncionarioId { get; set; }
    
    [ForeignKey("ContadorFuncionarioId")]
    public required Contador Contador { get; set; }
}