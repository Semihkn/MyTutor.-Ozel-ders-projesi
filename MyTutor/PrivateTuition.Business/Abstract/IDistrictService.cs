using PrivateTuition.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrivateTuition.Business.Abstract
{
    public interface IDistrictService
    {
        Task<List<District>> GetDistrictByCity(int CityID);
    }
}
