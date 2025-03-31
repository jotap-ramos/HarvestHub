using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HarvestHub.Data;
using HarvestHub.Models;
using HarvestHub.ViewModels;

namespace HarvestHub.Controllers
{
    public class InsumoController : Controller
    {
        private readonly HarvestHubContext _context;

        public InsumoController(HarvestHubContext context)
        {
            _context = context;
        }
        
        // GET: Insumo
        public async Task<IActionResult> Index()
        {
            var insumos = await _context.Insumos
                .Include(insumo => insumo.GerenteDeProducao)
                .ToListAsync();
            
            
            return View(insumos.ConvertAll(insumo => new IndexInsumoViewModel
            {
                Tipo = insumo.TipoInsumo,
                Codigo = insumo.CodInsumo,
                Descricao = insumo.Descricao,
                Crea = insumo.GerenteDeProducao.CREA,
                Custo = insumo.Custo,
                Id = insumo.IdInsumo,
                Marca = insumo.Marca,
                Volume = insumo.Volume
            }));
        }
        
        // GET: Insumo/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Insumo/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Tipo,Codigo,Volume,Custo,Descricao,Marca,Crea")] CreateInsumoViewModel viewmodel)
        {
            foreach (var error in ModelState.Values.SelectMany(v => v.Errors))
            {
                Console.WriteLine(error.ErrorMessage);
            }
            
            if (ModelState.IsValid)
            {
                var gerente = await _context.GerenteDeProducao
                    .Include(gerente => gerente.Funcionario)
                    .Include(gerente => gerente.Insumos)
                    .FirstOrDefaultAsync(gerente => gerente.CREA == viewmodel.Crea);
                
                if (gerente == null)
                {
                    viewmodel.Crea = "";
                    return View(viewmodel);
                }
                
                var insumo = new Insumo
                {
                    TipoInsumo = viewmodel.Tipo,
                    CodInsumo = viewmodel.Codigo,
                    Volume = viewmodel.Volume,
                    Custo = viewmodel.Custo,
                    Descricao = viewmodel.Descricao,
                    Marca = viewmodel.Marca,
                    GerenteDeProducaoId = gerente.Funcionario.Id,
                    GerenteDeProducao = gerente,
                    Estoques = new List<Estoque>()
                };
                
                _context.Insumos.Add(insumo);
                gerente.Insumos.Add(insumo);
                
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(viewmodel);
        }
        

        // GET: Insumo/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var insumo = await _context.Insumos
                .Include(insumo => insumo.GerenteDeProducao)
                .FirstOrDefaultAsync(m => m.IdInsumo == id);
            
            if (insumo == null)
            {
                return NotFound();
            }

            var viewmodel = new DeleteInsumoViewModel
            {
                Tipo = insumo.TipoInsumo,
                Codigo = insumo.CodInsumo,
                Volume = insumo.Volume,
                Custo = insumo.Custo,
                Descricao = insumo.Descricao,
                Marca = insumo.Marca,
                Crea = insumo.GerenteDeProducao.CREA
            };

            return View(viewmodel);
        }

        // POST: Insumo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var insumo = await _context.Insumos.FindAsync(id);
            if (insumo != null)
            {
                _context.Insumos.Remove(insumo);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        
    }
}
