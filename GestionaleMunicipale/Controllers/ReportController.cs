using Microsoft.AspNetCore.Mvc;
using GestionaleMunicipale.Services.Report;
using GestionaleMunicipale.ViewModels;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace GestionaleMunicipale.Controllers
{
    [Route("Reports")]
    public class ReportsController : Controller
    {
        private readonly VerbaliPerTrasgressoreService _verbaliPerTrasgressoreService;
        private readonly PuntiDecurtatiPerTrasgressoreService _puntiDecurtatiService;
        private readonly VerbaliSopra10PuntiService _verbaliSopra10Service;
        private readonly VerbaliSopra400EuroService _verbaliSopra400Service;

        public ReportsController(
            VerbaliPerTrasgressoreService verbaliPerTrasgressoreService,
            PuntiDecurtatiPerTrasgressoreService puntiDecurtatiService,
            VerbaliSopra10PuntiService verbaliSopra10Service,
            VerbaliSopra400EuroService verbaliSopra400Service)
        {
            _verbaliPerTrasgressoreService = verbaliPerTrasgressoreService;
            _puntiDecurtatiService = puntiDecurtatiService;
            _verbaliSopra10Service = verbaliSopra10Service;
            _verbaliSopra400Service = verbaliSopra400Service;
        }

        [HttpGet("")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("VerbaliPerTrasgressore")]
        public async Task<IActionResult> VerbaliPerTrasgressore()
        {
            var report = await _verbaliPerTrasgressoreService.GetVerbaliPerTrasgressoreAsync();
            return View(report);
        }

        [HttpGet("PuntiDecurtatiPerTrasgressore")]
        public async Task<IActionResult> PuntiDecurtatiPerTrasgressore()
        {
            var report = await _puntiDecurtatiService.GetPuntiDecurtatiPerTrasgressoreAsync();
            return View(report);
        }

        [HttpGet("VerbaliSopra10Punti")]
        public async Task<IActionResult> VerbaliSopra10Punti()
        {
            var report = await _verbaliSopra10Service.GetVerbaliSopra10PuntiAsync();
            return View(report);
        }

        [HttpGet("VerbaliSopra400Euro")]
        public async Task<IActionResult> VerbaliSopra400Euro()
        {
            var report = await _verbaliSopra400Service.GetVerbaliSopra400EuroAsync();
            return View(report);
        }

    }
}
