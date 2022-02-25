using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace news_site.Models
{
    public class News
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime Date { get; set; }
        public string Image { get; set; }
        public string Topic { get; set; }


        // The Next line is a aliternative way to use label like the label in html
        //[DisplayName("Category")]
        [ForeignKey("Category")]
        public int CategoryId { get; set; }
        public Category category { get; set; }
        //  [NotMapped] means that it will be used but bot storead in database
        [NotMapped]
        public FormFile File { get; set; }
    }
}
