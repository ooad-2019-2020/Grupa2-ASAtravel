using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace authTest.Models
{
    public class Iterator
    {
        public int Id { get; set; }
        [NotMapped] public virtual ICollection<double> prihodi { get; set; }
        public int trenutniIndeks { get; set; }

    }
}