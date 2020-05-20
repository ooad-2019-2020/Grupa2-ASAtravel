using System.Collections.Generic;

namespace authTest.Models
{
    public class Iterator
    {
        public virtual ICollection<double> prihodi { get; set; }
        public int trenutniIndeks { get; set; }

    }
}