using PrivateTuition.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PrivateTuition.Business.Abstract
{
    public interface IStudentService
    {
        Task CreateAsync(Student student);
        Task<Student> GetByIdAsync(int id);
        Task<List<Student>> GetAllAsync(Expression<Func<Student, bool>> expression);
        void Update(Student student);
        void Delete(Student student);
    }
}
