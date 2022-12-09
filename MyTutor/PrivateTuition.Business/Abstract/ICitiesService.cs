using PrivateTuition.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PrivateTuition.Business.Abstract
{
    public interface ICitiesService
    {
        #region Generics
        Task<City> GetByIdAsync(int id);
        Task<List<City>> GetAllAsync(Expression<Func<City, bool>> expression);
        Task CreateAsync(City city);
        Task BulkInsert(List<City> cities);
        void Update(City city);
        void Delete(City city);

        #endregion 
    }
}
