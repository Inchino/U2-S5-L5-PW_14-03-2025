using Microsoft.AspNetCore.Mvc;
using GestionaleMunicipale.Services;
using GestionaleMunicipale.Models;
using System.Threading.Tasks;

namespace GestionaleMunicipale.Controllers
{
    public class TipoViolazioneController : Controller
    {
        private readonly GenericService<TipoViolazione> _service;

        public TipoViolazioneController(GenericService<TipoViolazione> service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var violazioni = await _service.GetAllAsync();
            return View(violazioni);
        }
    }
}
