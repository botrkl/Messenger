using System.ComponentModel.DataAnnotations;

namespace FlashApp.Api.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "can't be blank!")]
        public string Username { get; set; }

        [Required(ErrorMessage = "can't be blank!")]
        public string Password { get; set; }
    }
}
