using PrivateTuition.Entity;
using System.ComponentModel.DataAnnotations;

namespace PrivateTuition.Web.Models
{
    public class SubjectWithCategoryModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Ders Adı Gerekli!")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "3 - 100")]
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public bool? IsApproved { get; set; }
        public List<Category> SelectedCategories { get; set; }
    }
}
