using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PrivateTuition.Business.Abstract;
using PrivateTuition.Core;
using PrivateTuition.Entity;
using PrivateTuition.Web.Models;
using System.Data;
using Microsoft.EntityFrameworkCore;
using PrivateTuition.Entity.Enum;
using Microsoft.AspNetCore.Identity;
using PrivateTuition.Web.Identity;
using System.Security.Claims;
using PrivateTuition.Data.Concrete.EFCore;
using PrivateTuition.Web.ViewModels;
using PrivateTuition.Data.Migrations;

namespace PrivateTuition.Web.Controllers
{
    [Authorize(Roles = "Teacher")]   
    public class TeacherController : Controller
    {
        private readonly IShowCardService _showCardService;
        private readonly ICategoryService _categoryService;
        private readonly ISubjectService _subjectService;
        private readonly ITeacherService _teacherService;
        private readonly ILessonRequestService _lessonRequestService;
        private readonly UserManager<MyIdentityUser> _userManager;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly PrivateTuitionContext _context;
        public TeacherController(IShowCardService showCardService, ICategoryService categoryService, ISubjectService subjectService, UserManager<MyIdentityUser> userManager, IHttpContextAccessor httpContextAccessor, ITeacherService teacherService, PrivateTuitionContext context, ILessonRequestService lessonRequestService)
        {
            _showCardService = showCardService;
            _categoryService = categoryService;
            _subjectService = subjectService;
            _userManager = userManager;
            _httpContextAccessor = httpContextAccessor;
            _teacherService = teacherService;
            _context = context;
            _lessonRequestService = lessonRequestService;
        }

        #region LessonRequest
        public async Task<IActionResult> LessonRequestList ()
        {
            var userId = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);

            var user = _userManager.Users.FirstOrDefault(x => x.Id == userId);

            var teacher = _context.Teachers.FirstOrDefault(q => q.Mail == user.Email);           
          
            List<LessonRequest> lessonRequests = await _lessonRequestService.GetAllAsync(t=>t.ShowCard.TeacherId==teacher.Id);


            return View(lessonRequests);
        }
        
        public async Task<IActionResult> LessonRequestApprove()
        {

            return View();
        }
        public async Task<IActionResult> LessonRequestDecline()
        {

            return View();
        }
        public async Task<IActionResult> LessonRequestDelete()
        {

            return View();
        }
        public async Task<IActionResult> LessonRequestPermanentlyDelete()
        {

            return View();
        }
        #endregion

        #region ShowCard
        [Route("/ShowCardList")]
        [HttpGet]
        public async Task<IActionResult> ShowCardList(bool isDeleted = false)
        {
            var userId = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = await _userManager.Users.FirstOrDefaultAsync(x => x.Id == userId);

            var teacher = await _teacherService.FindTeacherByMailAsync(user.Email);
            
            var showCards = await _showCardService.GetShowCardsByTeacherAsync(teacher.Id);
            ViewBag.IsDeleted = isDeleted;
            return View(showCards);
        }

        [HttpGet]
        [Route("/ShowCardCreate")]
        public async Task<IActionResult> ShowCardCreate()
        {
            var userId = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);

            var user = _userManager.Users.FirstOrDefault(x => x.Id == userId);

            //var teacher = _context.Teachers.FirstOrDefault(q => q.Mail == user.Email);
            var teacher = await _teacherService.FindTeacherByMailAsync(user.Email);

