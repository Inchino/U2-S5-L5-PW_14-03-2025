﻿// <auto-generated />
using System;
using GestionaleMunicipale.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace GestionaleMunicipale.Migrations
{
    [DbContext(typeof(GestionaleMunicipaleDbContext))]
    [Migration("20250314122315_Initial")]
    partial class Initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("GestionaleMunicipale.Models.Anagrafica", b =>
                {
                    b.Property<Guid>("IdAnagrafica")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CAP")
                        .IsRequired()
                        .HasMaxLength(5)
                        .HasColumnType("nvarchar(5)");

                    b.Property<string>("CF")
                        .IsRequired()
                        .HasMaxLength(16)
                        .HasColumnType("nvarchar(16)");

                    b.Property<string>("Citta")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Cognome")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Indirizzo")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("IdAnagrafica");

                    b.ToTable("Anagrafiche");
                });

            modelBuilder.Entity("GestionaleMunicipale.Models.TipoViolazione", b =>
                {
                    b.Property<Guid>("IdViolazione")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Descrizione")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("IdViolazione");

                    b.ToTable("TipiViolazioni");
                });

            modelBuilder.Entity("GestionaleMunicipale.Models.Verbale", b =>
                {
                    b.Property<Guid>("IdVerbale")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DataTrascrizioneVerbale")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DataViolazione")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("IdAnagrafica")
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("Importo")
                        .HasColumnType("decimal(10,2)");

                    b.Property<string>("IndirizzoViolazione")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("NominativoAgente")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("IdVerbale");

                    b.HasIndex("IdAnagrafica");

                    b.ToTable("Verbali");
                });

            modelBuilder.Entity("GestionaleMunicipale.Models.VerbaleViolazione", b =>
                {
                    b.Property<Guid>("IdVerbale")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("IdViolazione")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("DecurtamentoPunti")
                        .HasColumnType("int");

                    b.HasKey("IdVerbale", "IdViolazione");

                    b.HasIndex("IdViolazione");

                    b.ToTable("VerbaliViolazioni");
                });

            modelBuilder.Entity("GestionaleMunicipale.Models.Verbale", b =>
                {
                    b.HasOne("GestionaleMunicipale.Models.Anagrafica", "Anagrafica")
                        .WithMany("Verbali")
                        .HasForeignKey("IdAnagrafica")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Anagrafica");
                });

            modelBuilder.Entity("GestionaleMunicipale.Models.VerbaleViolazione", b =>
                {
                    b.HasOne("GestionaleMunicipale.Models.Verbale", "Verbale")
                        .WithMany("Violazioni")
                        .HasForeignKey("IdVerbale")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GestionaleMunicipale.Models.TipoViolazione", "TipoViolazione")
                        .WithMany("VerbaliViolazioni")
                        .HasForeignKey("IdViolazione")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TipoViolazione");

                    b.Navigation("Verbale");
                });

            modelBuilder.Entity("GestionaleMunicipale.Models.Anagrafica", b =>
                {
                    b.Navigation("Verbali");
                });

            modelBuilder.Entity("GestionaleMunicipale.Models.TipoViolazione", b =>
                {
                    b.Navigation("VerbaliViolazioni");
                });

            modelBuilder.Entity("GestionaleMunicipale.Models.Verbale", b =>
                {
                    b.Navigation("Violazioni");
                });
#pragma warning restore 612, 618
        }
    }
}
