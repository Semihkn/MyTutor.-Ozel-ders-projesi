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
        private readonly IShowCardService _showcardService;
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
                    else
                    {
                        await _userManager.AddToRoleAsync(myIdentityUser, "Teacher");
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
        public IActionResult Login(string returnUrl = null)
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

        public async Task<IActionResult> UserProfile()
        {
            var userId = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = _userManager.Users.FirstOrDefault(x => x.Id == userId);


            if (!User.Identity.IsAuthenticated) { return RedirectToAction("Login"); }

            if (User.IsInRole("Teacher"))
            {
                var teacher = await _teacherService.FindTeacherByMailAsync(user.Email);
                return View(new UserProfileModel()
                {
                    UserName = user.UserName,
                    Name = user.FirstName + " " + user.LastName,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    PhoneNumber = user.PhoneNumber,
                    Email = user.Email,
                    UserId = userId,
                    SelectedRoles = await _userManager.GetRolesAsync(user),
                    Roles = await _userManager.GetRolesAsync(user),
                    Description = teacher.TeacherInfo,
                    Job = teacher.Job,
                    Gender = teacher.Gender,
                    AvatarUrl = teacher.AvatarUrl,
                    City = teacher.City,
                    District = teacher.District,
                    //ShowCards = await _showcardService.GetShowCardsByTeacherAsync(teacher.Id),
                    //Comments= teacher.Comments,
                });
            }
            if (User.IsInRole("Student"))
            {
                var student = await _studentService.FindStudentByMailAsync(user.Email);
                return View(new UserProfileModel()
                {
                    UserName = user.UserName,
                    Name = user.FirstName + " " + user.LastName,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    PhoneNumber = user.PhoneNumber,
                    Email = user.Email,
                    UserId = userId,
                    SelectedRoles = await _userManager.GetRolesAsync(user),
                    Roles = await _userManager.GetRolesAsync(user),
                    Job = student.Job,
                    Gender = student.Gender,
                    AvatarUrl = student.AvatarUrl,
                    City = student.City,
                    District = student.District,
                });
            }
            return Redirect("~/");
        }

        [HttpPost]
        public async Task<IActionResult> ProfileEdit(UserProfileModel userProfile)
        {
            var userId = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = _userManager.Users.FirstOrDefault(x => x.Id == userId);
            if (!User.Identity.IsAuthenticated) { return RedirectToAction("Login"); }
            else
            {
                if (ModelState.IsValid)
                {
                    var teacher = await _teacherService.FindTeacherByMailAsync(user.Email);
                    var student = await _studentService.FindStudentByMailAsync(user.Email);
                    if (User.IsInRole("Teacher"))
                    {
                        teacher.UserName = userProfile.UserName;
                        teacher.FirstName = userProfile.FirstName;
                        teacher.LastName = userProfile.LastName;
                        teacher.UserName = userProfile.UserName;
                        teacher.PhoneNumber = userProfile.PhoneNumber;
                        teacher.Mail = userProfile.Email;
                        teacher.TeacherInfo = userProfile.Description;
                        teacher.Job = userProfile.Job;
                        teacher.Gender = userProfile.Gender;
                        teacher.AvatarUrl = userProfile.AvatarUrl;
                        teacher.City = userProfile.City;
                        teacher.District = userProfile.District;
                        await _teacherService.UpdateAsync(teacher);
                        //var result = await _userManager.UpdateAsync(user);
                        TempData["AlertMessage"] = Jobs.CreateMessage("Tebrikler!", "Kayıt başarıyla düzenlenmiştir.", "success");
                        return RedirectToAction("UserProfile");
                    }
                    else if (User.IsInRole("Student"))
                    {
                        student.UserName = userProfile.UserName;
                        student.FirstName = userProfile.FirstName;
                        student.LastName = userProfile.LastName;
                        student.PhoneNumber = userProfile.PhoneNumber;
                        student.Mail = userProfile.Email;
                        student.UserName = userProfile.UserName;
                        student.Job = userProfile.Job;
                        student.Gender = userProfile.Gender;
                        student.AvatarUrl = userProfile.AvatarUrl;
                        student.City = userProfile.City;
                        student.District = userProfile.District;
                        _studentService.Update(student);
                        TempData["AlertMessage"] = Jobs.CreateMessage("Tebrikler!", "Kayıt başarıyla düzenlenmiştir.", "success");
                        return RedirectToAction("UserProfile");
                    }

                }
            }
           
            TempData["AlertMessage"] = Jobs.CreateMessage("Hata!", "Kayıt düzenlenemedi.", "danger");

            return View("UserProfile");
        }

        public async Task<IActionResult> AccountSettings()
        {
            var userId = _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = _userManager.Users.FirstOrDefault(x => x.Id == userId);


            if (!User.Identity.IsAuthenticated) { return RedirectToAction("Login"); }

            if (User.IsInRole("Teacher"))
            {
                var teacher = await _teacherService.FindTeacherByMailAsync(user.Email);
                return View(new UserProfileModel()
                {
                    UserName = user.UserName,
                    Name = user.FirstName + " " + user.LastName,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    PhoneNumber = user.PhoneNumber,
                    Email = user.Email,
                    UserId = userId,
                    SelectedRoles = await _userManager.GetRolesAsync(user),
                    Roles = await _userManager.GetRolesAsync(user),
                    Description = teacher.TeacherInfo,
                    Job = teacher.Job,
                    Gender = teacher.Gender,
                    AvatarUrl = teacher.AvatarUrl,
                    City = teacher.City,
                    District = teacher.District,
                });
            }
            if (User.IsInRole("Student"))
            {
                var student = await _studentService.FindStudentByMailAsync(user.Email);
                return View(new UserProfileModel()
                {
                    UserName = user.UserName,
                    Name = user.FirstName + " " + user.LastName,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    PhoneNumber = user.PhoneNumber,
                    Email = user.Email,
                    UserId = userId,
                    SelectedRoles = await _userManager.GetRolesAsync(user),
                    Roles = await _userManager.GetRolesAsync(user),
                    Job = student.Job,
                    Gender = student.Gender,
                    AvatarUrl = student.AvatarUrl,
                    City = student.City,
                    District = student.District,
                });
            }
            return Redirect("~/");
        }

        [Authorize]
        public async Task<IActionResult> ChangePassword(string name)
        {
            var user = await _userManager.FindByIdAsync(User.Identity.Name);
            UserProfileModel changePasswordModel = new UserProfileModel() { UserId = user.Id };
            return View(changePasswordModel);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> ChangePassword(UserProfileModel changePassword)
        {

            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            var result = await _userManager.ChangePasswordAsync(user, changePassword.OldPassword, changePassword.NewPassword);
            if (result.Succeeded)
            {
                TempData["AlertMessage"] = Jobs.CreateMessage("Başarılı!", "Tebrikler, şifre değişti", "success");
                return RedirectToAction("UserProfile");
            }

            TempData["AlertMessage"] = Jobs.CreateMessage("Hata!", "Yanlış şifre girdiniz!", "danger");
            return View(changePassword);
        }

    }
}
