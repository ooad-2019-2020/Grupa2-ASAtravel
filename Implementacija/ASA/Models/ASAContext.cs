using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using authTest.Models;



namespace authTest.Models
{
    public class ASAContext : DbContext
    {
        public ASAContext(DbContextOptions<ASAContext> options) : base(options)
        {
        }
        public DbSet<Agencija> Agencija { get; set; }
        public DbSet<Korisnik> Korisnik { get; set; }
        public DbSet<Racun> Racun { get; set; }
        public DbSet<Rezervacija> Rezervacija { get; set; }
        public DbSet<Putovanje> Putovanje { get; set; }
        public DbSet<Kod> Kod { get; set; }
        public DbSet<Ocjena> Ocjena { get; set; }
        public DbSet<Iterator> Iterator { get; set; }
 
        //Ova funkcija se koriste da bi se ukinulo automatsko dodavanje množine u nazive
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Agencija>().ToTable("Agencija");
            modelBuilder.Entity<Korisnik>().ToTable("Korisnik");
            modelBuilder.Entity<Racun>().ToTable("Racun");
            modelBuilder.Entity<Rezervacija>().ToTable("Rezervacija");
            modelBuilder.Entity<Putovanje>().ToTable("Putovanje");
            modelBuilder.Entity<Kod>().ToTable("Kod");
            modelBuilder.Entity<Ocjena>().ToTable("Ocjena");
            modelBuilder.Entity<Iterator>().ToTable("Iterator");
        }
 
        //Ova funkcija se koriste da bi se ukinulo automatsko dodavanje množine u nazive
        public DbSet<authTest.Models.Administrator> Administrator { get; set; }
 
        //Ova funkcija se koriste da bi se ukinulo automatsko dodavanje množine u nazive
        public DbSet<authTest.Models.Cijena> Cijena { get; set; }
 
        //Ova funkcija se koriste da bi se ukinulo automatsko dodavanje množine u nazive
        public DbSet<authTest.Models.Klijent> Klijent { get; set; }
    }
}
