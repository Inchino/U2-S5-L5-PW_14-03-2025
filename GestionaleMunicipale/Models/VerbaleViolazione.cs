using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace GestionaleMunicipale.Models
{
    public class VerbaleViolazione
    {
        [Required(ErrorMessage = "L'ID del verbale è obbligatorio")]
        [ForeignKey("Verbale")]
        public int IdVerbale { get; set; }

        [Required(ErrorMessage = "L'ID della violazione è obbligatorio")]
        [ForeignKey("TipoViolazione")]
        public int IdViolazione { get; set; }

        [Required(ErrorMessage = "Il numero di punti decurtati è obbligatorio")]
        public int DecurtamentoPunti { get; set; }

        public Verbale Verbale { get; set; }
        public TipoViolazione TipoViolazione { get; set; }
    }
}
