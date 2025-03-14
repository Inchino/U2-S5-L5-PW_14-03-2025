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
    [Route("Verbale")]
    public class VerbaleController : Controller
    {
        private readonly GenericService<Verbale> _service;

        public VerbaleController(GenericService<Verbale> service)
        {
            _service = service;
        }

        [HttpGet("")]
        public async Task<IActionResult> Index()
        {
            var verbali = await _service.GetAllAsync();

            var viewModelList = verbali.Select(v => new VerbaleViewModel
            {
                IdVerbale = v.IdVerbale,
                IdAnagrafica = v.IdAnagrafica,
                DataViolazione = v.DataViolazione,
                IndirizzoViolazione = v.IndirizzoViolazione,
                NominativoAgente = v.NominativoAgente,
                DataTrascrizioneVerbale = v.DataTrascrizioneVerbale,
                Importo = v.Importo
            }).ToList();

            return View(viewModelList);
        }

        [HttpGet("Create")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create(VerbaleViewModel verbaleViewModel)
        {
            if (ModelState.IsValid)
            {
                var verbale = new Verbale
                {
                    IdVerbale = Guid.NewGuid(),
                    IdAnagrafica = verbaleViewModel.IdAnagrafica,
                    DataViolazione = verbaleViewModel.DataViolazione,
                    IndirizzoViolazione = verbaleViewModel.IndirizzoViolazione,
                    NominativoAgente = verbaleViewModel.NominativoAgente,
                    DataTrascrizioneVerbale = verbaleViewModel.DataTrascrizioneVerbale,
                    Importo = verbaleViewModel.Importo
                };

                await _service.CreateAsync(verbale);
                return RedirectToAction("Index");
            }
            return View(verbaleViewModel);
        }

        [HttpGet("Details/{id}")]
        public async Task<IActionResult> Details(Guid id)
        {
            var verbale = await _service.GetByIdAsync(id);
            if (verbale == null) return NotFound();

            var viewModel = new VerbaleViewModel
            {
                IdVerbale = verbale.IdVerbale,
                IdAnagrafica = verbale.IdAnagrafica,
                DataViolazione = verbale.DataViolazione,
                IndirizzoViolazione = verbale.IndirizzoViolazione,
                NominativoAgente = verbale.NominativoAgente,
                DataTrascrizioneVerbale = verbale.DataTrascrizioneVerbale,
                Importo = verbale.Importo
            };

            return View(viewModel);
        }
    }
}
