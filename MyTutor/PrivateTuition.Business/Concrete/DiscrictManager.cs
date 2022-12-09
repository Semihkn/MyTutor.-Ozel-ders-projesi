using PrivateTuition.Business.Abstract;
using PrivateTuition.Data.Abstract;
using PrivateTuition.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrivateTuition.Business.Concrete
{
    public class DistrictManager : IDistrictService
    {
        private IDistrictRepository _districtRepository;
        public DistrictManager(IDistrictRepository districtRepository)
        {
            _districtRepository = districtRepository;
        }
        public async Task<List<District>> GetDistrictByCity(int CityID)
        {
            
            return await _districtRepository.GetDistrictByCityId(CityID);
           
        }
    }
}
