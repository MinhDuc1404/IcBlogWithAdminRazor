﻿using IcBlog.Infrastructure.Data;
using IcBlog.Infrastructure.Models;
using IcBlog.Infrastructure.Services.Interface;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IcBlog.Infrastructure.Services
{
    public class CategoryServices : ICategoryServices
    {
        private readonly BlogContext _blogContext;

        public CategoryServices(BlogContext blogContext)
        {
            _blogContext = blogContext;
        }
        public async Task<List<Category>> GetListCategoryAsync()
        {
            return await _blogContext.Categories.ToListAsync();
        }
        public async Task<List<SelectListItem>> GetSelectListCategoryAsync()
        {
            return await _blogContext.Categories.Select(c => new SelectListItem
            {
                Value = c.CategoryID.ToString(),
                Text = c.Name
            }).ToListAsync();
        }
    }
}
