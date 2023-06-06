using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FilmesAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace FilmesAPI.Context
{
    public class FilmesContext : DbContext
    {
        public FilmesContext(DbContextOptions options) : base(options) { }

        public FilmesContext() { }

        public virtual DbSet<Filme> Filmes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("ServerConnection");
            }
        }
    }
}
