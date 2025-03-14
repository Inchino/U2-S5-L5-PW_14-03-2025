using System;

namespace GestionaleMunicipale.ViewModels
{
    public class ReportVerbaliSopra10PuntiViewModel
    {
        public string Nome { get; set; }
        public string Cognome { get; set; }
        public DateTime DataViolazione { get; set; }
        public decimal Importo { get; set; }
        public int DecurtamentoPunti { get; set; }
    }
}
