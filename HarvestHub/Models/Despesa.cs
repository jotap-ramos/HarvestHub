using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HarvestHub.Models;

public partial class Despesa
{
    public int Iddespesa { get; set; }

    public string Tipo { get; set; } = null!;

    public decimal Valor { get; set; }

    public DateTime DataRegistro { get; set; }

    private DateTime _dataPagamento;
    [Required, DataType(DataType.Date), Column(TypeName = "date"), DisplayName("Data de Pagamento")]
    public required DateTime DataPagamento
    {
        get => _dataPagamento;
        set => _dataPagamento = DateTime.SpecifyKind(value, DateTimeKind.Utc);
    }
}
