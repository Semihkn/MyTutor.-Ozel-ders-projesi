using PrivateTuition.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrivateTuition.Data.Abstract
{
    public interface IDistrictRepository : IRepository<District>
    {
          Task<List<District>> GetDistrictByCityId(int CityId);
    }
}
