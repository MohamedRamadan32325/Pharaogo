using System.ComponentModel.DataAnnotations;

namespace WebApplication7.ViewModels
{
	public class RegisterViewModel
	{
		public string? Id { get; set; }

		[Required]
		public string? UserName { get; set; }

		public string? LastName { get; set; }

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

		[DataType(DataType.Upload)]
		public string? MobilePhone { get; set; }  // Optional field
	}

}
