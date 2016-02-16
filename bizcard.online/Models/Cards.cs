using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bizcard.online.Models
{
    public class Cards
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageName { get; set; }

        public virtual ICollection<AssignedCards> AssignedCards { get; set; }
    }
}
