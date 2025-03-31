using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HarvestHub.Models;

public partial class Estoque
{
    public int Idlocal { get; set; }

    public string Nome { get; set; } = null!;

    public string Local { get; set; } = null!;

    public int InsumoId{ get; set; }

    public required Insumo Insumo{ get; set; }

}
