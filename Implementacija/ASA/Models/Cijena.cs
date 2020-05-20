using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace authTest.Models
{
    public class Cijena
    {
        public int Id { get; set; }
        public double PunaCijena { get; set; }
        public double Akontacija { get; set; }

        public Cijena(double punaCijena, double akontacija)
        {
            PunaCijena = punaCijena;
            Akontacija = akontacija;
        }

        public Cijena()
        {
        }
    }
}
