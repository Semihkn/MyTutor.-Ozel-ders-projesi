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
    public class EfCoreTeacherRepository : EfCoreGenericRepository<Teacher>, ITeacherRepository
    {
        public EfCoreTeacherRepository(PrivateTuitionContext dbContext) : base(dbContext)
        {
        }

        public async Task<List<Teacher>> GetAllTeachersAsync()
        {
            return await context
                .Teachers                
                .Include(t => t.ShowCards)
                .Where(sc => sc.IsDeleted == false)
                .ToListAsync();
        }

        public Task<int> GetTeachersCountByCategoryAsync(string category)
        {
            throw new NotImplementedException();

            //var teachers = context.Teachers.AsQueryable();
            //if (!string.IsNullOrEmpty(category))
            //{
            //    teachers = teachers
            //       .Include(t => t.ShowCards)
            //       .ThenInclude(t => t.Subject.SubjectCategories)
            //       .ThenInclude(sc => sc.Category)                  
            //       .Select(s => s.ShowCards).Select(s=>s.SubjectCategories.Any(sc=>sc.Category.Url==category));
            //};

            //return await teachers.CountAsync();
        }

        public async Task<Teacher> GetTeacherDetailsAsync(string url)
        {
            return await context
              .Teachers
              .Include(s => s.ShowCards)
              .ThenInclude(s => s.Subject)
              .Where(s => s.Url == url)
              .Include(s=>s.ShowCards)
              .ThenInclude(s => s.Subject.SubjectCategories)
              .ThenInclude(sc => sc.Category)
              .FirstOrDefaultAsync();
        }

        public Task<List<Teacher>> GetTeachersByCategoryAsync(string category, int page, int pageSize)
        {
            throw new NotImplementedException();

            //    var teachers = context.Teachers
            //         .Include(t => t.ShowCards)
            //         .ThenInclude(sc => sc.Subject)
            //         .ThenInclude(s=>s.SubjectCategories)
            //         .ThenInclude(sc => sc.Category)
            //         .AsQueryable();

            //    if (!string.IsNullOrEmpty(category))
            //    {
            //        teachers = teachers
            //            .Include(t => t.ShowCards)
            //            .ThenInclude(sc => sc.Subject.SubjectCategories)
            //            .ThenInclude(sc => sc.Category)
            //            .Select(sc => sc.ShowCards)
            //            .Where(s => s.Subject.SubjectCategories.Any(sc => sc.Category.Url == category));                    
            //    };

            //    return await teachers
            //        .Skip((page - 1) * pageSize)
            //        .Take(pageSize)
            //        .ToListAsync();
        }

        public async Task<Teacher> FindTeacherByMailAsync(string mail)
        {
            return await context
              .Teachers
              .Where(t => t.Mail == mail)
              .FirstOrDefaultAsync();
        }

        public async Task UpdateAsync(Teacher teacher)
        {
            await context.AddAsync(teacher);
            await context.SaveChangesAsync();
        }
    }
}
