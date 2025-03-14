using GestionaleMunicipale.Models;
using Microsoft.EntityFrameworkCore;

namespace GestionaleMunicipale.Data
{
    public class GestionaleMunicipaleDbContext : DbContext
    {
        public GestionaleMunicipaleDbContext(DbContextOptions<GestionaleMunicipaleDbContext>
            options) : base(options) { }

        public DbSet<Anagrafica> Anagrafiche { get; set; }
        public DbSet<Verbale> Verbali { get; set; }
        public DbSet<VerbaleViolazione> VerbaliViolazioni { get; set; }
        public DbSet<TipoViolazione> TipiViolazioni { get; set; }
    }
}