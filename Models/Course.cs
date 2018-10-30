using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using EFGetStarted.AspNetCore.NewDb.Models;

namespace EFGetStarted.AspNetCore.NewDb.Models
{
    public class BloggingContext : DbContext
    {
        public BloggingContext(DbContextOptions<BloggingContext> options)
            : base(options)
        { }

        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<Fattura> Fattura { get; set; }
        public DbSet<Spedizione> Spedizione { get; set; }
        public DbSet<Indirizzo> Indirizzo { get; set; }
        public DbSet<EFGetStarted.AspNetCore.NewDb.Models.Contatto> Contatto { get; set; }
    }

    public class Blog
    {
        public int BlogId { get; set; }
        public string Url { get; set; }

        public List<Post> Posts { get; set; }
    }

    public class Post
    {
        public int PostId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }

        public int BlogId { get; set; }
        public Blog Blog { get; set; }
    }
    public class Cliente
    {
        public string ClienteId { get; set; }
        public string nome { get; set; }
        public string cognome { get; set; }
        public string dNascita { get; set; }
        public char sesso { get; set; }
        public int ContattoId { get; set; }
        public Contatto Contatto { get; set; }
        public int SpedizioneId { get; set; }
        public Spedizione Spedizione { get; set; }
    }
    public class Fattura
    {
        public int FatturaId { get; set; }
        public int quantitaProdotto { get; set; }
        public int iva { get; set; }
        public int sconto { get; set; }
        public decimal totFattura { get; set; }
    }
    public class Spedizione
    {
        public int SpedizioneId { get; set; }
        public string nome { get; set; }
        public string descrizione { get; set; }
        public decimal costiSpedizione { get; set; }
    }
    public class Indirizzo
    {
        public int IndirizzoId { get; set; }
        public string indirizzoSpedizione { get; set; }
        public string indirizzoFatturazione { get; set; }
    }
    public class Contatto
    {
        public int ContattoId { get; set; }
        public string nTelefono { get; set; }
        public string nFax { get; set; }
        public string nCellulare { get; set; }
        public string eMail { get; set; }
    }
}