using Microsoft.AspNetCore.Http;
using PrivateTuition.Entity.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrivateTuition.Entity
{
    public class Teacher : User
    {
        public string TeacherInfo { get; set; }  // The information about teacher            
        public TeacherStatue TeacherStatue { get; set; } // Approved, New , Medium,Leader, Super etc..
        public byte RatingPoint { get; set; }  // Teachers average ratings given by students
        public string? Professions { get; set; }
        public string? ResponseRange { get; set; } //same day or a few days
        public int TotalLesson { get; set; } // How many request completed
        public string? Certificate { get; set; } //Teacher' diploma or sufficiency certificate

     
        public  ICollection<ShowCard> ShowCards { get; set; }            
        public ICollection<Comment>? Comments { get; set; }
    }

}
