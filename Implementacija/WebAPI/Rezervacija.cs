using System;
using System.Collections.Generic;

namespace WebAPI
{
    public partial class Rezervacija
    {
        public int Id { get; set; }
        public int KlijentId { get; set; }
        public int PutovanjeId { get; set; }
        public int? KodId { get; set; }
        public double Cijena { get; set; }
        public int? AgencijaId { get; set; }

        public virtual Agencija Agencija { get; set; }
        public virtual Korisnik Klijent { get; set; }
        public virtual Kod Kod { get; set; }
        public virtual Putovanje Putovanje { get; set; }
    }
}
