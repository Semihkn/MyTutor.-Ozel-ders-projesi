using PrivateTuition.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrivateTuition.Data.Abstract
{
    public interface IShowCardRepository : IRepository<ShowCard>
    {
        Task CreateAsync(ShowCard showCard, int categoryId);
        Task<List<ShowCard>> GetHomeShowCardsAsync(string category);
        Task<ShowCard> GetShowCardDetailsAsync(string url);
        Task<List<ShowCard>> GetShowCardsByCategoryAsync(string category, int page, int pageSize);
        Task<int> GetCountByCategoryAsync(string category);
        Task<List<ShowCard>> GetSearchResultAsync(string searchString); // searching any showcard
        Task<ShowCard> GetShowCardWithCategoriesAsync(int id); 
        Task<List<ShowCard>> GetAllShowCardsAsync();
        Task<List<ShowCard>> GetInActivatedShowCardsAsync();
        Task<List<ShowCard>> GetShowCardsByTeacherAsync(int teacherId);
        void IsActive(ShowCard showCard);
        Task UpdateAsync(ShowCard showCard, int subjectId);
        Task<List<ShowCard>> GetSearchResultAsync(City city, District district, Category category, Subject subject);


    }
}
