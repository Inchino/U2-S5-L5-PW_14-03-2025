using GestionaleMunicipale.Data;
using GestionaleMunicipale.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestionaleMunicipale.Services.Report
{
    public class PuntiDecurtatiPerTrasgressoreService
    {
        private readonly GestionaleMunicipaleDbContext _context;

        public PuntiDecurtatiPerTrasgressoreService(GestionaleMunicipaleDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<object>> GetPuntiDecurtatiPerTrasgressoreAsync()
        {
            try
            {
                return await _context.VerbaliViolazioni
                    .GroupBy(vv => vv.Verbale.IdAnagrafica)
                    .Select(g => new
                    {
                        IdAnagrafica = g.Key,
                        Nome = _context.Anagrafiche.Where(a => a.IdAnagrafica == g.Key).Select(a => a.Nome).FirstOrDefault(),
                        Cognome = _context.Anagrafiche.Where(a => a.IdAnagrafica == g.Key).Select(a => a.Cognome).FirstOrDefault(),
                        TotalePuntiDecurtati = g.Sum(vv => vv.DecurtamentoPunti)
                    }).ToListAsync();
            }
            catch (Exception ex) { throw new Exception("Errore nel recupero del report punti decurtati per trasgressore.", ex); }
        }
    }
}
