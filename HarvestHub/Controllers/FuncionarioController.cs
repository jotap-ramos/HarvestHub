using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HarvestHub.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HarvestHub.Models;
using HarvestHub.ViewModels;

namespace HarvestHub.Controllers
{
    public class FuncionarioController(AppDbContext context) : Controller
    {
        // GET: Funcionario
        public async Task<IActionResult> Index()
        {
            return View(await context.Funcionario.ToListAsync());
        }

        // GET: Funcionario/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var funcionario = await context.Funcionario
                .Include(funcionario => funcionario.Contratos)
                .FirstOrDefaultAsync(m => m.Id == id);
            
            if (funcionario == null)
            {
                return NotFound();
            }

            return View(funcionario);
        }

        // GET: Funcionario/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Funcionario/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Nome,Salario,DataAdmissao,CPF,DataNascimento,Status")] CreateFuncionarioViewModel viewModel)
        {
            foreach (var error in ModelState.Values.SelectMany(v => v.Errors))
            {
                Console.WriteLine(error.ErrorMessage);
            }
            
            if (ModelState.IsValid)
            {
                var funcionario = new Funcionario
                {
                    Nome = viewModel.Nome,
                    Salario = viewModel.Salario,
                    DataAdmissao = viewModel.DataAdmissao,
                    CPF = viewModel.CPF,
                    DataNascimento = viewModel.DataNascimento,
                    Status = viewModel.Status,
                    Contratos = new List<Contrato>()
                };
                
                context.Funcionario.Add(funcionario);
                await context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(viewModel);
        }

        // GET: Funcionario/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var funcionario = await context.Funcionario.FindAsync(id);
            if (funcionario == null)
            {
                return NotFound();
            }
            return View(funcionario);
        }

        // POST: Funcionario/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,Salario,DataAdmissao,CPF,DataNascimento,Status")] Funcionario funcionario)
        {
            if (id != funcionario.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    context.Update(funcionario);
                    await context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FuncionarioExists(funcionario.Id))
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
            return View(funcionario);
        }

        // GET: Funcionario/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var funcionario = await context.Funcionario
                .FirstOrDefaultAsync(m => m.Id == id);
            if (funcionario == null)
            {
                return NotFound();
            }

            return View(funcionario);
        }

        // POST: Funcionario/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var funcionario = await context.Funcionario.FindAsync(id);
            if (funcionario != null)
            {
                if (funcionario.Contador != null) context.Contador.Remove(funcionario.Contador);
                if (funcionario.GerenteDeProducao != null) context.GerenteDeProducao.Remove(funcionario.GerenteDeProducao);
                if (funcionario.RecursosHumanos != null) context.RecursosHumanos.Remove(funcionario.RecursosHumanos);
                
                context.Funcionario.Remove(funcionario);
            }

            await context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FuncionarioExists(int id)
        {
            return context.Funcionario.Any(e => e.Id == id);
        }
    }
}
