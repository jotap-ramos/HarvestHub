using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using HarvestHub.Models;

namespace HarvestHub.Controllers
{
    public class GerenciarBalancoController : Controller
    {
        private readonly AppDbContext _context;

        public GerenciarBalancoController(AppDbContext context)
        {
            _context = context;
        }

        // Ação para exibir o formulário (GET)
        public IActionResult Create()
        {
            return View();
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Despesa despesa)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    despesa.DataRegistro = DateTime.Now.Date; // Define a data atual (opcional)
                    _context.Despesas.Add(despesa);
                    await _context.SaveChangesAsync();
                    
                    TempData["Success"] = "Despesa cadastrada com sucesso!";
                    return RedirectToAction(nameof(Create));
                }
                catch (Exception ex)
                {
                    // Log do erro (exemplo simples)
                    ModelState.AddModelError("", $"Erro ao salvar: {ex.Message}");
                }
            }
            return View(despesa);
        }
    }
}