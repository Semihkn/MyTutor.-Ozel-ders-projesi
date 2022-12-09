using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PrivateTuition.Business.Abstract;
using PrivateTuition.Data.Concrete.EFCore;
using PrivateTuition.Entity;
using PrivateTuition.Web.Identity;
using PrivateTuition.Web.Models;
using PrivateTuition.Web.ViewModels;
using System.Security.Claims;

namespace PrivateTuition.Web.Controllers
{
    public class PrivateTuitionController : Controller
    {
        private readonly IShowCardService _showCardService;
        private readonly ITeacherService _teacherService;
        private readonly UserManager<MyIdentityUser> _userManager;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly PrivateTuitionContext _context;

        public PrivateTuitionController(IShowCardService showCardService, ITeacherService teacherService , IHttpContextAccessor httpContextAccessor,UserManager<MyIdentityUser> userManager, PrivateTuitionContext context)
        {
            _showCardService = showCardService;
            _teacherService = teacherService;
            _httpContextAccessor = httpContextAccessor;
            _context = context;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> TeacherList(string category, int page = 1) 
        {
            const int pageSize = 9;
            List<Teacher> teachers = await _teacherService.GetAllTeachersAsync();

            PageInfo pageInfo = new PageInfo()
            {
                //TotalItems = await _teacherService.GetTeachersCountByCategoryAsync(category),
                TotalItems= teachers.Count,
                CurrentPage = page,
                ItemsPerPage = pageSize,
                CurrentCategory = category
            };

            TeacherCardViewModel teacherCardViewModel = new TeacherCardViewModel()
            {
                Teachers = teachers,
                PageInfo = pageInfo
            };

            return View(teacherCardViewModel);
        }
        public async Task<IActionResult> List(string category, int page = 1)  //List All ShowCards
        {
            const int pageSize = 9;
            List<ShowCard> showCards = await _showCardService.GetAllShowCardsAsync();

            PageInfo pageInfo = new PageInfo()
            {
                TotalItems = await _showCardService.GetCountByCategoryAsync(category),
                CurrentPage = page,
                ItemsPerPage = pageSize,
                CurrentCategory = category
            };

            ShowCardViewModel showCardViewModel = new ShowCardViewModel()
            {
                ShowCards = showCards,
                PageInfo = pageInfo
            };

            return View(showCardViewModel);  
        }
        public async Task<IActionResult> ListByCategory(string category, int page = 1)  //List All ShowCards
        {
            const int pageSize = 9;
            List<ShowCard> showCards = await _showCardService.GetShowCardsByCategoryAsync(category,page,pageSize);
            PageInfo pageInfo = new PageInfo()
            {
                TotalItems = await _showCardService.GetCountByCategoryAsync(category),
                CurrentPage = page,
                ItemsPerPage = pageSize,
                CurrentCategory = category
            };

            ShowCardViewModel showCardViewModel = new ShowCardViewModel()
            {
                ShowCards = showCards,
                PageInfo = pageInfo
            };

            return View(showCardViewModel);
        }


        public async Task<IActionResult> Details(string url)
        {
            //if (string.IsNullOrEmpty(url))
            //{
            //    return NotFound();
            //}

            //var userId = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            //if (userId == null)
            //{
            //    return NotFound();

            //}
            //var user = _userManager.Users.FirstOrDefault(x => x.Id == userId);

            //var student = _context.Students.FirstOrDefault(q => q.Mail == user.Email);
            //ShowCard showCard = await _showCardService.GetShowCardDetailsAsync(url);

            //ShowCardDetailModel showCardDetailModel = new ShowCardDetailModel()
            //{
            //    ShowCard = showCard,
            //    Category = showCard
            //        .Subject.SubjectCategories
            //        .Select(sc => sc.Category)
            //        .FirstOrDefault()

            //};
            //ViewBag.Student = student.Id;
            //return View(showCardDetailModel);

            if (string.IsNullOrEmpty(url))
            {
                return NotFound();
            }
            ShowCard showCard = await _showCardService.GetShowCardDetailsAsync(url);

            ShowCardDetailModel showCardDetailModel = new ShowCardDetailModel()
            {
                ShowCard = showCard,
                Category = showCard
                    .Subject.SubjectCategories
                    .Select(sc => sc.Category)
                    .FirstOrDefault()

            };
            return View(showCardDetailModel);
        }

        public async Task<IActionResult> Search(string q)
        {
            List<ShowCard> searchResult = await _showCardService.GetSearchResultAsync(q);
            return View(searchResult);
        }
        public async Task<IActionResult> AdvanceSearch(City city, District district, Category category, Subject subject)
        {
            List<ShowCard> searchResult = await _showCardService.GetSearchResultAsync(city, district, category, subject);
            return View(searchResult);
        }
    }
}
