﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace authTest.Models
{
    public class Putovanje
    {
        public int Id { get; set; }
        public string Slika { get; set; }
        public string Destinacija { get; set; }
        public string Info { get; set; }
        public bool Aktuelno { get; set; }
        [Required(ErrorMessage = "Polje Datum polaska je obavezno")]
        [Display(Name = "Datum polaska")]
        public DateTime DatumPolaska { get; set; }
        [Required(ErrorMessage = "Polje Datum povratka je obavezno")]
        [Display(Name = "Datum povratka")]
        public DateTime DatumPovratka { get; set; }


        [Required(ErrorMessage = "Polje minimalni broj putnika je obavezno")]
        [Display(Name = "Broj putnika")]
        [Range(minimum: 10, maximum: 100, ErrorMessage = "Broj putnika mora biti u intervalu od 10 do 100")]
        public int MinBrojLjudi { get; set; }

        [Required(ErrorMessage = "Polje maximalni broj putnika je obavezno")]
        [Display(Name = "Broj putnika")]
        [Range(minimum: 200, maximum: 300, ErrorMessage = "Broj putnika mora biti u intervalu od 200 do 300")]

        public int MaxBrojLjudi { get; set; }
        public virtual Cijena Cijena { get; set; }
        public virtual ICollection<Korisnik> Putnici { get; set; }
  
        public Putovanje()
        {
        }
    }
}
 