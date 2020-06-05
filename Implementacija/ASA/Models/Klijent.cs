using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace authTest.Models
{
    public class Klijent : Korisnik
    {
        [Required(ErrorMessage = "Polje Ime je obavezno")]
        [Display(Name = "Ime")]
        [RegularExpression("^([a-zA-Z])+?$", ErrorMessage = "Polje ne smije sadržavati znakove osim slova")]
        public string Ime { get; set; }

        [Required(ErrorMessage = "Polje Prezime je obavezno")]
        [Display(Name = "Prezime")]
        [RegularExpression("^([a-zA-Z])+?$", ErrorMessage = "Polje ne smije sadržavati znakove osim slova")]
        public string Prezime { get; set; }
        public DateTime DatumRodjenja { get; set; }
        public string MjestoStanovanja { get; set; }
        [Required(ErrorMessage = "Polje Email je obavezno")]
        [Display(Name = "Email")]
        public string Email { get; set; }
        public virtual ICollection<Putovanje> Putovanja { get; set; }
        public int? RacunId { get; set; }
        public virtual Racun Racun { get; set; }

        public Klijent()
        {
        }
    }
}
