using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace authTest.Models
{
    public class Cijena : IzracunCijene
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
        public double dajCijenuSPopustom(double popust)
        {
            return popust * PunaCijena; 
        }
        public double dajPunuCijenu()
        {
            return PunaCijena;   

        }

    }
}
