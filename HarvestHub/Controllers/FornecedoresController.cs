using HarvestHub.Data;
using HarvestHub.Models;
using HarvestHub.ViewModels;
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
        public async Task<IActionResult> Create([Bind("Nome, CNPJ, Telefone, Email")] CreateFornecedorViewModel viewmodel)
        {
            if (ModelState.IsValid)
            {
                var fornecedor = new Fornecedor
                {
                    Nome = viewmodel.Nome,
                    CNPJ = viewmodel.CNPJ,
                    Telefone = viewmodel.Telefone,
                    Email = viewmodel.Email,
                    Contratos = new List<Contrato>()
                };
                
                _context.Fornecedores.Add(fornecedor);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            
            return View(viewmodel);
        }
        public async Task<IActionResult> Edit(int id)
        {
            var fornecedor = await _context.Fornecedores
                .FirstOrDefaultAsync(x => x.Id == id);

            if (fornecedor == null)
            {
                return NotFound();
            }

            var viewmodel = new EditFornecedorViewModel
            {
                Nome = fornecedor.Nome,
                CNPJ = fornecedor.CNPJ,
                Telefone = fornecedor.Telefone,
                Email = fornecedor.Email
            };
            
            return View(viewmodel);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Nome, CNPJ, Telefone, Email")] EditFornecedorViewModel viewmodel)
        {
            if (ModelState.IsValid)
            {
                var fornecedor = await _context.Fornecedores.FirstOrDefaultAsync(x => x.Id == id);
                if (fornecedor == null)
                {
                    return NotFound();
                }
                
                fornecedor.Nome = viewmodel.Nome;
                fornecedor.CNPJ = viewmodel.CNPJ;
                fornecedor.Telefone = viewmodel.Telefone;
                fornecedor.Email = viewmodel.Email;
                
                _context.Update(fornecedor);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(viewmodel);
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
