using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace news_site.Models
{
    public class ContactUs
    {
        public int Id { get; set; }
        [Required]
        [StringLength(15,MinimumLength =5)]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Subject { get; set; }
        public string Message { get; set; } 
 
    }
}
