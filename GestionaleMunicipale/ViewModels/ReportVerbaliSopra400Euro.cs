using System;

namespace GestionaleMunicipale.ViewModels
{
    public class ReportVerbaliSopra400EuroViewModel
    {
        public Guid IdVerbale { get; set; }
        public Guid IdAnagrafica { get; set; }
        public string Nome { get; set; }
        public string Cognome { get; set; }
        public DateTime DataViolazione { get; set; }
        public decimal Importo { get; set; }
    }
}
