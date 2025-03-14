using GestionaleMunicipale.Data;
using GestionaleMunicipale.Models;
using GestionaleMunicipale.Services;
using GestionaleMunicipale.Services.Report;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace GestionaleMunicipale.Controllers
{
    [Route("api/anagrafica")]
    [ApiController]
    public class AnagraficaController : ControllerBase
    {
        private readonly GenericService<Anagrafica> _service;

        public AnagraficaController(GenericService<Anagrafica> service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll() => Ok(await _service.GetAllAsync());

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id) => Ok(await _service.GetByIdAsync(id));

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Anagrafica anagrafica)
        {
            await _service.CreateAsync(anagrafica);
            return CreatedAtAction(nameof(GetById), new { id = anagrafica.IdAnagrafica }, anagrafica);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] Anagrafica anagrafica)
        {
            if (id != anagrafica.IdAnagrafica) return BadRequest();
            await _service.UpdateAsync(anagrafica);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _service.DeleteAsync(id);
            return NoContent();
        }
    }
}
