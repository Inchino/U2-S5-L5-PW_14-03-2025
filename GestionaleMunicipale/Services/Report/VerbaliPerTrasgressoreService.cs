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
    public class VerbaliPerTrasgressoreService
    {
        private readonly GestionaleMunicipaleDbContext _context;

        public VerbaliPerTrasgressoreService(GestionaleMunicipaleDbContext context)
        {
            _context = context;
        }

        public async Task<List<ReportVerbaliPerTrasgressoreViewModel>> GetVerbaliPerTrasgressoreAsync()
        {
            return await _context.Verbali
                .GroupBy(v => new { v.IdAnagrafica, v.Anagrafica.Cognome, v.Anagrafica.Nome })
                .Select(g => new ReportVerbaliPerTrasgressoreViewModel
                {
                    IdAnagrafica = g.Key.IdAnagrafica,
                    Cognome = g.Key.Cognome,
                    Nome = g.Key.Nome,
                    TotaleVerbali = g.Count()
                })
                .ToListAsync();
        }
    }
}
