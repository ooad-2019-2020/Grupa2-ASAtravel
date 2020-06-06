using System;
using System.Collections.Generic;

namespace WebAPI
{
    public partial class Kod
    {
        public Kod()
        {
            Rezervacija = new HashSet<Rezervacija>();
        }

        public int Id { get; set; }
        public string Sifra { get; set; }
        public int Popust { get; set; }
        public int AgencijaId { get; set; }

        public virtual Agencija Agencija { get; set; }
        public virtual ICollection<Rezervacija> Rezervacija { get; set; }
    }
}
