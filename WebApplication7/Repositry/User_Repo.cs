using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication7.Models;
using WebApplication7.ViewModels;


namespace DEPI.Repositry
{
	public class User_Repo
	{
		DepiContext dbContext = new DepiContext();
        public RegisterViewModel Update(string id)
        {
			User ss = new User();
			ss = dbContext.User.FirstOrDefault(x => x.Id == id);
			RegisterViewModel registerSeekr = new RegisterViewModel();

			registerSeekr.UserName = ss.UserName;
			registerSeekr.Email = ss.Email;
			registerSeekr.LastName = ss.LastName;
			registerSeekr.MobilePhone = ss.PhoneNumber;
			string Idd = ss.Id;
			return registerSeekr;
		}
		public void UpdateUser(RegisterViewModel s)
		{
			User ss = dbContext.User.FirstOrDefault(x => x.Id == s.Id);
			ss.UserName = s.UserName;
			ss.LastName = s.LastName;
			ss.Email = s.Email;
			ss.PhoneNumber = s.MobilePhone;
			//if (s.Image != null)
			//{
			//    var unfile = ImageSaver.SaveImage(s.Image, _webHostEnvironment);
			//    ss.ImageUrl = unfile.Result;
			//}
			//string Idd = ss.Id;
			//ViewBag.IDDD = Idd;
			dbContext.Update(ss);
			dbContext.SaveChanges();
		}
		public bool DeleteUser(string id)
		{
            
            User usertodelete = dbContext.User.FirstOrDefault(x => x.Id == id);
			if (usertodelete != null)
			{
				dbContext.User.Remove(usertodelete);
				dbContext.SaveChanges();
				return true;
			}
			else
			{
				return false;
			}

			
        }
    }
}
