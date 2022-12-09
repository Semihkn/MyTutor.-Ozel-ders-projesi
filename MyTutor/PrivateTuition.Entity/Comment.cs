using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrivateTuition.Entity
{
    public class Comment : BaseEntity
    {
        public string Title { get; set; }
        public string StdComment { get; set; }
        public byte Point { get; set; }
        public Teacher Teacher { get; set; }
        public int TeacherId { get; set; }

        public Student Student { get; set; }
        public int  StudentId { get; set; }

    }
}
