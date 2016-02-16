using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bizcard.online.Models
{
    public class AssignedCards
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please add a valid email address")]
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        [Display(Name = "To")]
        public string ToEmail { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        [Display(Name = "From")]
        public string FromEmail { get; set; }  
        [Required(ErrorMessage = "Required")] 
        public string Message { get; set; }
        public int CardId { get; set; }

        public virtual Cards Cards { get; set; } 
    }

}
