using PrivateTuition.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrivateTuition.Data.Abstract
{
    public interface ISubjectRepository : IRepository<Subject>
    {
        //All signatures found here in IRepository are inherited as configured according to Subject.
        Task CreateAsync(Subject subject, int[] categoryIds);
        //Task UpdateIsApprovedAsync(Subject subject);
        Task<Subject> GetSubejctWithCategoryAsync(int id);
        Task<List<Subject>> GetSubjectsByCategoryAsync(int id);
        Task<List<Subject>> GetSubjectsByCategoryInPageAsync(string category, int page, int pageSize);
        Task UpdateAsync(Subject subject, int[] categoryIds);
        void IsDelete(Subject subject);

        Task<List<Category>> GetAllSubjectsAsync(bool isDeleted);
        Task<List<Category>> GetSubjectWithShowCardsAsync(int id);

    }
}
