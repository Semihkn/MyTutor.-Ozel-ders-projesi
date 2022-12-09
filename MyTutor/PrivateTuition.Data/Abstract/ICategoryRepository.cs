using PrivateTuition.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrivateTuition.Data.Abstract
{
    public interface ICategoryRepository : IRepository<Category>
    {
        //All signatures found here in IRepository are inherited as configured according to Category.
        void IsDelete(Category category);
        Task<List<Category>> GetAllCategoriesAsync(bool isDeleted);
        Task<List<Category>> GetCategoryWithSubjectsAsync(int id);
        Task<List<Category>> GetCategoryWithShowCardsAsync(int id);
        Task<Category> GetCategoryWithOneSubjectAsync(int id);


    }
}
