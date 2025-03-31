using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HarvestHub.Models;

public partial class Estoque
{
    [Key]
    public int Idlocal { get; set; }

    public string Nome { get; set; } = null!;

    public string Local { get; set; } = null!;

    public int InsumoId{ get; set; }

    [ForeignKey("InsumoId")]
    public required Insumo Insumo{ get; set; }

}
