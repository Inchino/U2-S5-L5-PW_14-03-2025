using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace GestionaleMunicipale.Models
{
    public class Anagrafica
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid IdAnagrafica { get; set; }

        [Required(ErrorMessage = "Il cognome è obbligatorio")]
        [StringLength(50, ErrorMessage = "Il cognome non può superare i 50 caratteri")]
        public string Cognome { get; set; }

        [Required(ErrorMessage = "Il nome è obbligatorio")]
        [StringLength(50, ErrorMessage = "Il nome non può superare i 50 caratteri")]
        public string Nome { get; set; }

        [StringLength(100, ErrorMessage = "L'indirizzo non può superare i 100 caratteri")]
        public string Indirizzo { get; set; }

        [StringLength(50, ErrorMessage = "La città non può superare i 50 caratteri")]
        public string Citta { get; set; }

        [StringLength(5, MinimumLength = 5, ErrorMessage = "Il CAP deve contenere esattamente 5 caratteri")]
        public string CAP { get; set; }

        [Required(ErrorMessage = "Il codice fiscale è obbligatorio")]
        [StringLength(16, MinimumLength = 16, ErrorMessage = "Il codice fiscale deve essere di 16 caratteri")]
        [RegularExpression("^[A-Z0-9]{16}$", ErrorMessage = "Il codice fiscale deve contenere 16 caratteri alfanumerici in maiuscolo")]
        public string CF { get; set; }

        public ICollection<Verbale> Verbali { get; set; } = new List<Verbale>();
    }
}
