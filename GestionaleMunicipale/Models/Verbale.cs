using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace GestionaleMunicipale.Models
{
    public class Verbale
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdVerbale { get; set; }

        [Required(ErrorMessage = "L'anagrafica del trasgressore è obbligatoria")]
        [ForeignKey("Anagrafica")]
        public int IdAnagrafica { get; set; }

        [Required(ErrorMessage = "La data della violazione è obbligatoria")]
        [Column(TypeName = "date")]
        public DateTime DataViolazione { get; set; }

        [Required(ErrorMessage = "L'indirizzo della violazione è obbligatorio")]
        [StringLength(100, ErrorMessage = "L'indirizzo della violazione non può superare i 100 caratteri")]
        public string IndirizzoViolazione { get; set; }

        [Required(ErrorMessage = "Il nominativo dell'agente è obbligatorio")]
        [StringLength(100, ErrorMessage = "Il nominativo dell'agente non può superare i 100 caratteri")]
        public string NominativoAgente { get; set; }

        [Required(ErrorMessage = "La data di trascrizione del verbale è obbligatoria")]
        [Column(TypeName = "date")]
        public DateTime DataTrascrizioneVerbale { get; set; }

        [Required(ErrorMessage = "L'importo della multa è obbligatorio")]
        [Column(TypeName = "decimal(10,2)")]
        public decimal Importo { get; set; }

        public Anagrafica Anagrafica { get; set; }
        public ICollection<VerbaleViolazione> Violazioni { get; set; } = new List<VerbaleViolazione>();
    }
}
