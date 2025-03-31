using HarvestHub.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HarvestHub.Models;
using HarvestHub.ViewModels;

namespace HarvestHub.Controllers
{
    public class GerenteDeProducaoController(AppDbContext context) : Controller
    {
        // GET: GerenteDeProducao
        public async Task<IActionResult> Index()
        {
            var gerentes = await context.GerenteDeProducao
                .Include(g => g.Funcionario)
                .ToListAsync();

            return View(gerentes);
        }

        // GET: GerenteDeProducao/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gerente = await context.GerenteDeProducao
                .Include(g => g.Funcionario)
                .Include(g => g.Funcionario.Contratos)
                .Include(g => g.Insumos)
                .Include(g => g.Patrimonios)
                .FirstOrDefaultAsync(m => m.Funcionario.Id == id);
            
            if (gerente == null)
            {
                return NotFound();
            }

            return View(gerente);
        }

        // GET: GerenteDeProducao/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: GerenteDeProducao/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Nome,Salario,DataAdmissao,CPF,DataNascimento,Status,CREA")] GerenteDeProducaoViewModel viewmodel)
        {
            if (ModelState.IsValid)
            {
                var funcionario = new Funcionario
                {
                    Nome = viewmodel.Nome,
                    Salario = viewmodel.Salario,
                    DataAdmissao = DateTime.SpecifyKind(viewmodel.DataAdmissao, DateTimeKind.Utc),
                    CPF = viewmodel.CPF,
                    DataNascimento = DateTime.SpecifyKind(viewmodel.DataNascimento, DateTimeKind.Utc),
                    Status = viewmodel.Status,
                    Contratos = new List<Contrato>()
                };
                
                context.Funcionario.Add(funcionario);
                var gerente = new GerenteDeProducao
                {
                    FuncionarioId = funcionario.Id,
                    Funcionario = funcionario,
                    CREA = viewmodel.CREA,
                    Patrimonios = new List<Patrimonio>(),
                    Insumos = new List<Insumo>()
                };
                funcionario.GerenteDeProducao = gerente;

                context.GerenteDeProducao.Add(gerente);
                await context.SaveChangesAsync();

                return RedirectToAction("Index");
            }
            
            return View(viewmodel);
        }

        // GET: GerenteDeProducao/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gerente = await context.GerenteDeProducao
                .Include(g => g.Funcionario)
                .FirstOrDefaultAsync(m => m.Funcionario.Id == id);
            
            if (gerente == null)
            {
                return NotFound();
            }

            var model = new GerenteDeProducaoViewModel
            {
                FuncionarioId = gerente.FuncionarioId,
                Nome = gerente.Funcionario.Nome,
                Salario = gerente.Funcionario.Salario,
                DataAdmissao = gerente.Funcionario.DataAdmissao,
                CPF = gerente.Funcionario.CPF,
                DataNascimento = gerente.Funcionario.DataNascimento,
                Status = gerente.Funcionario.Status,
                CREA = gerente.CREA
            };
            
            return View(model);
        }

        // POST: GerenteDeProducao/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Nome,Salario,DataAdmissao,CPF,DataNascimento,Status,CREA")] GerenteDeProducaoViewModel viewmodel)
        {
            var gerente = await context.GerenteDeProducao
                .Include(g => g.Funcionario)
                .FirstOrDefaultAsync(m => m.Funcionario.Id == id);
            
            if (gerente == null)
            {
                return NotFound();
            }
            
            if (ModelState.IsValid)
            {
                try
                {
                    gerente.Funcionario.Nome = viewmodel.Nome;
                    gerente.Funcionario.Salario = viewmodel.Salario;
                    gerente.Funcionario.DataAdmissao = DateTime.SpecifyKind(viewmodel.DataAdmissao, DateTimeKind.Utc);
                    gerente.Funcionario.CPF = viewmodel.CPF;
                    gerente.Funcionario.DataNascimento = DateTime.SpecifyKind(viewmodel.DataNascimento, DateTimeKind.Utc);
                    gerente.Funcionario.Status = viewmodel.Status;
                    gerente.CREA = viewmodel.CREA;

                    context.Funcionario.Update(gerente.Funcionario);
                    context.GerenteDeProducao.Update(gerente);
                    
                    await context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GerenteDeProducaoExists(gerente.Funcionario.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            
            return View(viewmodel);
        }

        // GET: GerenteDeProducao/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gerente = await context.GerenteDeProducao
                .Include(g => g.Funcionario)
                .FirstOrDefaultAsync(m => m.Funcionario.Id == id);
            
            if (gerente == null)
            {
                return NotFound();
            }
            
            return View(gerente);
        }

        // POST: GerenteDeProducao/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var gerente = await context.GerenteDeProducao
                .Include(g => g.Funcionario)
                .FirstOrDefaultAsync(m => m.Funcionario.Id == id);
            
            if (gerente != null)
            {
                context.GerenteDeProducao.Remove(gerente);
                context.Funcionario.Remove(gerente.Funcionario);
            }

            await context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GerenteDeProducaoExists(int id)
        {
            return context.Funcionario.Any(e => e.Id == id && e.GerenteDeProducao != null);
        }
    }
}