            ViewBag.Teacher = teacher;
            ViewBag.Categories = await _categoryService.GetAllAsync(c => c.IsDeleted == false);
            return View();//viewModel - UIModel
        }

        [HttpPost]
        [Route("/ShowCardCreate")]
        public async Task<IActionResult> ShowCardCreate([FromBody] ShowCardModel showCardModel)
        {

            if (ModelState.IsValid)
            {
                var url = Jobs.MakeUrl(showCardModel.Id + showCardModel.Title);
                ShowCard showCard = new ShowCard()
                {
                    Title = showCardModel.Title,
                    Description = showCardModel.Description,
                    LessonPrice = showCardModel.LessonPrice,
                    Url = url,
                    IsDeleted = !showCardModel.IsDeleted,
                    CityId = showCardModel.CityId,
                    TeacherId = showCardModel.TeacherId,
                    WorkMethods = (WorkMethods)Enum.Parse(typeof(WorkMethods), showCardModel.WorkMethods, true),
                    SubjectId = showCardModel.SubjectId,
                    
                    CreatedDate = showCardModel.CreatedDate,
                    Subject = showCardModel.SelectedSubject,
                    City = showCardModel.SelectedCity

                };
                await _showCardService.CreateAsync(showCard, showCardModel.CategoryId);
                //await _showCardService.CreateAsync(showCard);

                return RedirectToAction("Index");
            }
            //Buradan itibaren hata kontrolleri
            if (showCardModel.CategoryId == 0)
            {
                ViewBag.CategoryErrorMessage = "Lütfen bir kategori seç!";
            }
            else
            {
                ViewData["SelectedCategory"] = showCardModel.CategoryId;
            }
            ViewBag.Categories = await _categoryService.GetAllAsync(c => c.IsDeleted == false);
            return View(showCardModel);
        }

        [HttpGet]
        //[Route("/ShowCardEdit")]
        public async Task<IActionResult> ShowCardEdit(int id)
        {
            var showCard = await _showCardService.GetShowCardWithCategoriesAsync(id);
            ShowCardModel showCardModel = new ShowCardModel()
            {
                Id = showCard.Id,
                Title = showCard.Title,
                LessonPrice = showCard.LessonPrice,
                Description = showCard.Description,
                ImageUrl = showCard.Teacher.AvatarUrl,
                IsDeleted = showCard.IsDeleted,
                SelectedCategory = showCard
                    .Subject.SubjectCategories
                    .Select(pc => pc.Category)
                    .FirstOrDefault(),
                SelectedSubject = showCard.Subject
            };
            ViewBag.Categories = await _categoryService.GetAllAsync(c => c.IsDeleted == false);
            ViewBag.Subjects = await _subjectService.GetAllAsync(c => c.IsDeleted == false);
            return View(showCardModel);
        }

        
        [HttpPost]
        //[Route("/ShowCardEdit")]
        public async Task<IActionResult> ShowCardEdit(ShowCardModel showCardModel, int subjectId)
        {

            string url = Jobs.MakeUrl(showCardModel.Title);
            if (ModelState.IsValid && subjectId >0)
            {
                var showCard = await _showCardService.GetByIdAsync(showCardModel.Id);


                if (showCard == null)
                {
                    return NotFound();
                }

                showCard.Title = showCardModel.Title;
                showCard.Url = url;
                showCard.LessonPrice = showCardModel.LessonPrice;
                showCard.Description = showCardModel.Description;
                showCard.IsDeleted = !showCardModel.IsDeleted;
                showCard.CreatedDate = showCardModel.CreatedDate;

                showCard.Subject = showCardModel.SelectedSubject;


                await _showCardService.UpdateAsync(showCard, subjectId);
                return RedirectToAction("ShowCardList");
            }
            if (subjectId == null)
            {
                ViewBag.CategoryErrorMessage = "Choose a subject!";
            }
            else
            {
                showCardModel.SelectedSubject.Id = subjectId;
            }

            ViewBag.Categories = await _categoryService.GetAllAsync(c => c.IsDeleted == false);
            ViewBag.Subjects = await _subjectService.GetAllAsync(c => c.IsDeleted == false);
            return View(showCardModel);
        }

        [Route("/ShowCardDelete")]
        [HttpGet]
        public async Task<IActionResult> ShowCardDelete(int id)
        {
            ShowCard showCard = await _showCardService.GetByIdAsync(id);
            if (showCard != null)
            {
                showCard.IsDeleted = showCard.IsDeleted ? false : true;
                _showCardService.IsDelete(showCard);
            }
            return RedirectToAction("ShowCardList");
        }

        [Route("/ShowCardDeletePermanently")]
        [HttpGet]
        public async Task<IActionResult> ShowCardDeletePermanently(int id)
        {
            var showCard = await _showCardService.GetByIdAsync(id);
            if (showCard == null)
            {
                return NotFound();
            }
            _showCardService.Delete(showCard);
            return Redirect("/Teacher/ShowCardList?isDeleted=true");
        }
    #endregion
    }
}
