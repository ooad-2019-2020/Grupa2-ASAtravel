using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace authTest.Models
{
    public class Klijent : Korisnik
    {
        [Required(ErrorMessage = "Polje Ime i prezime je obavezno")]
        [Display(Name = "Ime i prezime")]
        [RegularExpression("^([a-zA-Z]+[ ][a-zA-Z]+)+?$", ErrorMessage = "Polje ne smije sadržavati znakove osim slova")]
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public DateTime DatumRodjenja { get; set; }
        public string MjestoStanovanja { get; set; }
        public string Email { get; set; }
        public virtual ICollection<Putovanje> Putovanja { get; set; }
        public int RacunId { get; set; }
        public virtual Racun Racun { get; set; }

        public Klijent()
        {
        }
    }
}
