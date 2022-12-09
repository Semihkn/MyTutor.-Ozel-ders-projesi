using PrivateTuition.Data.Abstract;
using PrivateTuition.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrivateTuition.Data.Concrete.EFCore
{
    public class EFCoreCitiesRepository : EfCoreGenericRepository<City>, ICitiesRepository
    {
        public EFCoreCitiesRepository(PrivateTuitionContext dbContext) : base(dbContext)
        {
        }

        public async Task BulkInsert(List<City> cities)
        {
            await _dbContext.AddRangeAsync(cities);
            await _dbContext.SaveChangesAsync();
        }
    }
}
