using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bizcard.online.Models
{
    public class AssignedCards
    {
        public int Id { get; set; }
        public string ToEmail { get; set; }
        public string FromEmail { get; set; }
        public string Message { get; set; }
        public int CardId { get; set; }

        public virtual Cards Cards { get; set; } 
    }

}
