using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrivateTuition.Entity
{
    public class LessonRequest  : BaseEntity  
    {
        public string Expectations { get; set; } // whats student needs, adress availability etc..
        public string? Address { get; set; }
        public string ContactNumber { get; set; }
        public DateTime? ResponseTime { get; set; }
        public bool IsApproved { get; set; }
        [AllowNull]
        public Student Student { get; set; }
        public int StudentId { get; set; }
        [AllowNull]
        public ShowCard ShowCard { get; set; }
        public int ShowCardId { get; set; }
        
    }
}
