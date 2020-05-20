using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace authTest.Models
{
    public class Racun : Attribute
    {
        public int Id { get; set; }
        public string BrojRacuna { get; set; }
        public double IznosNovca { get; set; }

        public Racun()
        {
        }
    }
}
