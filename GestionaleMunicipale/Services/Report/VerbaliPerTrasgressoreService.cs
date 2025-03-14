using GestionaleMunicipale.Data;
using GestionaleMunicipale.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestionaleMunicipale.Services.Report
{
    public class VerbaliPerTrasgressoreService
    {
        private readonly GestionaleMunicipaleDbContext _context;

        public VerbaliPerTrasgressoreService(GestionaleMunicipaleDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<object>> GetVerbaliPerTrasgressoreAsync()
        {
            try
            {
                return await _context.Verbali
                    .GroupBy(v => v.IdAnagrafica)
                    .Select(g => new
                    {
                        IdAnagrafica = g.Key,
                        Nome = _context.Anagrafiche.Where(a => a.IdAnagrafica == g.Key).Select(a => a.Nome).FirstOrDefault(),
                        Cognome = _context.Anagrafiche.Where(a => a.IdAnagrafica == g.Key).Select(a => a.Cognome).FirstOrDefault(),
                        TotaleVerbali = g.Count()
                    }).ToListAsync();
            }
            catch (Exception ex) { throw new Exception("Errore nel recupero del report verbali per trasgressore.", ex); }
        }
    }
}
