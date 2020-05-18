using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace authTest.Models
{
    public class Korisnik
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int? AgencijaId { get; set; }
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
