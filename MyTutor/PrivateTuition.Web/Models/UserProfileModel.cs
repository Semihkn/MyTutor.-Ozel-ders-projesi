using PrivateTuition.Entity;
using System.ComponentModel.DataAnnotations;

namespace PrivateTuition.Web.Models
{
    public class UserProfileModel
    {
        public string Name { get; set; }
        public string UserId { get; set; }
        public string UserName { get; set; }
        [Required(ErrorMessage = "Gerekli Alam!")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Gerekli Alam!")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Gerekli Alam!")]
        public string Description { get; set; }
        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "Gerekli Alam!")]
        public string Email { get; set; }
        public string Job { get; set; }
        public string Gender { get; set; }
        public string AvatarUrl { get; set; }
        [Required(ErrorMessage = "Gerekli Alam!")]
        public string City { get; set; }
        [Required(ErrorMessage = "Gerekli Alam!")]
        public string District { get; set; }
        [DataType(DataType.PhoneNumber)]
        [Required(ErrorMessage = "Gerekli Alam!")]
        public string PhoneNumber { get; set; }
        public ICollection<string> Roles { get; set; }      
        public IEnumerable<string> SelectedRoles { get; set; }
        [Display(Name = "Current Password")]
        [Required(ErrorMessage = "Current password must be provided.")]
        [DataType(DataType.Password)]
        public string OldPassword { get; set; }
        [Display(Name = "New Password")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Bu alan zorunlu.")]
        [Compare("NewPassword", ErrorMessage = "Şifreler uyuşmuyor!")]
        public string NewPassword { get; set; }
        [Display(Name = "ReNew Repassword")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Bu alan zorunlu.")]
        public string ReNewPassword { get; set; }
        //public IEnumerable<ShowCard> ShowCards { get; set; }
        //public IEnumerable<Comment> Comments { get; set;}
    }
}
