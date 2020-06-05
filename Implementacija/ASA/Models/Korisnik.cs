using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace authTest.Models
{
    public class Korisnik
    {
      
        [Required(ErrorMessage = "Polje je obavezno")]
        [Display(Name = "Korisnik")]
        public int Id { get; set; }
        public string Username { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public int AgencijaId { get; set; }
        public virtual Agencija Agencija { get; set; }

        protected Korisnik(string username, string password)
        {
            Username = username;
            Password = password;
        }

        public Korisnik()
        {
        }
    }
}
