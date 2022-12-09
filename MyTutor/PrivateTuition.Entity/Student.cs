using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrivateTuition.Entity
{
    public class Student : User
    {

        public ICollection<LessonRequest>? Requests { get; set; }
        public ICollection<Comment>? Comments { get; set; }

    }
}
