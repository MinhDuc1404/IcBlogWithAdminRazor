using IcBlog.Infrastructure.Services.Interface;
using IcBlog.Services.Interface;
using Microsoft.AspNetCore.Mvc;
using IcBlog.Models;
using Microsoft.AspNetCore.Identity;

namespace IcBlog.Controllers
{
	public class BlogController : Controller
	{
        private readonly IGetBlogRepo _blogRepo;
        private readonly ICategoryServices _categoryServices;
   
		public BlogController(IGetBlogRepo blogRepo, ICategoryServices categoryServices)
        {
            _blogRepo = blogRepo;
            _categoryServices = categoryServices;
        }

        [Route("blog.html/{category:int?}")]
        public async Task<IActionResult> Index(int? category)
		{
          return View( await _blogRepo.GetBlogIndex(category));
        }
        [Route("blog-details.html/{id:int}")]
        public async Task<IActionResult> Details(int id)
        {
            return View(await _blogRepo.GetBlogDetail(id));
        }
        public async Task<IActionResult> Create()
        {
            var category = await _categoryServices.GetSelectListCategoryAsync();
            if (category == null || !category.Any())
            {
                // Logging hoặc xử lý khi không có danh mục nào
                 
            }
            ViewBag.Categories = category;
            
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateBlogViewModel createViewModel)
        {
            await _blogRepo.CreateBlog(createViewModel, User);
            return RedirectToAction("Create");
        }

        public async Task<IActionResult> Search(string searching)
        {
            return View(await _blogRepo.SearchBlog(searching));
        }
	}
}
