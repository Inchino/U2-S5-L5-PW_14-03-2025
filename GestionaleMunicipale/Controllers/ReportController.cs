using GestionaleMunicipale.Data;
using GestionaleMunicipale.Models;
using GestionaleMunicipale.Services;
using GestionaleMunicipale.Services.Report;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace GestionaleMunicipale.Controllers
{
    [Route("api/reports")]
    [ApiController]
    public class ReportsController : ControllerBase
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

        [HttpGet("verbali-per-trasgressore")]
        public async Task<IActionResult> GetVerbaliPerTrasgressore() => Ok(await _verbaliPerTrasgressoreService.GetVerbaliPerTrasgressoreAsync());

        [HttpGet("punti-decurtati-per-trasgressore")]
        public async Task<IActionResult> GetPuntiDecurtatiPerTrasgressore() => Ok(await _puntiDecurtatiService.GetPuntiDecurtatiPerTrasgressoreAsync());

        [HttpGet("verbali-sopra-10-punti")]
        public async Task<IActionResult> GetVerbaliSopra10Punti() => Ok(await _verbaliSopra10Service.GetVerbaliSopra10PuntiAsync());

        [HttpGet("verbali-sopra-400-euro")]
        public async Task<IActionResult> GetVerbaliSopra400Euro() => Ok(await _verbaliSopra400Service.GetVerbaliSopra400EuroAsync());
    }
}
