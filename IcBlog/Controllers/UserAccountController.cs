using Microsoft.AspNetCore.Mvc;
using IcBlog.Infrastructure.Services.Interface;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using IcBlog.Infrastructure.Models;
namespace IcBlog.Controllers
{
    public class UserAccountController : Controller
    {
        private readonly IUserService _userService;
        private readonly UserManager<ApplicationUser> _userManager;

        public  UserAccountController(IUserService userService, UserManager<ApplicationUser> userManager)
        {
            _userService = userService;
            _userManager = userManager;
        }
        public async Task<IActionResult> Index()
        {
            var userId = _userManager.GetUserId(User);
            if (userId == null)
            {
                return RedirectToAction("Login", "Account"); // Redirect to login if not logged in
            }

            var user = await _userService.GetUserByIdAsync(userId);
            return View(user);
        }
    }
}
