using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HarvestHub.Data;
using HarvestHub.Models;

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
            return View(await _context.Insumos.ToListAsync());
        }
        
        // GET: Insumo/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Insumo/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdInsumo,TipoInsumo,CodInsumo,Volume,Custo,Descricao,Marca,GerenteDeProducaoCrea")] Insumo insumo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(insumo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(insumo);
        }
        

        // GET: Insumo/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var insumo = await _context.Insumos
                .FirstOrDefaultAsync(m => m.IdInsumo == id);
            if (insumo == null)
            {
                return NotFound();
            }

            return View(insumo);
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
