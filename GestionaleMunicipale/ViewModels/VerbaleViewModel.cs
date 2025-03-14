using System;

namespace GestionaleMunicipale.ViewModels
{
    public class VerbaleViewModel
    {
        public int IdVerbale { get; set; }
        public int IdAnagrafica { get; set; }
        public DateTime DataViolazione { get; set; }
        public string IndirizzoViolazione { get; set; }
        public string NominativoAgente { get; set; }
        public DateTime DataTrascrizioneVerbale { get; set; }
        public decimal Importo { get; set; }
    }
}
