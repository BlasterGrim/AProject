using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

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
        public int ClienteId { get; set; }
        public string nome { get; set; }
        public string cognome { get; set; }
        public string dNascita { get; set; }
        public char sesso { get; set; }
    }
    public class Fattura
    {
        public int ClienteId { get; set; }
        public string Nome { get; set; }
    }
    public class Spedizione
    {
        public int ClienteId { get; set; }
        public string Nome { get; set; }
    }
    public class Indirizzo
    {
        public int ClienteId { get; set; }
        public string Nome { get; set; }
    }
}