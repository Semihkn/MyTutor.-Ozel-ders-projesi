using PrivateTuition.Entity;
using PrivateTuition.Entity.Enum;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace PrivateTuition.Web.Models
{
    public class ShowCardModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "İlan başlığı gerekli!")]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "5-50 arasında karakter giriniz.")]
        public string? Title { get; set; }

        [Required(ErrorMessage = "Ücret yazılmalı!")]
        [Range(0, 10000, ErrorMessage = "0-10000 arasında")]
        [RegularExpression(@"^(0|-?\d{0,16}(\.\d{0,0})?)$")]
        public decimal LessonPrice { get; set; }

        [Required(ErrorMessage = "Hakkıda kısmı gerekli!")]
        [StringLength(150, MinimumLength = 15, ErrorMessage = "15-150 arası karakter giriniz")]
        public string Description { get; set; }

        public string ImageUrl { get; set; }
        
        public bool IsDeleted { get; set; }


        public string WorkMethods { get; set; } //Online, studentHome, teacherOffice, 
       
        public int SubjectId { get; set; }
        public int CategoryId { get; set; }
        public int CityId { get; set; }
        public int TeacherId { get; set; }

        [AllowNull]
        public Category SelectedCategory{ get; set; } = null!;
        public Subject SelectedSubject { get; set; }
        public City SelectedCity { get; set; }
        public District SelectedDistrict { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
    }
}
