using System.ComponentModel.DataAnnotations;

namespace PrivateTuition.Web.Models
{
    public class ChangePasswordModel
    {
        public string UserId { get; set; }
        [Required(ErrorMessage = "Bu alan zorunlu.")]
        public string NewPassword { get; set; }
        [Required(ErrorMessage = "Bu alan zorunlu.")]
        [Compare("Password", ErrorMessage = "Şifreler uyuşmuyor!")]
        public string ReNewPassword { get; set; }
    }
}
