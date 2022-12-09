using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrivateTuition.Entity
{
    public class City : BaseEntity
    {
        public string il_adi { get; set; }
        public string plaka_kodu { get; set; }
        public List<District> ilceler { get; set; }
        //public ICollection<ShowCard> ShowCards { get; set; }
        
    }
    public class District : BaseEntity
    {
        public string ilce_adi { get; set; }

        public int CityId { get; set; }

        public City City { get; set; }

    }
    public class Root
    {
        public List<City> data { get; set; }
    }
}
