﻿using IcBlog.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IcBlog.Infrastructure.Services.Interface
{
    public interface IBlogServices
    {
        Task<List<Blog>> GetListBlogAsync();
        Task<List<Blog>> GetBlogWithCateAsync(int? category);
        Task<Blog> GetBlogAsync(int id);
        Task<List<Blog>> GetBlogSearchingAsync(string searching);


        Task<Blog> AddBlog(Blog blog);
    }
}
