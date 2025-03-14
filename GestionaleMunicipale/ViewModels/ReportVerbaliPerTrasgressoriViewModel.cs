using System;

namespace GestionaleMunicipale.ViewModels
{
    public class ReportVerbaliPerTrasgressoreViewModel
    {
        public Guid IdAnagrafica { get; set; }
        public string Nome { get; set; }
        public string Cognome { get; set; }
        public int TotaleVerbali { get; set; }
    }
}
