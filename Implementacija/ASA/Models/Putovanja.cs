using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace authTest.Models
{
    public class Putovanje
    {
        public int Id { get; set; }
        public string Slika { get; set; }
        public string Destinacija { get; set; }
        public string Info { get; set; }
        public bool Aktuelno { get; set; }
        public DateTime DatumPolaska { get; set; }
        public DateTime DatumPovratka { get; set; }
        public int MinBrojLjudi { get; set; }
        public int MaxBrojLjudi { get; set; }
        public int CijenaId { get; set; }
        public virtual Cijena Cijena { get; set; }
        public virtual ICollection<Korisnik> Putnici { get; set; }

    }
}
