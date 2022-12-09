using PrivateTuition.Entity.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrivateTuition.Entity
{
    public class ShowCard : BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal LessonPrice { get; set; }
        public WorkMethods WorkMethods { get; set; } //Online, studentHome, teacherOffice, 
        public Subject Subject{ get; set; }
        public int SubjectId { get; set; }

        public City City { get; set; }
        public int CityId { get; set; }


        public Teacher Teacher { get; set; }
        public int TeacherId { get; set; }
        public ICollection<LessonRequest> Requests { get; set; } // Request area from students 
        
    }
}
