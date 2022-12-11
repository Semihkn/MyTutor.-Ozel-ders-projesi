using System.ComponentModel.DataAnnotations;

namespace PrivateTuition.Web.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Bu Alan Gerekli!")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required(ErrorMessage = "Bu Alan Gerekli!")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public string? ReturnUrl { get; set; }
        public bool RememberMe { get; set; }
    }
}
