using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using HarvestHub.Models;
using HarvestHub.Data;

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