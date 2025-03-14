using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace GestionaleMunicipale.Models
{
    public class TipoViolazione
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdViolazione { get; set; }

        [Required(ErrorMessage = "La descrizione è obbligatoria")]
        [StringLength(255, ErrorMessage = "La descrizione non può superare i 255 caratteri")]
        public string Descrizione { get; set; }

        public ICollection<VerbaleViolazione> VerbaliViolazioni { get; set; } = new List<VerbaleViolazione>();
    }
}
