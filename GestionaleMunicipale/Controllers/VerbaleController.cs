using Microsoft.AspNetCore.Mvc;
using GestionaleMunicipale.Services;
using GestionaleMunicipale.Models;
using System;
using System.Threading.Tasks;

namespace GestionaleMunicipale.Controllers
{
    public class VerbaleController : Controller
    {
        private readonly GenericService<Verbale> _service;

        public VerbaleController(GenericService<Verbale> service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var verbali = await _service.GetAllAsync();
            return View(verbali);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Verbale verbale)
        {
            if (ModelState.IsValid)
            {
                await _service.CreateAsync(verbale);
                return RedirectToAction("Index");
            }
            return View(verbale);
        }

        [HttpGet]
        public async Task<IActionResult> Details(Guid id)
        {
            var verbale = await _service.GetByIdAsync(id);
            if (verbale == null) return NotFound();
            return View(verbale);
        }
    }
}
