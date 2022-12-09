using PrivateTuition.Business.Abstract;
using PrivateTuition.Data.Abstract;
using PrivateTuition.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PrivateTuition.Business.Concrete
{
    public class CitiesManager : ICitiesService
    {
        private ICitiesRepository _citiesRepository;
        public CitiesManager(ICitiesRepository citiesRepository)
        {
            _citiesRepository = citiesRepository;
        }

        public async Task  BulkInsert(List<City> cities)
        {
           await _citiesRepository.BulkInsert(cities);
        }

        public Task CreateAsync(City city)
        {
            throw new NotImplementedException();
        }

        public void Delete(City city)
        {
            throw new NotImplementedException();
        }

        public async Task<List<City>> GetAllAsync(Expression<Func<City, bool>> expression)
        {
            return await _citiesRepository.GetAllAsync(expression);
        }

        public Task<City> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(City city)
        {
            throw new NotImplementedException();
        }
    }
}
