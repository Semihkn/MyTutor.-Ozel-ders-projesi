using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PrivateTuition.Business.Abstract;
using PrivateTuition.Core;
using PrivateTuition.Data.Concrete.EFCore;
using PrivateTuition.Entity;
using PrivateTuition.Web.Identity;
using PrivateTuition.Web.Models;
using System.Security.Claims;


namespace PrivateTuition.Web.Controllers
{
    public class StudentController : Controller
    {
        private readonly IShowCardService _showCardService;
        private readonly ILessonRequestService _lessonRequestService;
        private readonly ITeacherService _teacherService;
        private readonly IStudentService _studentService;
        private readonly UserManager<MyIdentityUser> _userManager;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly PrivateTuitionContext _context;

        public StudentController(IShowCardService showCardService, ITeacherService teacherService, IHttpContextAccessor httpContextAccessor, UserManager<MyIdentityUser> userManager, PrivateTuitionContext context, ILessonRequestService lessonRequestService, IStudentService studentService)
        {
            _showCardService = showCardService;
            _teacherService = teacherService;
            _httpContextAccessor = httpContextAccessor;
            _context = context;
            _userManager = userManager;
            _lessonRequestService = lessonRequestService;
            _studentService = studentService;
        }

        [HttpGet]
        public IActionResult Index()
        {

            return RedirectToAction("Index", "Home");
        }


        //[HttpPost]
        //public IActionResult SaveRequest([FromForm] SaveRequestReq request)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _context.LessonRequests.Add(new Entity.LessonRequest
        //        {
        //            Address = request.Address,
        //            ContactNumber = request.ContactNumber,
        //            Expectations = request.Expectations,
        //            StudentId = request.StudentId,
        //            ShowCardId = request.ShowCardId,
        //            IsApproved = false,

        //        });
        //        var a = _context.SaveChanges();
        //        if (a == 1)
        //        {
        //            //başarıyla kaydetti
        //        }
        //        else
        //        {
        //            //kaydedemedi hata var 
        //        }
        //    }
        //    return RedirectToAction("Index", "Home");

        //}

        [HttpPost]
        public async Task<IActionResult> SaveRequest([FromForm] SaveRequestReq request)
        {
            if (ModelState.IsValid)
            {
                LessonRequest lessonRequest= new LessonRequest 
                {
                    Address = request.Address,
                    ContactNumber = request.ContactNumber,
                    Expectations = request.Expectations,
                    StudentId = request.StudentId,
                    ShowCardId = request.ShowCardId,
                    IsApproved = false,
                    
                    

                };
                await _lessonRequestService.CreateAsync(lessonRequest);
           
            }
            return RedirectToAction("Index", "Home");

        }

        public async Task<IActionResult> LessonRequestList()
        {
            var userId = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);

            var user = _userManager.Users.FirstOrDefault(x => x.Id == userId);

            var student = _context.Students.FirstOrDefault(q => q.Mail == user.Email);

            var lessonRequests = await _lessonRequestService.GetAllAsync(q => q.StudentId == student.Id);

            return View(lessonRequests);
        }
        public async Task<IActionResult> NewLessonRequest()
        {
            ViewBag.LessonRequests = await _lessonRequestService.GetAllAsync(c => c.Id>0);
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> NewLessonRequest(LessonRequestModel lessonRequestModel)
        {
            if (ModelState.IsValid)
            {
                var url = Jobs.MakeUrl(lessonRequestModel.ShowCard.Url + lessonRequestModel.Student.Url);
                LessonRequest lessonRequest = new LessonRequest()
                {
                    Expectations = lessonRequestModel.Expectations,
                    Url = url,
                    Address = lessonRequestModel.Address,
                    ContactNumber = lessonRequestModel.ContactNumber,
                    CreatedDate = lessonRequestModel.LessonRequestTime,
                    IsApproved = lessonRequestModel.IsApproved,
                    ResponseTime = lessonRequestModel.ResponseTime,
                    ShowCard = lessonRequestModel.ShowCard,
                    Student = lessonRequestModel.Student          

                };
                                            
                await _lessonRequestService.CreateAsync(lessonRequest);
               
            }
            return View(lessonRequestModel);

        }
    }

    public class SaveRequestReq
    {
        public int StudentId { get; set; }
        public int ShowCardId { get; set; }
        public string Expectations { get; set; }
        public string Address { get; set; }
        public string ContactNumber { get; set; }
    }


}

