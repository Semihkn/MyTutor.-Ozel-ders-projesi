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
    public class EfCoreCategoryRepository : EfCoreGenericRepository<Category>, ICategoryRepository
    {
        public EfCoreCategoryRepository(PrivateTuitionContext _dbContext) : base(_dbContext)
        {
        }

        public async Task<List<Category>> GetAllCategoriesAsync(bool isDeleted)
        {
            return await context
             .Categories
             .Where(c => c.IsDeleted == isDeleted)
             .ToListAsync();
        }

        public async Task<List<Category>> GetCategoryWithSubjectsAsync(int id)
        {
            return await context
               .Categories
               .Where(c => c.Id == id)
               .Include(c => c.SubjectCategories)
               .ThenInclude(sc => sc.Subject)
               .ToListAsync();
        }

        public async Task<Category> GetCategoryWithOneSubjectAsync(int id)
        {
            return await context
                .Categories
                .Where(c => c.Id == id)
                .Include(c => c.SubjectCategories)
                .ThenInclude(pc => pc.Subject)
                .FirstOrDefaultAsync();
        }

        public async Task<List<Category>> GetCategoryWithShowCardsAsync(int id)
        {
            return await context
               .Categories
               .Where(c => c.Id == id)
               .Include(c => c.SubjectCategories)
               .ThenInclude(sc => sc.Subject.ShowCards)
               .ToListAsync();
        }

        public void IsDelete(Category category)
        {
            context.Update(category);
            context.SaveChanges();
        }


    }  
}