using System;
using System.Linq;
using System.Threading.Tasks;
using HarvestHub.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HarvestHub.Models;
using HarvestHub.ViewModels;

namespace HarvestHub.Controllers
{
    public class RecursosHumanosController(AppDbContext context) : Controller
    {
        public async Task<IActionResult> Index()
        {
            var recursosHumanos = await context.RecursosHumanos
                .Include(rh => rh.Funcionario)
                .ToListAsync();

            return View(recursosHumanos);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var rh = await context.RecursosHumanos
                .Include(rh => rh.Funcionario)
                .Include(rh => rh.Funcionario.Contratos)
                .FirstOrDefaultAsync(m => m.Funcionario.Id == id);

            return rh == null ? NotFound() : View(rh);
        }

        public IActionResult Create() => View();

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Nome,Salario,DataAdmissao,CPF,DataNascimento,Status,CRA")] RecursosHumanosViewModel viewmodel)
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

                var rh = new RecursosHumanos
                {
                    FuncionarioId = funcionario.Id,
                    Funcionario = funcionario,
                    CRA = viewmodel.CRA
                };

                funcionario.RecursosHumanos = rh;
                context.RecursosHumanos.Add(rh);

                await context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(viewmodel);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var rh = await context.RecursosHumanos
                .Include(rh => rh.Funcionario)
                .FirstOrDefaultAsync(m => m.Funcionario.Id == id);

            if (rh == null) return NotFound();

            var model = new RecursosHumanosViewModel
            {
                FuncionarioId = rh.FuncionarioId,
                Nome = rh.Funcionario.Nome,
                Salario = rh.Funcionario.Salario,
                DataAdmissao = rh.Funcionario.DataAdmissao,
                CPF = rh.Funcionario.CPF,
                DataNascimento = rh.Funcionario.DataNascimento,
                Status = rh.Funcionario.Status,
                CRA = rh.CRA
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Nome,Salario,DataAdmissao,CPF,DataNascimento,Status,CRA")] RecursosHumanosViewModel viewmodel)
        {
            var rh = await context.RecursosHumanos
                .Include(rh => rh.Funcionario)
                .FirstOrDefaultAsync(m => m.Funcionario.Id == id);

            if (rh == null) return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    rh.Funcionario.Nome = viewmodel.Nome;
                    rh.Funcionario.Salario = viewmodel.Salario;
                    rh.Funcionario.DataAdmissao = DateTime.SpecifyKind(viewmodel.DataAdmissao, DateTimeKind.Utc);
                    rh.Funcionario.CPF = viewmodel.CPF;
                    rh.Funcionario.DataNascimento = DateTime.SpecifyKind(viewmodel.DataNascimento, DateTimeKind.Utc);
                    rh.Funcionario.Status = viewmodel.Status;
                    rh.CRA = viewmodel.CRA;

                    context.Funcionario.Update(rh.Funcionario);
                    context.RecursosHumanos.Update(rh);

                    await context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RecursosHumanosExists(rh.Funcionario.Id)) return NotFound();
                    throw;
                }

                return RedirectToAction(nameof(Index));
            }

            return View(viewmodel);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var rh = await context.RecursosHumanos
                .Include(rh => rh.Funcionario)
                .FirstOrDefaultAsync(m => m.Funcionario.Id == id);

            return rh == null ? NotFound() : View(rh);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var rh = await context.RecursosHumanos
                .Include(rh => rh.Funcionario)
                .FirstOrDefaultAsync(m => m.Funcionario.Id == id);

            if (rh != null)
            {
                context.RecursosHumanos.Remove(rh);
                context.Funcionario.Remove(rh.Funcionario);
            }

            await context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RecursosHumanosExists(int id)
        {
            return context.Funcionario.Any(e => e.Id == id && e.RecursosHumanos != null);
        }
    }
}
