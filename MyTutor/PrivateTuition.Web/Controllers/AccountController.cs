using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NuGet.DependencyResolver;
using PrivateTuition.Business.Abstract;
using PrivateTuition.Business.Concrete;
using PrivateTuition.Core;
using PrivateTuition.Data.Concrete.EFCore;
using PrivateTuition.Entity;
using PrivateTuition.Web.Identity;
using PrivateTuition.Web.Models;
using System.Security.Claims;

namespace PrivateTuition.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<MyIdentityUser> _userManager;
        private readonly ITeacherService _teacherService;
        private readonly IStudentService _studentService;
        private readonly SignInManager<MyIdentityUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly PrivateTuitionContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;


        public AccountController(UserManager<MyIdentityUser> userManager, SignInManager<MyIdentityUser> signInManager, RoleManager<IdentityRole> roleManager, PrivateTuitionContext context, ITeacherService teacherService, IStudentService studentService, IHttpContextAccessor httpContextAccessor)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _context = context;
            _teacherService = teacherService;
            _studentService = studentService;
            _httpContextAccessor = httpContextAccessor;
        }
        #region Login/Register
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterModel registerModel)
        {
            if (ModelState.IsValid)
            {
                MyIdentityUser myIdentityUser = new MyIdentityUser()
                {
                    FirstName = registerModel.FirstName,
                    LastName = registerModel.LastName,
                    UserName = registerModel.UserName,
                    Email = registerModel.Email,
                    
                };

                var result = await _userManager.CreateAsync(myIdentityUser, registerModel.Password);
                if (result.Succeeded)
                {
                    var url = Jobs.MakeUrl(registerModel.UserName);

                    if (registerModel.IsStudent == true)
                    {
                       await _userManager.AddToRoleAsync(myIdentityUser, "Student");
                        //_context.Students.Add(new Student
                        //{
                        //    Name = registerModel.FirstName+registerModel.LastName,
                        //    FirstName= registerModel.FirstName,
                        //    LastName= registerModel.LastName,
                        //    Url = url,
                        //    IsDeleted = false,
                        //    Mail = registerModel.Email,
                            

                        //});
                        Student student = new Student()                        
                        {
                            Name = registerModel.FirstName + registerModel.LastName,
                            FirstName = registerModel.FirstName,
                            LastName = registerModel.LastName,
                            Url = url,
                            IsDeleted = false,
                            Mail = registerModel.Email,
                        };
                        await _studentService.CreateAsync(student);


                    }
                    //if (registerModel.IsTeacher == true)
                    //{
                    //    await _userManager.AddToRoleAsync(myIdentityUser, "Teacher");
                    //    //_context.Teachers.Add(new Teacher
                    //    //{
                    //    //    Name = registerModel.FirstName + registerModel.LastName,
                    //    //    FirstName= registerModel.FirstName,
                    //    //    LastName= registerModel.LastName,
                    //    //    Url = url,
                    //    //    IsDeleted = false,
                    //    //    Mail = registerModel.Email,

                    //    //});

                    //    Teacher teacher = new Teacher()
                    //    {
                    //        Name = registerModel.FirstName + registerModel.LastName,
                    //        FirstName = registerModel.FirstName,
                    //        LastName = registerModel.LastName,
                    //        Url = url,
                    //        IsDeleted = false,
                    //        Mail = registerModel.Email,
                    //    };
                    else
                    {
                        await _userManager.AddToRoleAsync(myIdentityUser, "Teacher");
                        //_context.Teachers.Add(new Teacher
                        //{
                        //    Name = registerModel.FirstName + registerModel.LastName,
                        //    Url = url,
                        //    IsDeleted = false,
                        //    Mail = registerModel.Email,

                        //});
                        Teacher teacher = new Teacher()
                        {
                            Name = registerModel.FirstName + registerModel.LastName,
                            FirstName = registerModel.FirstName,
                            LastName = registerModel.LastName,
                            Url = url,
                            IsDeleted = false,
                            Mail = registerModel.Email,
                        };
                        await _teacherService.CreateAsync(teacher);

                    }
                    TempData["AlertMessage"] = Jobs.CreateMessage("BİLGİLENDİRME!", "Kaydınız başarıyla oluşturulmuştur.", "success");
                    return RedirectToAction("Login");

                    
                }
                _context.SaveChanges();

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }
            

            return View(registerModel);
        }
        public IActionResult Login(string returnUrl = null )
        {
            if (!User.Identity.IsAuthenticated)
            {
                return View(new LoginModel() { ReturnUrl = returnUrl });
            }
             return Redirect("~/");
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginModel loginModel)
        {
           
            if (ModelState.IsValid)
            {
                var myIdentityUser = await _userManager.FindByEmailAsync(loginModel.Email);
                if (myIdentityUser == null)
                {
                    TempData["AlertMessage"] = Jobs.CreateMessage("HATA!", "Kullanıcı adı ya da şifre hatalı!", "danger");
                    return View(loginModel);
                }
                var result = await _signInManager.PasswordSignInAsync(myIdentityUser, loginModel.Password, loginModel.RememberMe, true);
                if (result.Succeeded)
                {
                    return Redirect(loginModel.ReturnUrl ?? "~/");
                }
                TempData["AlertMessage"] = Jobs.CreateMessage("HATA!", "Kullanıcı adı ya da şifre hatalı!", "danger");
                return View(loginModel);
            }
            return View();
        }
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return Redirect("~/");
        }
        #endregion

        public IActionResult UserProfile()
        {
            var userId = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = _userManager.Users.FirstOrDefault(x => x.Id == userId);

            if (!User.Identity.IsAuthenticated)
            {
                return View(new User() {
                    UserName= user.UserName,
                    FirstName=user.FirstName,
                    LastName=user.LastName,
                    PhoneNumber=user.PhoneNumber,
                    Mail = user.Email,
                });
            }
            return View();
        }
        [Authorize]
        public IActionResult ChangePassword()
        {
            return View();
        }
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> ChangePassword(ChangePasswordModel changePassword)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByNameAsync(User.Identity.Name);
                var result = await _userManager.ChangePasswordAsync(user, changePassword.OldPassword, changePassword.NewPassword);
                if (result.Succeeded)
                {
                    return Redirect("~/");
                }
            }
            return View(changePassword);
        }

    }
}
