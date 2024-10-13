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
    public class UserController : Controller
    {
        private readonly IWebHostEnvironment _webHostEnvironment;

        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;
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
            User ss = new User();
            ss = dbContext.User.FirstOrDefault(x => x.Id == id);
            RegisterViewModel registerSeekr = new RegisterViewModel();
        
            registerSeekr.UserName = ss.UserName;
            registerSeekr.Email = ss.Email;
            string Idd = ss.Id;
            //registerSeekr.urll = ss.ImageUrl;

            return View(registerSeekr);
        }
        [HttpPost]
        public IActionResult EditUser(RegisterViewModel s)
        {

            User ss = dbContext.User.FirstOrDefault(x => x.Id == s.Id);
            ss.UserName = s.UserName;
            ss.LastName = s.LastName;
            //ss.Address = s.Addresss;
            ss.Email = s.Email;
            ss.PhoneNumber = s.MobilePhone;
            

            //if (s.Image != null)
            //{
            //    var unfile = ImageSaver.SaveImage(s.Image, _webHostEnvironment);
            //    ss.ImageUrl = unfile.Result;

            //}

            string Idd = ss.Id;

            ViewBag.IDDD = Idd;
            dbContext.Update(ss);
            dbContext.SaveChanges();

            return RedirectToAction("Index", "Home");

        }
    }
}
