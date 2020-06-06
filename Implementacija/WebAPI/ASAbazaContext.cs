using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WebAPI
{
    public partial class ASAbazaContext : DbContext
    {
        public ASAbazaContext()
        {
        }

        public ASAbazaContext(DbContextOptions<ASAbazaContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Agencija> Agencija { get; set; }
        public virtual DbSet<AspNetRoleClaims> AspNetRoleClaims { get; set; }
        public virtual DbSet<AspNetRoles> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUserClaims> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogins> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUserRoles> AspNetUserRoles { get; set; }
        public virtual DbSet<AspNetUserTokens> AspNetUserTokens { get; set; }
        public virtual DbSet<AspNetUsers> AspNetUsers { get; set; }
        public virtual DbSet<Cijena> Cijena { get; set; }
        public virtual DbSet<Iterator> Iterator { get; set; }
        public virtual DbSet<Kod> Kod { get; set; }
        public virtual DbSet<Korisnik> Korisnik { get; set; }
        public virtual DbSet<Ocjena> Ocjena { get; set; }
        public virtual DbSet<Putovanje> Putovanje { get; set; }
        public virtual DbSet<Racun> Racun { get; set; }
        public virtual DbSet<Rezervacija> Rezervacija { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=tcp:asatravel.database.windows.net,1433;Initial Catalog=ASAbaza;Persist Security Info=False;User ID=asaadmin;Password=ASApassword1;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Agencija>(entity =>
            {
                entity.HasIndex(e => e.IteratorId);

                entity.HasIndex(e => e.RacunId);

                entity.HasOne(d => d.Iterator)
                    .WithMany(p => p.Agencija)
                    .HasForeignKey(d => d.IteratorId);

                entity.HasOne(d => d.Racun)
                    .WithMany(p => p.Agencija)
                    .HasForeignKey(d => d.RacunId);
            });

            modelBuilder.Entity<AspNetRoleClaims>(entity =>
            {
                entity.HasIndex(e => e.RoleId);

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.RoleId).IsRequired();

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetRoleClaims)
                    .HasForeignKey(d => d.RoleId);
            });

            modelBuilder.Entity<AspNetRoles>(entity =>
            {
                entity.HasIndex(e => e.NormalizedName)
                    .HasName("RoleNameIndex")
                    .IsUnique();

                entity.Property(e => e.Name)
                    .HasMaxLength(256)
                    .IsUnicode(false);

                entity.Property(e => e.NormalizedName)
                    .HasMaxLength(256)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<AspNetUserClaims>(entity =>
            {
                entity.HasIndex(e => e.UserId);

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.UserId).IsRequired();

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserClaims)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserLogins>(entity =>
            {
                entity.HasKey(e => new { e.LoginProvider, e.ProviderKey });

                entity.HasIndex(e => e.UserId);

                entity.Property(e => e.LoginProvider)
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.Property(e => e.ProviderKey)
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.Property(e => e.UserId).IsRequired();

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserLogins)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserRoles>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.RoleId });

                entity.HasIndex(e => e.RoleId);

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.RoleId);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserTokens>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name });

                entity.Property(e => e.LoginProvider)
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(128)
                    .IsUnicode(false);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserTokens)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUsers>(entity =>
            {
                entity.HasIndex(e => e.NormalizedEmail)
                    .HasName("EmailIndex");

                entity.HasIndex(e => e.NormalizedUserName)
                    .HasName("UserNameIndex")
                    .IsUnique();

                entity.Property(e => e.Discriminator)
                    .IsRequired()
                    .HasColumnType("text")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.Email)
                    .HasMaxLength(256)
                    .IsUnicode(false);

                entity.Property(e => e.Ime).HasColumnType("text");

                entity.Property(e => e.NormalizedEmail)
                    .HasMaxLength(256)
                    .IsUnicode(false);

                entity.Property(e => e.NormalizedUserName)
                    .HasMaxLength(256)
                    .IsUnicode(false);

                entity.Property(e => e.UserName)
                    .HasMaxLength(256)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Kod>(entity =>
            {
                entity.HasIndex(e => e.AgencijaId);

                entity.HasOne(d => d.Agencija)
                    .WithMany(p => p.Kod)
                    .HasForeignKey(d => d.AgencijaId);
            });

            modelBuilder.Entity<Korisnik>(entity =>
            {
                entity.HasIndex(e => e.AgencijaId);

                entity.HasIndex(e => e.PutovanjeId);

                entity.HasIndex(e => e.RacunId);

                entity.Property(e => e.Discriminator).IsRequired();

                entity.Property(e => e.Password).IsRequired();

                entity.HasOne(d => d.Agencija)
                    .WithMany(p => p.Korisnik)
                    .HasForeignKey(d => d.AgencijaId);

                entity.HasOne(d => d.Putovanje)
                    .WithMany(p => p.Korisnik)
                    .HasForeignKey(d => d.PutovanjeId);

                entity.HasOne(d => d.Racun)
                    .WithMany(p => p.Korisnik)
                    .HasForeignKey(d => d.RacunId);
            });

            modelBuilder.Entity<Ocjena>(entity =>
            {
                entity.HasIndex(e => e.KorisnikId);

                entity.HasIndex(e => e.PutovanjeId);

                entity.HasOne(d => d.Korisnik)
                    .WithMany(p => p.Ocjena)
                    .HasForeignKey(d => d.KorisnikId);

                entity.HasOne(d => d.Putovanje)
                    .WithMany(p => p.Ocjena)
                    .HasForeignKey(d => d.PutovanjeId);
            });

            modelBuilder.Entity<Putovanje>(entity =>
            {
                entity.HasIndex(e => e.AgencijaId);

                entity.HasIndex(e => e.KlijentId);

                entity.HasOne(d => d.Agencija)
                    .WithMany(p => p.Putovanje)
                    .HasForeignKey(d => d.AgencijaId);

                entity.HasOne(d => d.Klijent)
                    .WithMany(p => p.PutovanjeNavigation)
                    .HasForeignKey(d => d.KlijentId);
            });

            modelBuilder.Entity<Rezervacija>(entity =>
            {
                entity.HasIndex(e => e.AgencijaId);

                entity.HasIndex(e => e.KlijentId);

                entity.HasIndex(e => e.KodId);

                entity.HasIndex(e => e.PutovanjeId);

                entity.HasOne(d => d.Agencija)
                    .WithMany(p => p.Rezervacija)
                    .HasForeignKey(d => d.AgencijaId);

                entity.HasOne(d => d.Klijent)
                    .WithMany(p => p.Rezervacija)
                    .HasForeignKey(d => d.KlijentId);

                entity.HasOne(d => d.Kod)
                    .WithMany(p => p.Rezervacija)
                    .HasForeignKey(d => d.KodId);

                entity.HasOne(d => d.Putovanje)
                    .WithMany(p => p.Rezervacija)
                    .HasForeignKey(d => d.PutovanjeId);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
