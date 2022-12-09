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
    public class EfCoreShowCardRepository : EfCoreGenericRepository<ShowCard>, IShowCardRepository
    {
        public EfCoreShowCardRepository(PrivateTuitionContext dbContext) : base(dbContext)
        {
        }

        public async Task CreateAsync(ShowCard showCard, int categoryId)
        {
            await context.ShowCards.AddAsync(showCard);
            await context.SaveChangesAsync();
          
        }

        public async Task<List<ShowCard>> GetAllShowCardsAsync()
        {
            return await context
                .ShowCards
                .Include(s => s.Teacher) 
                .Include(s => s.Subject)
                .Where(sc => sc.IsDeleted == false)
                .ToListAsync();
        }

        public async Task<int> GetCountByCategoryAsync(string category)
        {
            var showCards =  context.ShowCards.AsQueryable();
            if (!string.IsNullOrEmpty(category))
            {
                showCards = showCards
                   .Include(s => s.Subject)
                   .ThenInclude(s => s.SubjectCategories)
                   .ThenInclude(sc => sc.Category)
                   .Where(s => s.Subject.SubjectCategories.Any(sc => sc.Category.Url == category));
            };

            return await showCards.CountAsync();
        }

        public async Task<List<ShowCard>> GetHomeShowCardsAsync(string category)
        {

            var showcards = context
                .ShowCards
                .Include(s => s.Teacher)
                .Include(s => s.Subject)
                .Where(s => s.Teacher.RatingPoint >=0 && s.IsDeleted == false && s.Teacher.ResponseRange == null)  //rating ve response ayarlanacak
                .AsQueryable();


            if (!string.IsNullOrEmpty(category))
            {
                showcards = showcards
                    .Include(s => s.Subject.SubjectCategories)
                    .ThenInclude(sc => sc.Category)
                    .Where(s => s.Subject.SubjectCategories.Any(sc => sc.Category.Url == category));     
            }
            var a = showcards.ToList();
            
            return await showcards.ToListAsync();
        }

        public async Task<List<ShowCard>> GetInActivatedShowCardsAsync()
        {
            return await context
                .ShowCards
                .Include(s => s.Teacher)
                .Include(s => s.Subject)
                .Where(p => p.IsDeleted == true)
                .ToListAsync();
        }

        public async Task<ShowCard> GetShowCardDetailsAsync(string url)
        {
            return await context
               .ShowCards
               .Include(s => s.Teacher)
               .Include(s => s.Subject)
               .Where(s => s.Url == url)
               .Include(s => s.Subject.SubjectCategories)
               .ThenInclude(sc => sc.Category)
               .FirstOrDefaultAsync();
        }

        public async Task<List<ShowCard>> GetSearchResultAsync(string searchString)
        {
            return await context
               .ShowCards
               .Include(s => s.Teacher)
               .Include(s => s.Subject)
               .Where(s=> s.Title.ToLower().Contains(searchString.ToLower()) || s.Description.ToLower().Contains(searchString.ToLower()))
               .ToListAsync();
        }

        public async Task<List<ShowCard>> GetShowCardsByCategoryAsync(string category, int page, int pageSize)
        {

            var showCards = context.ShowCards
                .Include(s => s.Teacher)
                .Include(s => s.Subject)
                .AsQueryable();

            if (!string.IsNullOrEmpty(category))
            {
                showCards = showCards                    
                    .Include(s => s.Subject.SubjectCategories)                   
                    .ThenInclude(sc=> sc.Category)
                    .Where(s => s.Subject.SubjectCategories.Any(sc => sc.Category.Url == category));
            };           

            return await showCards
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }

        public async Task<ShowCard> GetShowCardWithCategoriesAsync(int id)
        {
            return await context.ShowCards.Include(s => s.Teacher).Include(s => s.Subject)
               .Where(s => s.Id == id && s.IsDeleted == false)
               .Include(s => s.Subject.SubjectCategories)
               .ThenInclude(sc => sc.Category)
               .FirstOrDefaultAsync();
        }

        public void IsActive(ShowCard showCard)
        {
            if (showCard.IsDeleted == false)
            {
                showCard.IsDeleted = true;
            }
            else
            {
                showCard.IsDeleted = false;
            }
            context.Update(showCard);
            context.SaveChanges();
        }

        public async Task UpdateAsync(ShowCard showCard, int subjectId)
        {
            var newShowCard = await context
                .ShowCards
               .Include(s => s.Subject)
               .ThenInclude(s => s.SubjectCategories)
               .FirstOrDefaultAsync(s => s.Id == showCard.Id);

            newShowCard.Title = showCard.Title;
            newShowCard.Description = showCard.Description;
            newShowCard.IsDeleted = !showCard.IsDeleted;
            newShowCard.LessonPrice = showCard.LessonPrice;
            newShowCard.Url = showCard.Url;
            newShowCard.Subject.SubjectCategories = showCard.Subject.SubjectCategories;            
            newShowCard.Subject.Id= subjectId;
               

            context.Update(newShowCard);
            context.SaveChanges();
        }
        public async Task<List<ShowCard>> GetSearchResultAsync(City city, District district, Category category, Subject subject)
        {
            return await context
               .ShowCards
               .Include(s => s.City.il_adi)
               .Include(s => s.Subject)
               .Include(s => s.Subject.SubjectCategories)
               .ThenInclude(sc => sc.Category)
               .Include(s => s.City.ilceler)
               .ThenInclude(i => i.ilce_adi)
               .Where(s => s.City.il_adi == city.il_adi || s.Subject.Name == subject.Name
                || s.Subject.SubjectCategories.Any(sc => sc.Category.Name == category.Name)
                || s.City.ilceler.Any(i => i.ilce_adi == district.Name)
                )
               .ToListAsync();
        }

        public async Task<List<ShowCard>> GetShowCardsByTeacherAsync(int teacherId)
        {
            var showCards = context.ShowCards
                 .Include(s => s.Teacher)
                 .Where(s=>s.Teacher.Id== teacherId && s.IsDeleted==false)
                 .ToListAsync();

            return await showCards;
               
        }
    }
}
