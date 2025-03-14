using Microsoft.AspNetCore.Mvc;
using GestionaleMunicipale.Services;
using GestionaleMunicipale.Models;
using GestionaleMunicipale.ViewModels;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;

namespace GestionaleMunicipale.Controllers
{
    [Route("TipoViolazione")]
    public class TipoViolazioneController : Controller
    {
        private readonly GenericService<TipoViolazione> _service;

        public TipoViolazioneController(GenericService<TipoViolazione> service)
        {
            _service = service;
        }

        [HttpGet("")]
        public async Task<IActionResult> Index()
        {
            var violazioni = await _service.GetAllAsync();

            var viewModelList = violazioni.Select(v => new TipoViolazioneViewModel
            {
                IdViolazione = v.IdViolazione,
                Descrizione = v.Descrizione
            }).ToList();

            return View(viewModelList);
        }
    }
}
