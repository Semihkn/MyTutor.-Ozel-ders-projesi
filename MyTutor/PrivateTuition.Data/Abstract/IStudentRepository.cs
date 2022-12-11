using PrivateTuition.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrivateTuition.Data.Abstract
{
    public interface IStudentRepository : IRepository<Student>
    {
        Task<Student> FindStudentByMailAsync(string mail);
        Task<Student> GetStudentDetailsAsync(string url);

    }
}
