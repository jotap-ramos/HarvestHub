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
    public class ProducaoController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProducaoController(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _context.Producoes.ToListAsync());
        }
        // GET: Producao/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Producao/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdProducao,Tipo,Custo,Volume")] Producao producao)
        {
            if (ModelState.IsValid)
            {
                _context.Add(producao);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Create));
            }
            return View(producao);
        }

    }
}
