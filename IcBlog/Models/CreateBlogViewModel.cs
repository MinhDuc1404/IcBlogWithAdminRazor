using IcBlog.Infrastructure.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace IcBlog.Models
{
    public class CreateBlogViewModel
    {
        public Blog Blog { get; set; }
        //public string NewCategoryName { get; set; } // For new category
        public List<SelectListItem> Categories { get; set; }
    }
}
