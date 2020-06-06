using System;
using System.Collections.Generic;

namespace WebAPI
{
    public partial class Racun
    {
        public Racun()
        {
            Agencija = new HashSet<Agencija>();
            Korisnik = new HashSet<Korisnik>();
        }

        public int Id { get; set; }
        public string BrojRacuna { get; set; }
        public double IznosNovca { get; set; }

        public virtual ICollection<Agencija> Agencija { get; set; }
        public virtual ICollection<Korisnik> Korisnik { get; set; }
    }
}
