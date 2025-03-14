using System;

namespace GestionaleMunicipale.ViewModels
{
    public class ReportPuntiDecurtatiPerTrasgressoreViewModel
    {
        public Guid IdAnagrafica { get; set; }
        public string Nome { get; set; }
        public string Cognome { get; set; }
        public int TotalePuntiDecurtati { get; set; }
    }
}
