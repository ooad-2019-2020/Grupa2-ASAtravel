using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace authTest.Models
{
    public class Kod
    {
        public int Id { get; set; }
        public string Sifra { get; set; }
        public int Popust { get; set; }
        public int AgencijaId { get; set; }
        public virtual Agencija Agencija { get; set; }

        public Kod(string sifra, int popust)
        {
            Sifra = sifra;
            Popust = popust;
        }
        public Kod()
        {

        }
    }
}
