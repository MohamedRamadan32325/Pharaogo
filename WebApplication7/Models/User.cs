using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace WebApplication7.Models
{
	public class User:ApplicationUser
	{
		public int Age { get; set; }
		public string LastName { get; set; }
	}
}
