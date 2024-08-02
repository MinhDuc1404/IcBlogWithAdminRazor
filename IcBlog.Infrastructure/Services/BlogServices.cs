using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IcBlog.Infrastructure.Data;
using IcBlog.Infrastructure.Models;
using IcBlog.Infrastructure.Services.Interface;
using Microsoft.EntityFrameworkCore;

namespace IcBlog.Infrastructure.Services
{
    public class BlogServices : IBlogServices
    {
        private readonly BlogContext _blogContext;

        public BlogServices(BlogContext blogContext)
        {  
            _blogContext = blogContext; 
        }
        public async Task<List<Blog>> GetListBlogAsync()
        {
            return await _blogContext.Blogs
                .Include(b => b.Category)
                .Include(b=>b.Author)
                .OrderByDescending(b=>b.DateTime)
                .ToListAsync();
        }
        public async Task<List<Blog>> GetBlogWithCateAsync(int? category)
        {
            return await _blogContext.Blogs
                .Include(b => b.Category)
                .Include(b => b.Author)
                .Where(b => b.Category.CategoryID == category)
                .OrderByDescending(b=>b.DateTime)
                .ToListAsync();
        }
        public async Task<List<Blog>> GetBlogSearchingAsync(string searching)
        {
            return await _blogContext.Blogs
                .Include(b => b.Category)
                .Include(b => b.Author)
                .Where(b=>b.Title.Contains(searching)).ToListAsync();
        }
        public async Task<Blog> GetBlogAsync(int id)
        {
            return await _blogContext.Blogs
                .Include(b => b.Category)
                .Include(b => b.Author)
                .Where(b => b.BlogID == id)
                .FirstOrDefaultAsync();
        }
        public async Task<Blog> AddBlog(Blog blog)
        {
            
            _blogContext.Add(blog);
           await _blogContext.SaveChangesAsync();
            return blog;  
        }
     
      
    }
}
