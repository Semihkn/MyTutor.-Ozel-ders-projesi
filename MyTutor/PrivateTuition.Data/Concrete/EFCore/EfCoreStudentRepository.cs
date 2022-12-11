using Microsoft.EntityFrameworkCore;
using PrivateTuition.Data.Abstract;
using PrivateTuition.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrivateTuition.Data.Concrete.EFCore
{
    public class EfCoreStudentRepository : EfCoreGenericRepository<Student>, IStudentRepository
    {
        public EfCoreStudentRepository(PrivateTuitionContext dbContext) : base(dbContext)
        {
        }

        public async Task<Student> FindStudentByMailAsync(string mail)
        {
            return await context
              .Students
              .Where(s => s.Mail == mail)
              .FirstOrDefaultAsync();
        }

        public async Task<Student> GetStudentDetailsAsync(string url)
        {
            return await context
              .Students
              .Include(s => s.Comments)
              .Include(s => s.Requests)
              .Where(s => s.Url == url)
              .FirstOrDefaultAsync();
        }
    }
}
