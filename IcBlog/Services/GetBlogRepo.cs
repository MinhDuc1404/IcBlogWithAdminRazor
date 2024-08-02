using IcBlog.Infrastructure.Models;
using IcBlog.Infrastructure.Services.Interface;
using IcBlog.Models;
using IcBlog.Services.Interface;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace IcBlog.Services
{
    public class GetBlogRepo : IGetBlogRepo
    {
        private readonly IBlogServices _blogServices;
        private readonly ICategoryServices _categoryServices;
        private readonly UserManager<ApplicationUser> _userManager;

        public GetBlogRepo(IBlogServices blogServices, UserManager<ApplicationUser> userManager, ICategoryServices categoryServices)
        {
            _blogServices = blogServices;
            _userManager = userManager;
            _categoryServices = categoryServices;
        }
      
        public async Task<BlogIndexViewModel> GetBlogIndex(int? category)
        {
            if (category == null)
            {
                var blog = await _blogServices.GetListBlogAsync();
                
                return new BlogIndexViewModel
                {
                    Blogs = blog
                 };
            }
            else
            {
                var blog = await _blogServices.GetBlogWithCateAsync(category);
                return new BlogIndexViewModel
                {
                    Blogs = blog
                };
            }
           
        }
        public async Task<BlogDetailsViewModel> GetBlogDetail(int id)
        {
            var blog = await _blogServices.GetBlogAsync(id);
            return new BlogDetailsViewModel
            {
                Blog = blog
            };
        }
       public async Task<SearchViewModel> SearchBlog(string searching)
        {
            var blog = await _blogServices.GetBlogSearchingAsync(searching);
            return new SearchViewModel
            {
                Blogs = blog
            };
        }
        public async Task<Blog> CreateBlog(CreateBlogViewModel createBlogViewModel, ClaimsPrincipal claimsPrincipal)
        {
            var blog = createBlogViewModel.Blog;
            blog.Author = await _userManager.GetUserAsync(claimsPrincipal);
            blog.DateTime = DateTime.Now;
            
       
           return await _blogServices.AddBlog(blog);
           
        }
     
    }
}
