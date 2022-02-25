using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace news_site.Models
{
    public class TeamMember
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(30, MinimumLength = 5)]
        public string Name { get; set; }
        [Required]
        public string Job { get; set; }
        public string Image { get; set; }

        [NotMapped]
        public IFormFile File { get; set; }
    }
}
