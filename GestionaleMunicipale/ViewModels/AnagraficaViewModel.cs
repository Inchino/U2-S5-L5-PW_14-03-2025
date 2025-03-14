using System;

namespace GestionaleMunicipale.ViewModels
{
    public class AnagraficaViewModel
    {
        public Guid IdAnagrafica { get; set; }
        public string Cognome { get; set; }
        public string Nome { get; set; }
        public string Indirizzo { get; set; }
        public string Citta { get; set; }
        public string CAP { get; set; }
        public string CF { get; set; }
    }
}
