using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrivateTuition.Entity
{
    public class SubjectCategory
    {
        public int SubjectId { get; set; }
        public Subject Subject { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        
    }
}
