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
    public class VerbaliSopra400EuroService
    {
        private readonly GestionaleMunicipaleDbContext _context;

        public VerbaliSopra400EuroService(GestionaleMunicipaleDbContext context)
        {
            _context = context;
        }

        public async Task<List<ReportVerbaliSopra400EuroViewModel>> GetVerbaliSopra400EuroAsync()
        {
            return await _context.Verbali
                .Where(v => v.Importo > 400)
                .Select(v => new ReportVerbaliSopra400EuroViewModel
                {
                    IdVerbale = v.IdVerbale,
                    Cognome = v.Anagrafica.Cognome,
                    Nome = v.Anagrafica.Nome,
                    DataViolazione = v.DataViolazione,
                    Importo = v.Importo
                })
                .ToListAsync();
        }
    }
}
