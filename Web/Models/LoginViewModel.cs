using System.ComponentModel.DataAnnotations;

namespace Web.Models
{
	public class LoginViewModel
	{
		[Required(ErrorMessage = "Имейлът е задължителен")]
		public string Email { get; set; }

		[Required(ErrorMessage = "Паролата е задължителна")]
		public string Password { get; set; }
	}
}