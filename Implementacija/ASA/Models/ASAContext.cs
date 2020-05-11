using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;



namespace authTest.Models
{
    public class ASAContext : DbContext
    {
        public ASAContext(DbContextOptions<ASAContext> options) : base(options)
        {
        }
        public DbSet<Agencija> Agencija { get; set; }
        public DbSet<Klijent> Klijent { get; set; }

        //Ova funkcija se koriste da bi se ukinulo automatsko dodavanje množine u nazive
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Agencija>().ToTable("Agencija");
            modelBuilder.Entity<Klijent>().ToTable("Klijent");
        }
    }
}
