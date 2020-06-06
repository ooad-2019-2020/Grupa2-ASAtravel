using System;
using System.Collections.Generic;

namespace WebAPI
{
    public partial class Agencija
    {
        public Agencija()
        {
            Kod = new HashSet<Kod>();
            Korisnik = new HashSet<Korisnik>();
            Putovanje = new HashSet<Putovanje>();
            Rezervacija = new HashSet<Rezervacija>();
        }

        public int Id { get; set; }
        public string Info { get; set; }
        public string Naziv { get; set; }
        public string UsloviPutovanja { get; set; }
        public int RacunId { get; set; }
        public int? IteratorId { get; set; }

        public virtual Iterator Iterator { get; set; }
        public virtual Racun Racun { get; set; }
        public virtual ICollection<Kod> Kod { get; set; }
        public virtual ICollection<Korisnik> Korisnik { get; set; }
        public virtual ICollection<Putovanje> Putovanje { get; set; }
        public virtual ICollection<Rezervacija> Rezervacija { get; set; }
    }
}
