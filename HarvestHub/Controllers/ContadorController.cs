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
    public class ContadorController(ApplicationContext context) : Controller
    {
        // GET: Funcionario
        public async Task<IActionResult> Index()
        {
            var contadores = await context.Contador
                .Include(c => c.Funcionario)
                .ToListAsync();

            return View(contadores);
        }

        // GET: Funcionario/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contador = await context.Contador
                .Include(c => c.Funcionario)
                .FirstOrDefaultAsync(m => m.Funcionario.Id == id);
            
            if (contador == null)
            {
                return NotFound();
            }

            return View(contador);
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
        public async Task<IActionResult> Create([Bind("Nome,Salario,DataAdmissao,CPF,DataNascimento,Status,CRC")] ContadorViewModel viewmodel)
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
                    Status = viewmodel.Status
                };
                
                context.Funcionario.Add(funcionario);
                var contador = new Contador
                {
                    FuncionarioId = funcionario.Id,
                    Funcionario = funcionario,
                    CRC = viewmodel.CRC
                };
                funcionario.Contador = contador;

                context.Contador.Add(contador);
                await context.SaveChangesAsync();

                return RedirectToAction("Index");
            }
            
            return View(viewmodel);
        }

        // GET: Funcionario/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contador = await context.Contador
                .Include(c => c.Funcionario)
                .FirstOrDefaultAsync(m => m.Funcionario.Id == id);
            
            if (contador == null)
            {
                return NotFound();
            }

            var model = new ContadorViewModel
            {
                FuncionarioId = contador.FuncionarioId,
                Nome = contador.Funcionario.Nome,
                Salario = contador.Funcionario.Salario,
                DataAdmissao = contador.Funcionario.DataAdmissao,
                CPF = contador.Funcionario.CPF,
                DataNascimento = contador.Funcionario.DataNascimento,
                Status = contador.Funcionario.Status,
                CRC = contador.CRC
            };
            
            return View(model);
        }

        // POST: Funcionario/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Nome,Salario,DataAdmissao,CPF,DataNascimento,Status,CRC")] ContadorViewModel viewmodel)
        {
            var contador = await context.Contador
                .Include(c => c.Funcionario)
                .FirstOrDefaultAsync(m => m.Funcionario.Id == id);
            
            if (contador == null)
            {
                return NotFound();
            }
            
            Console.WriteLine("funcione nmrl 0");
            if (ModelState.IsValid)
            {
                Console.WriteLine("funcione nmrl 1");
                try
                {
                    contador.Funcionario.Nome = viewmodel.Nome;
                    contador.Funcionario.Salario = viewmodel.Salario;
                    contador.Funcionario.DataAdmissao = DateTime.SpecifyKind(viewmodel.DataAdmissao, DateTimeKind.Utc);
                    contador.Funcionario.CPF = viewmodel.CPF;
                    contador.Funcionario.DataNascimento = DateTime.SpecifyKind(viewmodel.DataNascimento, DateTimeKind.Utc);
                    contador.Funcionario.Status = viewmodel.Status;
                    contador.CRC = viewmodel.CRC;

                    context.Funcionario.Update(contador.Funcionario);
                    context.Contador.Update(contador);
                    
                    await context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ContadorExists(contador.Funcionario.Id))
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

        // GET: Funcionario/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contador = await context.Contador
                .Include(c => c.Funcionario)
                .FirstOrDefaultAsync(m => m.Funcionario.Id == id);
            
            if (contador == null)
            {
                return NotFound();
            }
            
            return View(contador);
        }

        // POST: Funcionario/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var contador = await context.Contador
                .Include(c => c.Funcionario)
                .FirstOrDefaultAsync(m => m.Funcionario.Id == id);
            
            if (contador != null)
            {
                context.Contador.Remove(contador);
                context.Funcionario.Remove(contador.Funcionario);
            }

            await context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ContadorExists(int id)
        {
            return context.Funcionario.Any(e => e.Id == id && e.Contador != null);
        }
    }
}
