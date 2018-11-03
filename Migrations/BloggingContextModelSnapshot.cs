﻿// <auto-generated />
using EFGetStarted.AspNetCore.NewDb.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EFGetStarted.AspNetCore.NewDb.Migrations
{
    [DbContext(typeof(BloggingContext))]
    partial class BloggingContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024");

            modelBuilder.Entity("EFGetStarted.AspNetCore.NewDb.Models.Acquisti", b =>
                {
                    b.Property<int>("AcquistiID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ClienteId");

                    b.Property<int>("FatturaId");

                    b.Property<int>("SpedizioneId");

                    b.HasKey("AcquistiID");

                    b.HasIndex("ClienteId");

                    b.HasIndex("FatturaId");

                    b.HasIndex("SpedizioneId");

                    b.ToTable("Acquisti");
                });

            modelBuilder.Entity("EFGetStarted.AspNetCore.NewDb.Models.Cliente", b =>
                {
                    b.Property<int>("ClienteId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ContattoId");

                    b.Property<int>("IndirizzoId");

                    b.Property<int>("TipoId");

                    b.Property<string>("cognome")
                        .IsRequired();

                    b.Property<string>("dNascita")
                        .IsRequired();

                    b.Property<string>("nome")
                        .IsRequired();

                    b.Property<char>("sesso");

                    b.HasKey("ClienteId");

                    b.HasIndex("ContattoId");

                    b.HasIndex("IndirizzoId");

                    b.HasIndex("TipoId");

                    b.ToTable("Cliente");
                });

            modelBuilder.Entity("EFGetStarted.AspNetCore.NewDb.Models.Contatto", b =>
                {
                    b.Property<int>("ContattoId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("eMail");

                    b.Property<string>("nCellulare");

                    b.Property<string>("nFax");

                    b.Property<string>("nTelefono");

                    b.HasKey("ContattoId");

                    b.ToTable("Contatto");
                });

            modelBuilder.Entity("EFGetStarted.AspNetCore.NewDb.Models.Fattura", b =>
                {
                    b.Property<int>("FatturaId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ClienteId");

                    b.Property<int>("iva");

                    b.Property<int>("quantitaProdotto");

                    b.Property<int>("sconto");

                    b.Property<decimal>("totFattura");

                    b.HasKey("FatturaId");

                    b.HasIndex("ClienteId");

                    b.ToTable("Fattura");
                });

            modelBuilder.Entity("EFGetStarted.AspNetCore.NewDb.Models.Indirizzo", b =>
                {
                    b.Property<int>("IndirizzoId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("indirizzoFatturazione");

                    b.Property<string>("indirizzoSpedizione");

                    b.HasKey("IndirizzoId");

                    b.ToTable("Indirizzo");
                });

            modelBuilder.Entity("EFGetStarted.AspNetCore.NewDb.Models.Spedizione", b =>
                {
                    b.Property<int>("SpedizioneId")
                        .ValueGeneratedOnAdd();

                    b.Property<decimal>("costiSpedizione");

                    b.Property<string>("descrizione");

                    b.Property<string>("nome");

                    b.HasKey("SpedizioneId");

                    b.ToTable("Spedizione");
                });

            modelBuilder.Entity("EFGetStarted.AspNetCore.NewDb.Models.Tipo", b =>
                {
                    b.Property<int>("TipoId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("descrizione");

                    b.Property<int>("pIVA");

                    b.HasKey("TipoId");

                    b.ToTable("Tipo");
                });

            modelBuilder.Entity("EFGetStarted.AspNetCore.NewDb.Models.Acquisti", b =>
                {
                    b.HasOne("EFGetStarted.AspNetCore.NewDb.Models.Cliente", "Cliente")
                        .WithMany()
                        .HasForeignKey("ClienteId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("EFGetStarted.AspNetCore.NewDb.Models.Fattura", "Fattura")
                        .WithMany()
                        .HasForeignKey("FatturaId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("EFGetStarted.AspNetCore.NewDb.Models.Spedizione", "Spedizione")
                        .WithMany()
                        .HasForeignKey("SpedizioneId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("EFGetStarted.AspNetCore.NewDb.Models.Cliente", b =>
                {
                    b.HasOne("EFGetStarted.AspNetCore.NewDb.Models.Contatto", "Contatto")
                        .WithMany()
                        .HasForeignKey("ContattoId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("EFGetStarted.AspNetCore.NewDb.Models.Indirizzo", "Indirizzo")
                        .WithMany()
                        .HasForeignKey("IndirizzoId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("EFGetStarted.AspNetCore.NewDb.Models.Tipo", "Tipo")
                        .WithMany()
                        .HasForeignKey("TipoId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("EFGetStarted.AspNetCore.NewDb.Models.Fattura", b =>
                {
                    b.HasOne("EFGetStarted.AspNetCore.NewDb.Models.Cliente", "Cliente")
                        .WithMany()
                        .HasForeignKey("ClienteId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
