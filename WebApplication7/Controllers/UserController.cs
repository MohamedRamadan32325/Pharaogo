using DEPI.Repositry;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.DotNet.Scaffolding.Shared.ProjectModel;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol.Plugins;
using System.Security.Claims;
using WebApplication7.Models;
using WebApplication7.ViewModels;

namespace WebApplication7.Controllers
{
	[Authorize]
	public class UserController : Controller
    {
        private readonly IWebHostEnvironment _webHostEnvironment;

        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;
        User_Repo user_repo = new User_Repo();
        DepiContext dbContext = new DepiContext();

        public UserController(UserManager<ApplicationUser> _userManager, SignInManager<ApplicationUser> _signInManager, IWebHostEnvironment webHostEnvironment, DepiContext context)
        {
            userManager = _userManager;
            signInManager = _signInManager;
            _webHostEnvironment = webHostEnvironment;
            dbContext = context;
        }
        
        public IActionResult Edit()
        {
            string id = User.FindFirstValue(ClaimTypes.NameIdentifier);
            return RedirectToAction("EditUser", new { id = id });
        }
        [HttpGet]
        
        public IActionResult EditUser(string id)
        {
			RegisterViewModel rr = user_repo.Update(id);
            return View(rr);
        }
        [HttpPost]
        public IActionResult EditUser(RegisterViewModel s)
        {
            user_repo.UpdateUser(s);
            return RedirectToAction("Index", "Home");
        }
    }
}
