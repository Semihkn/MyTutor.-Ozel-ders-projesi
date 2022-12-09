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
    public class ShowCardManager : IShowCardService
    {
        private IShowCardRepository _showCardRepository;

        public ShowCardManager(IShowCardRepository showCardRepository)
        {
            _showCardRepository = showCardRepository;
        }

        public async Task CreateAsync(ShowCard showCard)
        {
            await _showCardRepository.CreateAsync(showCard);
        }

        public async Task CreateAsync(ShowCard showCard, int categoryId)
        {
            await _showCardRepository.CreateAsync(showCard,categoryId);

        }

        public void Delete(ShowCard showCard)
        {
            _showCardRepository.Delete(showCard);
        }
        public async Task<List<ShowCard>> GetSearchResultAsync(City city, District district, Category category, Subject subject)
        {
            return await _showCardRepository.GetSearchResultAsync(city, district, category, subject);

        }
        public async Task<List<ShowCard>> GetAllAsync(Expression<Func<ShowCard, bool>> expression)
        {
            return await _showCardRepository.GetAllAsync(expression);
        }

        public async Task<List<ShowCard>> GetAllShowCardsAsync()
        {
            return await _showCardRepository.GetAllShowCardsAsync();
        }

        public async Task<ShowCard> GetByIdAsync(int id)
        {
            return await _showCardRepository.GetByIdAsync(id);
        }

        public async Task<int> GetCountByCategoryAsync(string category)
        {
            return await _showCardRepository.GetCountByCategoryAsync(category);
        }

        public async Task<List<ShowCard>> GetHomeShowCardsAsync(string category)
        {
            return await _showCardRepository.GetHomeShowCardsAsync(category);
        }

        public async Task<List<ShowCard>> GetInActivatedShowCardsAsync()
        {
            return await _showCardRepository.GetInActivatedShowCardsAsync();

        }

        public async Task<List<ShowCard>> GetSearchResultAsync(string searchString)
        {
            return await _showCardRepository.GetSearchResultAsync(searchString);
        }

        public async Task<ShowCard> GetShowCardDetailsAsync(string url)
        {
            return await _showCardRepository.GetShowCardDetailsAsync(url);
        }

        public async Task<List<ShowCard>> GetShowCardsByCategoryAsync(string category, int page, int pageSize)
        {
           return await _showCardRepository.GetShowCardsByCategoryAsync(category, page, pageSize);
        }

        public async Task<ShowCard> GetShowCardWithCategoriesAsync(int id)
        {
           return await _showCardRepository.GetShowCardWithCategoriesAsync(id);
        }

        public void IsDelete(ShowCard showCard)
        {
            _showCardRepository.IsActive(showCard);
        }

        public void Update(ShowCard showCard)
        {
            _showCardRepository.Update(showCard);
        }

        public async Task UpdateAsync(ShowCard showCard, int subjectId)
        {
            await _showCardRepository.UpdateAsync(showCard, subjectId);

        }

        public async Task<List<ShowCard>> GetShowCardsByTeacherAsync(int teacherId)
        {
            return await _showCardRepository.GetShowCardsByTeacherAsync(teacherId);
        }
    }
}
