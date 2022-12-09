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
    public class EfCoreSubjectRepository : EfCoreGenericRepository<Subject>, ISubjectRepository
    {
        public EfCoreSubjectRepository(PrivateTuitionContext dbContext) : base(dbContext)
        {
        }

        public async Task CreateAsync(Subject subject, int[] categoryIds)
        {
            await context.Subjects.AddAsync(subject);
            await context.SaveChangesAsync();
            subject.SubjectCategories = categoryIds
                .Select(catId => new SubjectCategory
                {
                    SubjectId = subject.Id,
                    CategoryId = catId
                }).ToList();
            await context.SaveChangesAsync();
        }

        public async Task<List<Category>> GetAllSubjectsAsync(bool isDeleted)
        {
            return await context
             .Categories
             .Include(cat => cat.SubjectCategories)
             .ThenInclude(sc => sc.Subject)
             .Where(c => c.IsDeleted == isDeleted)
             .ToListAsync();


        }

        public async Task<Subject> GetSubejctWithCategoryAsync(int id)
        {
            return await context
                 .Subjects
                 .Where(p => p.Id == id)
                 .Include(p => p.SubjectCategories)
                 .ThenInclude(sc => sc.Category)
                 .FirstOrDefaultAsync();
        }

        public async Task<List<Subject>> GetSubjectsByCategoryAsync(int id)
        {
            return await context
                  .Subjects
                  .Include(s => s.SubjectCategories)
                  .ThenInclude(sc => sc.Category)
                  .Where(x => x.SubjectCategories.Any(s => s.CategoryId == id))
                   .ToListAsync();

        }

        public async Task<List<Subject>> GetSubjectsByCategoryInPageAsync(string category, int page, int pageSize)
        {
            var subjects = context.Subjects.AsQueryable();
            if (!string.IsNullOrEmpty(category))
            {
                subjects = subjects
                    .Include(s => s.SubjectCategories)
                    .ThenInclude(sc => sc.Category)
                    .Where(s => s.SubjectCategories.Any(sc => sc.Category.Url == category));
            };
            return await subjects
               .Skip((page - 1) * pageSize)
               .Take(pageSize)
               .ToListAsync();
        }

        public Task<List<Category>> GetSubjectWithShowCardsAsync(int id)
        {

            //var showCards = await context.ShowCards.AsQueryable();
            //if (!string.IsNullOrEmpty(id))
            //{
            //    showCards = showCards
            //        .Where(sc => sc.Subject.Id == id);               
            //};

            return null;
        }

        public void IsDelete(Subject subject)
        {
            context.Update(subject);
            context.SaveChanges();
        }

        public async Task UpdateAsync(Subject subject, int[] categoryIds)
        {
            var newSubject = await context
               .Subjects
               .Include(s => s.SubjectCategories)
               .FirstOrDefaultAsync(s => s.Id == subject.Id);

            newSubject.Name = subject.Name;
            newSubject.Url = subject.Url;
            newSubject.SubjectCategories = categoryIds
                .Select(catId => new SubjectCategory()
                {
                    SubjectId = subject.Id,
                    CategoryId = catId
                }).ToList();
            context.Update(newSubject);
            context.SaveChanges();
        }
    }
}
