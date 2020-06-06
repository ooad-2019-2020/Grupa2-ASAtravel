using System;
using System.Collections.Generic;

namespace WebAPI
{
    public partial class Iterator
    {
        public Iterator()
        {
            Agencija = new HashSet<Agencija>();
        }

        public int Id { get; set; }
        public double IndeksTrenutni { get; set; }

        public virtual ICollection<Agencija> Agencija { get; set; }
    }
}
