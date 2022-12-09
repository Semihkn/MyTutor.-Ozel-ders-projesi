using PrivateTuition.Entity;
using System.ComponentModel.DataAnnotations;

namespace PrivateTuition.Web.Models
{
    public class SubjectModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Name alanı zorunludur.")]
        [MaxLength(100)]
        [MinLength(5)]
        public string Name { get; set; }
        public string Url { get; set; }
        public bool IsDeleted { get; set; }
        public List<ShowCard> ShowCards { get; set; }
    }
}
