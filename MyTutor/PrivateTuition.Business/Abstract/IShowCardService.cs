using PrivateTuition.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PrivateTuition.Business.Abstract
{
    public interface IShowCardService
    {
        #region Generics
        Task<ShowCard> GetByIdAsync(int id);
        Task<List<ShowCard>> GetAllAsync(Expression<Func<ShowCard, bool>> expression);
        Task CreateAsync(ShowCard showCard);
        void Update(ShowCard showCard);
        void Delete(ShowCard showCard);
        #endregion

        #region ShowCard
        Task CreateAsync(ShowCard showCard, int categoryId);
        Task<List<ShowCard>> GetHomeShowCardsAsync(string category);
        Task<ShowCard> GetShowCardDetailsAsync(string url);
        Task<List<ShowCard>> GetShowCardsByCategoryAsync(string category, int page, int pageSize);
        Task<int> GetCountByCategoryAsync(string category);
        Task<List<ShowCard>> GetSearchResultAsync(string searchString);
        Task<ShowCard> GetShowCardWithCategoriesAsync(int id);
        Task<List<ShowCard>> GetAllShowCardsAsync();
        Task<List<ShowCard>> GetInActivatedShowCardsAsync();
        void IsDelete(ShowCard showCard);
        Task UpdateAsync(ShowCard showCard, int subjectId);
        Task<List<ShowCard>> GetSearchResultAsync(City city, District district, Category category, Subject subject);

        Task<List<ShowCard>> GetShowCardsByTeacherAsync(int teacherId);

        #endregion


    }
}
