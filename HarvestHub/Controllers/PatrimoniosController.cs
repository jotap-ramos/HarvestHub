using HarvestHub.Data;
using HarvestHub.Models;
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
        public async Task<IActionResult> Create([Bind("Id, Nome, Categoria, Valor, DataAquisicao")]Patrimonio patrimonio)
        {
            if(ModelState.IsValid)
            {
                _context.Patrimonios.Add(patrimonio);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(patrimonio);
        }
        public async Task<IActionResult> Edit(int id)
        {
            var patrimonio = await _context.Patrimonios.FirstOrDefaultAsync(x => x.Id == id);
            return View(patrimonio);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id, Nome, Categoria, Valor, DataAquisicao")] Patrimonio patrimonio)
        {
            if (ModelState.IsValid)
            {
                _context.Update(patrimonio);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(patrimonio);
        }
        public async Task<IActionResult> Delete(int id)
        {
            var patrimonio = await _context.Patrimonios.FirstOrDefaultAsync(x => x.Id == id);
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
