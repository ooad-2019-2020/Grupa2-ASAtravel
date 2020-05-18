using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace authTest.Models
{
    public class Klijent : Korisnik
    {

        public string Ime { get; set; }
        public string Prezime { get; set; }
        public DateTime DatumRodjenja { get; set; }
        public string MjestoStanovanja { get; set; }
        public string Email { get; set; }
        public virtual ICollection<Putovanje> Putovanja { get; set; }
        public int RacunId { get; set; }
        public virtual Racun Racun { get; set; }

    }
}
