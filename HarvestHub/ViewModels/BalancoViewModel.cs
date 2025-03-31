using HarvestHub.Models;

namespace HarvestHub.ViewModels
{
    public class BalancoViewModel
    {
        public required List<Despesa> Despesas { get; set; }
        public required List<Receita> Receitas { get; set; }
    }
}
