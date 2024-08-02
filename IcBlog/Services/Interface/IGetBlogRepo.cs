﻿using IcBlog.Infrastructure.Models;
using IcBlog.Models;
using System.Security.Claims;
using System.Threading.Tasks;

namespace IcBlog.Services.Interface
{
    public interface IGetBlogRepo
    {
        
        Task<BlogIndexViewModel> GetBlogIndex(int? category);
        Task<BlogDetailsViewModel> GetBlogDetail(int id);

        Task<SearchViewModel> SearchBlog(string searching);

        Task<Blog> CreateBlog(CreateBlogViewModel createBlogViewModel, ClaimsPrincipal claimsPrincipal);

       
    }
}
