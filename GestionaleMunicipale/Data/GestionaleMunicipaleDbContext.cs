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

        // Consiglio di ChatGPT perchè VerbaleViolazione deve avere una chiave composta (come definito nel mio vecchio progetto SQL), la soluzione migliore è configurare la chiave composta nel DbContext.
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Definizione della chiave composta per VerbaleViolazione
            modelBuilder.Entity<VerbaleViolazione>()
                .HasKey(vv => new { vv.IdVerbale, vv.IdViolazione });

            // Relazione tra Verbale e Anagrafica
            modelBuilder.Entity<Verbale>()
                .HasOne(v => v.Anagrafica)
                .WithMany(a => a.Verbali)
                .HasForeignKey(v => v.IdAnagrafica)
                .OnDelete(DeleteBehavior.Cascade);

            // Relazione tra VerbaleViolazione e Verbale
            modelBuilder.Entity<VerbaleViolazione>()
                .HasOne(vv => vv.Verbale)
                .WithMany(v => v.Violazioni)
                .HasForeignKey(vv => vv.IdVerbale)
                .OnDelete(DeleteBehavior.Cascade);

            // Relazione tra VerbaleViolazione e TipoViolazione
            modelBuilder.Entity<VerbaleViolazione>()
                .HasOne(vv => vv.TipoViolazione)
                .WithMany(tv => tv.VerbaliViolazioni)
                .HasForeignKey(vv => vv.IdViolazione)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}