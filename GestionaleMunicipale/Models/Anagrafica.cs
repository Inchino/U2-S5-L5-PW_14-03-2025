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
        public int IdAnagrafica { get; set; }

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

        [StringLength(5, ErrorMessage = "Il CAP deve contenere al massimo 5 caratteri")]
        public string CAP { get; set; }

        [Required(ErrorMessage = "Il codice fiscale è obbligatorio")]
        [StringLength(16, ErrorMessage = "Il codice fiscale deve essere di 16 caratteri")]
        [Index(IsUnique = true)]
        public string CF { get; set; }

        public ICollection<Verbale> Verbali { get; set; } = new List<Verbale>();
    }
}
