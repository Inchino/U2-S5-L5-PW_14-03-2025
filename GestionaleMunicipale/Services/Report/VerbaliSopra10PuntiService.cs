using GestionaleMunicipale.Data;
using GestionaleMunicipale.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GestionaleMunicipale.Services.Report
{
    public class VerbaliSopra10PuntiService
    {
        private readonly GestionaleMunicipaleDbContext _context;

        public VerbaliSopra10PuntiService(GestionaleMunicipaleDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<object>> GetVerbaliSopra10PuntiAsync()
        {
            try
            {
                return await _context.VerbaliViolazioni
                    .Where(vv => vv.DecurtamentoPunti > 10)
                    .Select(vv => new
                    {
                        vv.Verbale.IdVerbale,
                        vv.Verbale.IdAnagrafica,
                        vv.Verbale.Anagrafica.Nome,
                        vv.Verbale.Anagrafica.Cognome,
                        vv.Verbale.DataViolazione,
                        vv.Verbale.Importo,
                        vv.DecurtamentoPunti
                    }).ToListAsync();
            }
            catch (Exception ex) { throw new Exception("Errore nel recupero del report verbali sopra 10 punti.", ex); }
        }
    }
}
