using GestionaleMunicipale.Data;
using GestionaleMunicipale.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestionaleMunicipale.Services.Report
{
    public class VerbaliSopra400EuroService
    {
        private readonly GestionaleMunicipaleDbContext _context;

        public VerbaliSopra400EuroService(GestionaleMunicipaleDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<object>> GetVerbaliSopra400EuroAsync()
        {
            try
            {
                return await _context.Verbali
                    .Where(v => v.Importo > 400)
                    .Select(v => new
                    {
                        v.IdVerbale,
                        v.IdAnagrafica,
                        v.Anagrafica.Nome,
                        v.Anagrafica.Cognome,
                        v.DataViolazione,
                        v.Importo
                    }).ToListAsync();
            }
            catch (Exception ex) { throw new Exception("Errore nel recupero del report verbali sopra 400 euro.", ex); }
        }
    }
}
