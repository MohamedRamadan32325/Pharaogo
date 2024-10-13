using System.ComponentModel.DataAnnotations;

namespace WebApplication7.ViewModels
{
	public class RegisterViewModel
	{
		public string? Id { get; set; }
		public string? LastName { get; set; }
		public string? MobilePhone { get; set; }
		[Required]
		public string UserName { get; set; }

		[Required]
		[EmailAddress]
		public string Email { get; set; }

		[DataType(DataType.Password)]
		[Required]
		public string Password { get; set; }

		[DataType(DataType.Password)]
		[Required]
		[Compare("Password")]
		public string confirmPassword { get; set; }

	
	}

}
