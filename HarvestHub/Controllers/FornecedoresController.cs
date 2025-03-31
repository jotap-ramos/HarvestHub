using HarvestHub.Data;
using HarvestHub.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HarvestHub.Controllers
{
    public class FornecedoresController : Controller
    {
        private readonly HarvestHubContext _context;
        public FornecedoresController(HarvestHubContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var fornecedor = await _context.Fornecedores.ToListAsync();
            return View(fornecedor);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create([Bind("Id, Nome, CNPJ, Telefone, Email, Contratos")] Fornecedor fornecedor)
        {
            if (ModelState.IsValid)
            {
                _context.Fornecedores.Add(fornecedor);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(fornecedor);
        }
        public async Task<IActionResult> Edit(int id)
        {
            var fornecedor = await _context.Fornecedores.FirstOrDefaultAsync(x => x.Id == id);
            return View(fornecedor);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id, Nome, CNPJ, Telefone, Email, Contratos")] Fornecedor fornecedor)
        {
            if (ModelState.IsValid)
            {
                _context.Update(fornecedor);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(fornecedor);
        }
        public async Task<IActionResult> Delete(int id)
        {
            var fornecedor = await _context.Fornecedores.FirstOrDefaultAsync(x => x.Id == id);
            return View(fornecedor);
        }
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var fornecedor = await _context.Fornecedores.FindAsync(id);
            if (fornecedor != null)
            {
                _context.Fornecedores.Remove(fornecedor);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction("Index");
        }
    }
}
