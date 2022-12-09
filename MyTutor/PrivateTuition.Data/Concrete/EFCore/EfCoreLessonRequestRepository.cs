using Microsoft.EntityFrameworkCore;
using PrivateTuition.Data.Abstract;
using PrivateTuition.Data.Migrations;
using PrivateTuition.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrivateTuition.Data.Concrete.EFCore
{
    public class EfCoreLessonRequestRepository : EfCoreGenericRepository<LessonRequest>, ILessonRequestRepository
    {
        public EfCoreLessonRequestRepository(PrivateTuitionContext dbContext) : base(dbContext)
        {
        }

        public async Task<List<LessonRequest>> GetAllLessonRequestsAsync()
        {
            return await context
               .LessonRequests
               .Include(ls => ls.ShowCard)
               .Include(ls => ls.Student)
               .Include(ls=>ls.ShowCard.Teacher)
               .Where(sc => sc.IsDeleted == false)
               .ToListAsync();
        }

        public async Task<int> GetCountByTeacherAsync(string teacher)
        {
            var lessonRequests = context.LessonRequests.AsQueryable();
            if (!string.IsNullOrEmpty(teacher))
            {
                lessonRequests = lessonRequests
                   .Include(ls => ls.ShowCard)
                   .ThenInclude(sc => sc.Teacher)
                   .Where(s => s.ShowCard.Teacher.ShowCards.Any(sc => sc.Teacher.Url == teacher));
            };

            return await lessonRequests.CountAsync();
        }

        public async Task<List<LessonRequest>> GetLessonRequestByTeacherAsync(string teacher, int page, int pageSize)
        {
            var lessonRequests = context.LessonRequests
              .Include(s => s.ShowCard)
              .Include(s => s.ShowCard.Teacher)
              .AsQueryable();

            if (!string.IsNullOrEmpty(teacher))
            {
                lessonRequests = lessonRequests
                    .Include(s => s.ShowCard)
                    .ThenInclude(sc => sc.Teacher)
                    .Where(s => s.ShowCard.Teacher.ShowCards.Any(sc => sc.Teacher.Url == teacher));
            };

            return await lessonRequests
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }

        public async Task<LessonRequest> GetLessonRequestDetailsAsync(string url)
        {
            return await context
              .LessonRequests
              .Include(ls => ls.ShowCard)
              .ThenInclude(s => s.Teacher)
              .Where(t => t.Url == url)
              .Include(ls => ls.Student)                           
              .FirstOrDefaultAsync();
        }

        public void IsActive(LessonRequest lessonRequest)
        {
            if (lessonRequest.IsDeleted == false)
            {
                lessonRequest.IsDeleted = true;
            }
            else
            {
                lessonRequest.IsDeleted = false;
            }
            context.Update(lessonRequest);
            context.SaveChanges();
        }
    }
}
