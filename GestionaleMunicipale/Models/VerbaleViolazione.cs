using System;

namespace PoliziaMunicipaleApp
{
    public class VerbaleViolazione
    {
        public int IdVerbale { get; set; }
        public int IdViolazione { get; set; }
        public int DecurtamentoPunti { get; set; }
        public Verbale Verbale { get; set; }
        public TipoViolazione TipoViolazione { get; set; }
    }
}
