using System;
using System.Collections.Generic;

namespace WebAPI
{
    public partial class Korisnik
    {
        public Korisnik()
        {
            Ocjena = new HashSet<Ocjena>();
            PutovanjeNavigation = new HashSet<Putovanje>();
            Rezervacija = new HashSet<Rezervacija>();
        }

        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int? AgencijaId { get; set; }
        public string Discriminator { get; set; }
        public int? PutovanjeId { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public DateTime? DatumRodjenja { get; set; }
        public string MjestoStanovanja { get; set; }
        public string Email { get; set; }
        public int? RacunId { get; set; }

        public virtual Agencija Agencija { get; set; }
        public virtual Putovanje Putovanje { get; set; }
        public virtual Racun Racun { get; set; }
        public virtual ICollection<Ocjena> Ocjena { get; set; }
        public virtual ICollection<Putovanje> PutovanjeNavigation { get; set; }
        public virtual ICollection<Rezervacija> Rezervacija { get; set; }
    }
}
