using System;

namespace GestionaleMunicipale.ViewModels
{
    public class VerbaleViewModel
    {
        public Guid IdVerbale { get; set; }
        public Guid IdAnagrafica { get; set; }
        public DateTime DataViolazione { get; set; }
        public string IndirizzoViolazione { get; set; }
        public string NominativoAgente { get; set; }
        public DateTime DataTrascrizioneVerbale { get; set; }
        public decimal Importo { get; set; }
    }
}
