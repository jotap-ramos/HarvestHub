using HarvestHub.Data;
using HarvestHub.Models;
using HarvestHub.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HarvestHub.Controllers
{
    public class PatrimoniosController : Controller
    {
        private readonly HarvestHubContext _context;
        public PatrimoniosController(HarvestHubContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var patrimonio = await _context.Patrimonios.ToListAsync();
            return View(patrimonio);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create([Bind("Nome, Categoria, Valor, DataAquisicao, CREA")]CreatePatrimonioViewModel viewmodel)
        {
            if(ModelState.IsValid)
            {
                var gerente = await _context.GerenteDeProducao
                    .Include(gerente => gerente.Funcionario)
                    .FirstOrDefaultAsync(gerente => gerente.CREA == viewmodel.CREA);

                if (gerente == null)
                {
                    viewmodel.CREA = "";
                    return View(viewmodel);
                }
                
                var patrimonio = new Patrimonio
                {
                    Nome = viewmodel.Nome,
                    Categoria = viewmodel.Categoria,
                    DataAquisicao = viewmodel.DataAquisicao,
                    Valor = viewmodel.Valor,
                    GerenteDeProducaoId = gerente.FuncionarioId,
                    GerenteDeProducao = gerente
                };
                
                _context.Patrimonios.Add(patrimonio);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            
            return View(viewmodel);
        }
        public async Task<IActionResult> Edit(int id)
        {
            var patrimonio = await _context.Patrimonios
                .Include(patrimonio => patrimonio.GerenteDeProducao)
                .FirstOrDefaultAsync(x => x.Id == id);

            if (patrimonio == null)
            {
                return NotFound();
            }
            
            var viewModel = new EditPatrimonioViewModel
            {
                Nome = patrimonio.Nome,
                Categoria = patrimonio.Categoria,
                DataAquisicao = patrimonio.DataAquisicao,
                Valor = patrimonio.Valor,
                CREA = patrimonio.GerenteDeProducao.CREA,
            };
            
            return View(viewModel);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Nome, Categoria, Valor, DataAquisicao, CREA")] EditPatrimonioViewModel viewmodel)
        {
            if (ModelState.IsValid)
            {
                var patrimonio = await _context.Patrimonios.FirstOrDefaultAsync(x => x.Id == id);
                if (patrimonio == null)
                {
                    return NotFound();
                }
                
                var gerente = await _context.GerenteDeProducao
                    .Include(gerente => gerente.Funcionario)
                    .FirstOrDefaultAsync(gerente => gerente.CREA == viewmodel.CREA);

                if (gerente == null)
                {
                    viewmodel.CREA = "";
                    return View(viewmodel);
                }
                
                patrimonio.Nome = viewmodel.Nome;
                patrimonio.Categoria = viewmodel.Categoria;
                patrimonio.Valor = viewmodel.Valor;
                patrimonio.DataAquisicao = viewmodel.DataAquisicao;
                patrimonio.GerenteDeProducaoId = gerente.FuncionarioId;
                patrimonio.GerenteDeProducao = gerente;
                
                _context.Patrimonios.Update(patrimonio);
                await _context.SaveChangesAsync();
                
                return RedirectToAction("Index");
            }
            
            return View(viewmodel);
        }
        public async Task<IActionResult> Delete(int id)
        {
            var patrimonio = await _context.Patrimonios
                .Include(patrimonio => patrimonio.GerenteDeProducao)
                .FirstOrDefaultAsync(x => x.Id == id);
            
            return View(patrimonio);
        }
        [HttpPost,ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var patrimonio = await _context.Patrimonios.FindAsync(id);
            if(patrimonio != null)
            {
                _context.Patrimonios.Remove(patrimonio);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction("Index");
        }
    }
}
