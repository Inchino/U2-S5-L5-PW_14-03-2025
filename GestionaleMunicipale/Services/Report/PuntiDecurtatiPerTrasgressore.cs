using GestionaleMunicipale.Data;
using GestionaleMunicipale.Models;
using GestionaleMunicipale.ViewModels;
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

        public async Task<List<ReportPuntiDecurtatiPerTrasgressoreViewModel>> GetPuntiDecurtatiPerTrasgressoreAsync()
        {
            return await _context.VerbaliViolazioni
                .GroupBy(vv => new { vv.Verbale.IdAnagrafica, vv.Verbale.Anagrafica.Cognome, vv.Verbale.Anagrafica.Nome })
                .Select(g => new ReportPuntiDecurtatiPerTrasgressoreViewModel
                {
                    IdAnagrafica = g.Key.IdAnagrafica,
                    Cognome = g.Key.Cognome,
                    Nome = g.Key.Nome,
                    TotalePuntiDecurtati = g.Sum(vv => vv.DecurtamentoPunti)
                })
                .ToListAsync();
        }
    }
}
