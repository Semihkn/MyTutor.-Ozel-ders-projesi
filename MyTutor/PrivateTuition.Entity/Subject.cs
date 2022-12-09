using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrivateTuition.Entity
{
    public class Subject : BaseEntity
    {

        public ICollection<SubjectCategory> SubjectCategories { get; set; }
        public ICollection<ShowCard> ShowCards { get; set; }

    }
}
