using Microsoft.AspNetCore.Mvc;
using GestionaleMunicipale.Services;
using GestionaleMunicipale.Models;
using System;
using System.Threading.Tasks;

namespace GestionaleMunicipale.Controllers
{
    public class AnagraficaController : Controller
    {
        private readonly GenericService<Anagrafica> _service;

        public AnagraficaController(GenericService<Anagrafica> service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var trasgressori = await _service.GetAllAsync();
            return View(trasgressori);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Anagrafica anagrafica)
        {
            if (ModelState.IsValid)
            {
                await _service.CreateAsync(anagrafica);
                return RedirectToAction("Index");
            }
            return View(anagrafica);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var trasgressore = await _service.GetByIdAsync(id);
            if (trasgressore == null) return NotFound();
            return View(trasgressore);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Guid id, Anagrafica anagrafica)
        {
            if (id != anagrafica.IdAnagrafica) return BadRequest();
            if (ModelState.IsValid)
            {
                await _service.UpdateAsync(anagrafica);
                return RedirectToAction("Index");
            }
            return View(anagrafica);
        }

        [HttpGet]
        public async Task<IActionResult> Details(Guid id)
        {
            var trasgressore = await _service.GetByIdAsync(id);
            if (trasgressore == null) return NotFound();
            return View(trasgressore);
        }
    }
}
