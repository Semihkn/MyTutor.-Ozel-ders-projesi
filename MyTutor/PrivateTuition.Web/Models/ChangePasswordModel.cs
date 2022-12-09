using System.ComponentModel.DataAnnotations;

namespace PrivateTuition.Web.Models
{
    public class ChangePasswordModel
    {
        public string UserId { get; set; }
        [Display(Name = "Current Password")]
        [Required(ErrorMessage = "Current password must be provided.")]
        [DataType(DataType.Password)]
        public string OldPassword { get; set; }
        [Display(Name = "New Password")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Bu alan zorunlu.")]
        public string NewPassword { get; set; }
        [Display(Name = "New Repassword")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Bu alan zorunlu.")]
        [Compare("Password", ErrorMessage = "Şifreler uyuşmuyor!")]
        public string ReNewPassword { get; set; }
    }
}
