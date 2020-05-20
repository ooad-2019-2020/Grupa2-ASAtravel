using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace authTest.Models
{
    public class Ocjena
    {
        public int Id { get; set; }
        public int BrojOcjena { get; set; }
        public double Prosjek { get; set; }
        public int KorisnikId { get; set; }
        public virtual Korisnik Korisnik { get; set; }
        public int PutovanjeId { get; set; }
        public virtual Putovanje Putovanje { get; set; }

        public Ocjena(int brojOcjena, double prosjek)
        {
            BrojOcjena = brojOcjena;
            Prosjek = prosjek;
        }

        public Ocjena()
        {
        }
    }
}
