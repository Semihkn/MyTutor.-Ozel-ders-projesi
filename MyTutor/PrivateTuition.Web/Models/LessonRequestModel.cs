using PrivateTuition.Entity;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace PrivateTuition.Web.Models
{
    public class LessonRequestModel
    {
        [Required]
        [AllowNull]
        public string Expectations { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        [DataType(DataType.PhoneNumber)]
        public string ContactNumber { get; set; }
        [Required]
        public bool FirstLesson { get; set; }
        [Required]
        public bool ForWho { get; set; }
        public bool IsApproved { get; set; }
        public DateTime? ResponseTime { get; set; }
        public DateTime LessonRequestTime { get; set; }= DateTime.Now;
        public ShowCard ShowCard { get; set; }
        public Student Student { get; set; }
        //public Teacher Teacher  { get; set;}

    }
}
