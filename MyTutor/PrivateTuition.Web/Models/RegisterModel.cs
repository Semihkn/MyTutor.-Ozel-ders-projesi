using System.ComponentModel.DataAnnotations;

namespace PrivateTuition.Web.Models
{
    public class RegisterModel
    {

        [Required(ErrorMessage = "Bu alan zorunlu.")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Bu alan zorunlu.")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Bu alan zorunlu.")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Bu alan zorunlu.")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required(ErrorMessage = "Bu alan zorunlu.")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Şifreler uyuşmuyor!")]
        public string Password { get; set; }  
        [Required(ErrorMessage = "Bu alan zorunlu.")]
        [DataType(DataType.Password)]
        public string RePassword { get; set; }
        public bool IsStudent { get; set; }
        public bool IsTeacher { get; set; }


    }
}
