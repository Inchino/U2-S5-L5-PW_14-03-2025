using GestionaleMunicipale.Data;
using GestionaleMunicipale.Models;
using GestionaleMunicipale.Services;
using GestionaleMunicipale.Services.Report;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace GestionaleMunicipale.Controllers
{
    [Route("api/verbale")]
    [ApiController]
    public class VerbaleController : ControllerBase
    {
        private readonly GenericService<Verbale> _service;

        public VerbaleController(GenericService<Verbale> service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll() => Ok(await _service.GetAllAsync());

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Verbale verbale)
        {
            await _service.CreateAsync(verbale);
            return CreatedAtAction(nameof(GetAll), new { id = verbale.IdVerbale }, verbale);
        }
    }
}
