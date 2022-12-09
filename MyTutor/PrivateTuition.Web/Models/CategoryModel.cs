using Microsoft.AspNetCore.Identity;
using PrivateTuition.Entity;
using PrivateTuition.Web.Identity;
using System.ComponentModel.DataAnnotations;

namespace PrivateTuition.Web.Models
{
    public class CategoryModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Name alanı zorunludur.")]
        [MaxLength(30)]
        [MinLength(3)]
        public string Name { get; set; }
        public string Url { get; set; }
        public bool IsDeleted { get; set; }      
        public List<ShowCard> ShowCards { get; set; }
        public List<Subject> Subjects { get; set; }
    }
    public class CategoryDetails
    {        
        public Category Category { get; set; }
        public List<Subject> Members { get; set; }
        public List<Subject> NonMembers { get; set; }
    }

    public class CategoryEditModel
    {
        public string CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string[] IdsToAdd { get; set; }
        public string[] IdsToRemove { get; set; }
    }
}
