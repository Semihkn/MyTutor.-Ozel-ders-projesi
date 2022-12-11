using PrivateTuition.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PrivateTuition.Business.Abstract
{
    public interface ITeacherService
    {

        #region Generics
        Task<Teacher> GetByIdAsync(int id);
        Task<List<Teacher>> GetAllAsync(Expression<Func<Teacher, bool>> expression);
        Task CreateAsync(Teacher teacher);
        void Update(Teacher teacher);
        void Delete(Teacher teacher);
        #endregion

        #region Teacher
        Task<Teacher> FindTeacherByMailAsync(string mail);
        Task<List<Teacher>> GetAllTeachersAsync();
        Task<Teacher> GetTeacherDetailsAsync(string url);
        Task<List<Teacher>> GetTeachersByCategoryAsync(string category, int page, int pageSize);
        Task<int> GetTeachersCountByCategoryAsync(string category);
        Task UpdateAsync(Teacher teacher);
        #endregion

    }
}
