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
    public class VerbaliSopra10PuntiService
    {
        private readonly GestionaleMunicipaleDbContext _context;

        public VerbaliSopra10PuntiService(GestionaleMunicipaleDbContext context)
        {
            _context = context;
        }

        public async Task<List<ReportVerbaliSopra10PuntiViewModel>> GetVerbaliSopra10PuntiAsync()
        {
            return await _context.VerbaliViolazioni
                .Where(vv => vv.DecurtamentoPunti > 10)
                .Select(vv => new ReportVerbaliSopra10PuntiViewModel
                {
                    IdVerbale = vv.IdVerbale,
                    Cognome = vv.Verbale.Anagrafica.Cognome,
                    Nome = vv.Verbale.Anagrafica.Nome,
                    DataViolazione = vv.Verbale.DataViolazione,
                    DecurtamentoPunti = vv.DecurtamentoPunti,
                    Importo = vv.Verbale.Importo
                })
                .ToListAsync();
        }
    }
}
