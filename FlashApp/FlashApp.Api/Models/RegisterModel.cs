using System.ComponentModel.DataAnnotations;

namespace FlashApp.Api.Models
{
    public class RegisterDTO
    {
        [Required(ErrorMessage = "Username can't be blank!")]
        public string Username { get; set; }
        public string? Nickname { get; set; }
        [EmailAddress(ErrorMessage = "invalid email!")]
        public string? Email { get; set; }
        [Required(ErrorMessage = "Password can't be blank!")]
        public string Password { get; set; }
    }
}
