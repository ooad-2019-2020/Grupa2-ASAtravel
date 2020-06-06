using authTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASA.Models
{
     
        public class Prijava
        {
            private static ASAContext _context;
            public static Prijava PrijaviSe { get; set; }

            public Prijava(ASAContext context)
            {
                _context = context;
            }
            public Korisnik? provjera(string username, string password)
            {
                IQueryable<Korisnik> korisnici = _context.Korisnik.Where(k => k.Username == username && k.Password == password);
                if (korisnici.Any())
                {
                    return korisnici.First();
                }
                return null;
            }
        }
    }


