using Microsoft.EntityFrameworkCore;
using PrivateTuition.Data.Abstract;
using PrivateTuition.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrivateTuition.Data.Concrete.EFCore
{
    public class EFCoreDistrictRepository : EfCoreGenericRepository<District>, IDistrictRepository
    {
        public EFCoreDistrictRepository(PrivateTuitionContext dbContext) : base(dbContext)
        {
        }

        public async Task<List<District>> GetDistrictByCityId(int CityId)
        {
            
            return await context.Districts.Where(q => q.CityId == CityId).OrderBy(x => x.ilce_adi).ToListAsync();
            
        }
    }
}
