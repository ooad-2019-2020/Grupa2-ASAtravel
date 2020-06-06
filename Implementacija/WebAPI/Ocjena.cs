using System;
using System.Collections.Generic;

namespace WebAPI
{
    public partial class Ocjena
    {
        public int Id { get; set; }
        public int BrojOcjena { get; set; }
        public double Prosjek { get; set; }
        public int KorisnikId { get; set; }
        public int PutovanjeId { get; set; }

        public virtual Korisnik Korisnik { get; set; }
        public virtual Putovanje Putovanje { get; set; }
    }
}
