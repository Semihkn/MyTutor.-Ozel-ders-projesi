using PrivateTuition.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrivateTuition.Data.Abstract
{
    public interface ITeacherRepository : IRepository<Teacher>
    {
        Task<List<Teacher>> GetAllTeachersAsync();
        Task<Teacher> GetTeacherDetailsAsync(string url);
        Task<List<Teacher>> GetTeachersByCategoryAsync(string category, int page, int pageSize);
        Task<int> GetTeachersCountByCategoryAsync(string category);
        Task<Teacher> FindTeacherByMailAsync(string mail);

    }
}
