using PrivateTuition.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PrivateTuition.Business.Abstract
{
    public interface ISubjectService
    {
        #region Generics
        Task<Subject> GetByIdAsync(int id);
        Task<List<Subject>> GetAllAsync(Expression<Func<Subject, bool>> expression);
        Task CreateAsync(Subject subject);
        void Update(Subject subject);
        void Delete(Subject subject);
        #endregion

        #region Subject
        Task CreateAsync(Subject subject, int[] categoryIds);
        //Task UpdateIsApprovedAsync(Subject subject);
        Task<Subject> GetSubejctWithCategoryAsync(int id);
        Task<List<Subject>> GetSubjectsByCategory(int id);
        Task UpdateAsync(Subject subject, int[] categoryIds);
        void IsDelete(Subject subject);
        Task<List<Subject>> GetSubjectsByCategoryInPageAsync(string category, int page, int pageSize);
        Task<List<Category>> GetAllSubjectsAsync(bool isDeleted);
        Task<List<Category>> GetSubjectWithShowCardsAsync(int id);

        #endregion
    }
}
