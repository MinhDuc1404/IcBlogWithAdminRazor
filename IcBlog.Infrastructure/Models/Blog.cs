using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IcBlog.Infrastructure.Models
{
    public class Blog
    {
        [Key]
        public int BlogID { get; set; }

        public ApplicationUser Author { get; set; }
        public string Title { get; set; }

        public string Content { get; set; }

        public string? Image { get; set; }

        public DateTime? DateTime { get; set; }
        public int CategoryID { get; set; }

        public Category Category { get; set; }
    }
}
