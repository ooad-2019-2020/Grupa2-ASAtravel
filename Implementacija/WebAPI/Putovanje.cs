using System;
using System.Collections.Generic;

namespace WebAPI
{
    public partial class Putovanje
    {
        public Putovanje()
        {
            Korisnik = new HashSet<Korisnik>();
            Ocjena = new HashSet<Ocjena>();
            Rezervacija = new HashSet<Rezervacija>();
        }

        public int Id { get; set; }
        public string Slika { get; set; }
        public string Destinacija { get; set; }
        public string Info { get; set; }
        public bool Aktuelno { get; set; }
        public DateTime DatumPolaska { get; set; }
        public DateTime DatumPovratka { get; set; }
        public int MinBrojLjudi { get; set; }
        public int MaxBrojLjudi { get; set; }
        public int? AgencijaId { get; set; }
        public int? KlijentId { get; set; }
        public double Cijena { get; set; }

        public virtual Agencija Agencija { get; set; }
        public virtual Korisnik Klijent { get; set; }
        public virtual ICollection<Korisnik> Korisnik { get; set; }
        public virtual ICollection<Ocjena> Ocjena { get; set; }
        public virtual ICollection<Rezervacija> Rezervacija { get; set; }
    }
}
