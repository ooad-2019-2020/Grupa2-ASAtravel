using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace authTest.Models
{
    public class Rezevacija
    {
        public int Id { get; set; }
        public Klijent Klijent { get; set; }
        public Putovanje Putovanje { get; set; }
        public Kod Kod { get; set; }
        public double Cijena { get; set; }
    }
}
