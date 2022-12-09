using PrivateTuition.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrivateTuition.Data.Abstract
{
    public interface ICitiesRepository : IRepository<City>
    {
        Task BulkInsert(List<City> cities);
    }
}
