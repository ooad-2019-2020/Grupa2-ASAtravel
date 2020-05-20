using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace authTest.Models
{
    public class Rezervacija
    {
        public int Id { get; set; }
        public int KlijentId { get; set; }
        public Klijent Klijent { get; set; }
        public int PutovanjeId { get; set; }
        public Putovanje Putovanje { get; set; }
        public int? KodId { get; set; }
        public Kod Kod { get; set; }
        public double Cijena { get; set; }

        public Rezervacija()
        {
        }
    }
}
