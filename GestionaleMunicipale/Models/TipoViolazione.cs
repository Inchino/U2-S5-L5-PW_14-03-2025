using System;

namespace PoliziaMunicipaleApp
{
    public class TipoViolazione
    {
        public int IdViolazione { get; set; }
        public string Descrizione { get; set; }
        public ICollection<VerbaleViolazione> VerbaliViolazioni { get; set; }
    }
}
