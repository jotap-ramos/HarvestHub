using Microsoft.AspNetCore.Mvc;
using HarvestHub.Data;
using HarvestHub.Models;
using HarvestHub.ViewModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HarvestHub.Controllers
{
    public class GerenciarBalancoController : Controller
    {
        private readonly AppDbContext _context;

        public GerenciarBalancoController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View(); // Renderiza a tela intermediária com os botões
        }

        // GET: GerenciarBalanco/RegistrarDespesa
        public IActionResult RegistrarDespesa()
        {
            return View();
        }

        // POST: GerenciarBalanco/RegistrarDespesa
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RegistrarDespesa([Bind("Tipo, Valor, DataRegistro, DataPagamento")]
            CreateDespesaViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var despesa = new Despesa
                {
                    Tipo = viewModel.Tipo,
                    Valor = viewModel.Valor,
                    DataRegistro = viewModel.DataRegistro, // Campo controlado pelo sistema
                    DataPagamento = viewModel.DataPagamento
                };

                _context.Despesa.Add(despesa);
                await _context.SaveChangesAsync();
                TempData["SuccessMessage"] = "Despesa registrada com sucesso!";
                return RedirectToAction(nameof(ListarRegistros));
            }

            foreach (var error in ModelState.Values.SelectMany(v => v.Errors))
            {
                Console.WriteLine(error.ErrorMessage); // Log de erros
            }

            return View(viewModel);
        }

        // GET: GerenciarBalanco/CadastrarReceita
        public IActionResult CadastrarReceita()
        {
            // Carrega os contadores com os funcionários relacionados
            var contadores = _context.Contador
                .Include(c => c.Funcionario) // Garante que o Funcionario é carregado
                .ToList();

            if (contadores == null || !contadores.Any())
            {
                TempData["ErrorMessage"] = "Nenhum contador cadastrado. Cadastre um contador primeiro.";
                return RedirectToAction(nameof(Index));
            }

            // Usa Funcionario.Nome para exibir no dropdown
            ViewBag.Contadores = new SelectList(
                contadores,
                "FuncionarioId",
                "Funcionario.Nome" // <--- Aqui está a correção
            );
            return View();
        }

        // POST: GerenciarBalanco/CadastrarReceita
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CadastrarReceita([Bind("Tipo,Valor,ContadorFuncionarioId")] CreateReceitaViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                // Busca o Contador no banco de dados
                var contador = await _context.Contador
                    .FirstOrDefaultAsync(c => c.FuncionarioId == viewModel.ContadorFuncionarioId);

                if (contador == null)
                {
                    ModelState.AddModelError("ContadorFuncionarioId", "Contador não encontrado!");
                    return View(viewModel);
                }

                var receita = new Receita
                {
                    Tipo = viewModel.Tipo,
                    Valor = viewModel.Valor,
                    ContadorFuncionarioId = viewModel.ContadorFuncionarioId,
                    Contador = contador, // Propriedade obrigatória inicializada
                    DataRegistro = DateTime.UtcNow // Removi do ViewModel (definido pelo sistema)
                };

                _context.Receita.Add(receita);
                await _context.SaveChangesAsync();
                TempData["SuccessMessage"] = "Receita cadastrada com sucesso!";
                return RedirectToAction(nameof(ListarRegistros));
            }
            return View(viewModel);
        }

        // GET: GerenciarBalanco/ListarRegistros
        public async Task<IActionResult> ListarRegistros()
        {
            var despesas = await _context.Despesa.ToListAsync();
            var receitas = await _context.Receita.ToListAsync();

            return View(new BalancoViewModel
            {
                Despesas = despesas,
                Receitas = receitas
            });
        }
    }
}