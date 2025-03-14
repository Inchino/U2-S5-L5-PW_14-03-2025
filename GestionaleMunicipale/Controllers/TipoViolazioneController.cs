using GestionaleMunicipale.Data;
using GestionaleMunicipale.Models;
using GestionaleMunicipale.Services;
using GestionaleMunicipale.Services.Report;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace GestionaleMunicipale.Controllers
{
    [Route("api/tipoviolazione")]
    [ApiController]
    public class TipoViolazioneController : ControllerBase
    {
        private readonly GenericService<TipoViolazione> _service;

        public TipoViolazioneController(GenericService<TipoViolazione> service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll() => Ok(await _service.GetAllAsync());
    }
}
