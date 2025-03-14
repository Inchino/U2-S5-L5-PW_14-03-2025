using Microsoft.AspNetCore.Mvc;
using GestionaleMunicipale.Services;
using GestionaleMunicipale.Models;
using GestionaleMunicipale.ViewModels;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace GestionaleMunicipale.Controllers
{
    [Route("Anagrafica")]
    public class AnagraficaController : Controller
    {
        private readonly GenericService<Anagrafica> _service;

        public AnagraficaController(GenericService<Anagrafica> service)
        {
            _service = service;
        }

        [HttpGet("")]
        public async Task<IActionResult> Index()
        {
            var trasgressori = await _service.GetAllAsync();
            var viewModelList = trasgressori.Select(a => new AnagraficaViewModel
            {
                IdAnagrafica = a.IdAnagrafica,
                Cognome = a.Cognome,
                Nome = a.Nome,
                Indirizzo = a.Indirizzo,
                Citta = a.Citta,
                CAP = a.CAP,
                CF = a.CF
            }).ToList();

            return View(viewModelList);
        }

        [HttpGet("Create")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create(AnagraficaViewModel anagraficaViewModel)
        {
            if (ModelState.IsValid)
            {
                var anagrafica = new Anagrafica
                {
                    IdAnagrafica = Guid.NewGuid(),
                    Cognome = anagraficaViewModel.Cognome,
                    Nome = anagraficaViewModel.Nome,
                    Indirizzo = anagraficaViewModel.Indirizzo,
                    Citta = anagraficaViewModel.Citta,
                    CAP = anagraficaViewModel.CAP,
                    CF = anagraficaViewModel.CF
                };

                await _service.CreateAsync(anagrafica);
                return RedirectToAction("Index");
            }
            return View(anagraficaViewModel);
        }

        [HttpGet("Edit/{id}")]
        public async Task<IActionResult> Edit(Guid id)
        {
            var trasgressore = await _service.GetByIdAsync(id);
            if (trasgressore == null) return NotFound();

            var viewModel = new AnagraficaViewModel
            {
                IdAnagrafica = trasgressore.IdAnagrafica,
                Cognome = trasgressore.Cognome,
                Nome = trasgressore.Nome,
                Indirizzo = trasgressore.Indirizzo,
                Citta = trasgressore.Citta,
                CAP = trasgressore.CAP,
                CF = trasgressore.CF
            };

            return View(viewModel);
        }

        [HttpPost("Edit/{id}")]
        public async Task<IActionResult> Edit(Guid id, AnagraficaViewModel anagraficaViewModel)
        {
            if (id != anagraficaViewModel.IdAnagrafica) return BadRequest();

            if (ModelState.IsValid)
            {
                var anagrafica = new Anagrafica
                {
                    IdAnagrafica = anagraficaViewModel.IdAnagrafica,
                    Cognome = anagraficaViewModel.Cognome,
                    Nome = anagraficaViewModel.Nome,
                    Indirizzo = anagraficaViewModel.Indirizzo,
                    Citta = anagraficaViewModel.Citta,
                    CAP = anagraficaViewModel.CAP,
                    CF = anagraficaViewModel.CF
                };

                await _service.UpdateAsync(anagrafica);
                return RedirectToAction("Index");
            }
            return View(anagraficaViewModel);
        }

        [HttpGet("Details/{id}")]
        public async Task<IActionResult> Details(Guid id)
        {
            var trasgressore = await _service.GetByIdAsync(id);
            if (trasgressore == null) return NotFound();

            var viewModel = new AnagraficaViewModel
            {
                IdAnagrafica = trasgressore.IdAnagrafica,
                Cognome = trasgressore.Cognome,
                Nome = trasgressore.Nome,
                Indirizzo = trasgressore.Indirizzo,
                Citta = trasgressore.Citta,
                CAP = trasgressore.CAP,
                CF = trasgressore.CF
            };

            return View(viewModel);
        }
    }
}
