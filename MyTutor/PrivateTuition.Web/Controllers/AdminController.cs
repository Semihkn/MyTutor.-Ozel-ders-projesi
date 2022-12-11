using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PrivateTuition.Business.Abstract;
using PrivateTuition.Core;
using PrivateTuition.Entity;
using PrivateTuition.Web.Identity;
using PrivateTuition.Web.Models;
using System.Data;

namespace PrivateTuition.Web.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly ICategoryService _categoryService;
        private readonly ISubjectService _subjectService;
        private readonly UserManager<MyIdentityUser> _userManager;
        private readonly SignInManager<MyIdentityUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AdminController(
            ICategoryService categoryService, ISubjectService subjectService,
            UserManager<MyIdentityUser> userManager, SignInManager<MyIdentityUser> signInManager,
            RoleManager<IdentityRole> roleManager)
        {
            _categoryService = categoryService;
            _subjectService = subjectService;
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }

        #region RolesActions
        public async Task<IActionResult> RoleList()
        {
            return View(await _roleManager.Roles.ToListAsync());
        }
        public IActionResult RoleCreate()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> RoleCreate(RoleModel roleModel)
        {
            if (ModelState.IsValid)
            {
                IdentityRole role = new IdentityRole() { Name = roleModel.Name };
                var result = await _roleManager.CreateAsync(role);
                if (result.Succeeded)
                {
                    TempData["AlertMessage"] = Jobs.CreateMessage("Tebrikler!", "Rol başarıyla oluşturuldu.", "success");
                    return RedirectToAction("RoleList");
                }
            }
            return View(roleModel);
        }
        public async Task<IActionResult> RoleEdit(string id)
        {
            var users = await _userManager.Users.ToListAsync();
            var role = await _roleManager.FindByIdAsync(id);
            var members = new List<MyIdentityUser>();
            var nonMembers = new List<MyIdentityUser>();
            foreach (var user in users)
            {
                var list = await _userManager.IsInRoleAsync(user, role.Name) ? members : nonMembers;
                list.Add(user);
                
            }
            RoleDetails roleDetails = new RoleDetails()
            {
                Role = role,
                Members = members,
                NonMembers = nonMembers
            };
            return View(roleDetails);
        }
        [HttpPost]
        public async Task<IActionResult> RoleEdit(RoleEditModel roleEditModel)
        {
            if (ModelState.IsValid)
            {
                //Seçili role eklenecek userlar
                foreach (var userId in roleEditModel.IdsToAdd ?? new string[] { })
                {
                    var user = await _userManager.FindByIdAsync(userId);
                    if (user != null)
                    {
                        var result = await _userManager.AddToRoleAsync(user, roleEditModel.RoleName);
                        if (!result.Succeeded)
                        {
                            foreach (var error in result.Errors)
                            {
                                ModelState.AddModelError("", error.Description);
                            }
                        }
                    }
                }

                //Seçili rolden çıkarılacak userlar
                foreach (var userId in roleEditModel.IdsToRemove ?? new string[] { })
                {
                    var user = await _userManager.FindByIdAsync(userId);
                    if (user != null)
                    {
                        var result = await _userManager.RemoveFromRoleAsync(user, roleEditModel.RoleName);
                        if (!result.Succeeded)
                        {
                            foreach (var error in result.Errors)
                            {
                                ModelState.AddModelError("", error.Description);
                            }
                        }
                    }
                }

            }
            return Redirect($"/Admin/RoleEdit/{roleEditModel.RoleId}");
        }
        public async Task<IActionResult> RoleDelete(string id)
        {
            var role = await _roleManager.FindByIdAsync(id);
            if (role == null) { return NotFound(); }
            foreach (var user in await _userManager.Users.ToListAsync())
            {
                if (await _userManager.IsInRoleAsync(user, role.Name))
                {
                    TempData["AlertMessage"] = Jobs.CreateMessage("Silme Başarısız oldu!", "Bu rolde userlar bulunmaktadır, önce userları silmeniz gerekmektedir.", "danger");
                    return RedirectToAction("RoleList");
                }
            }
            var result = await _roleManager.DeleteAsync(role);
            if (result.Succeeded)
            {
                TempData["AlertMessage"] = Jobs.CreateMessage("Başarılı!", "Silme işlemi tamamlandı.", "success");
            }
            return RedirectToAction("RoleList");
        }
        #endregion

        #region UserActions
        public async Task<IActionResult> UserList()
        {
            return View(await _userManager.Users.ToListAsync());
        }
        public async Task<IActionResult> UserCreate()
        {
            var roles = await _roleManager.Roles.Select(r => r.Name).ToListAsync();
            ViewBag.Roles = roles;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> UserCreate(UserModel userModel, string[] selectedRoles)
        {
            //List<string> roles = null;
            if (ModelState.IsValid)
            {
                MyIdentityUser user = new MyIdentityUser()
                {
                    FirstName = userModel.FirstName,
                    LastName = userModel.LastName,
                    UserName = userModel.UserName,
                    Email = userModel.Email
                };
                var result = await _userManager.CreateAsync(user, "Qwe123.");
                if (result.Succeeded)
                {
                    selectedRoles = selectedRoles ?? new string[] { };
                    await _userManager.AddToRolesAsync(user, selectedRoles);
                    TempData["AlertMessage"] = Jobs.CreateMessage("Tebrikler!", "Kullanıcı başarıyla oluşturuldu!", "success");
                    return RedirectToAction("UserList");
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }
            ViewBag.SelectedRoles = selectedRoles;
            ViewBag.Roles = await _roleManager.Roles.Select(r => r.Name).ToListAsync();
            return View(userModel);
        }

        public async Task<IActionResult> UserEdit(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user == null) { return RedirectToAction("UserList"); }
            var userModel = new UserModel()
            {
                UserId = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                UserName = user.UserName,
                Email = user.Email,
                SelectedRoles = await _userManager.GetRolesAsync(user)
            };
            ViewBag.Roles = await _roleManager.Roles.Select(r => r.Name).ToListAsync();
            return View(userModel);
        }

        [HttpPost]
        public async Task<IActionResult> UserEdit(UserModel userModel)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByIdAsync(userModel.UserId);
                if (user != null)
                {
                    user.FirstName = userModel.FirstName;
                    user.LastName = userModel.LastName;
                    user.UserName = userModel.UserName;
                    user.Email = userModel.Email;
                    var result = await _userManager.UpdateAsync(user);

                    if (result.Succeeded)
                    {
                        var userRoles = await _userManager.GetRolesAsync(user);
                        userModel.SelectedRoles = userModel.SelectedRoles ?? new string[] { };
                        await _userManager.AddToRolesAsync(user, userModel.SelectedRoles.Except(userRoles).ToArray<string>());
                        await _userManager.RemoveFromRolesAsync(user, userRoles.Except(userModel.SelectedRoles).ToArray<string>());
                        TempData["AlertMessage"] = Jobs.CreateMessage("Tebrikler!", "Kayıt başarıyla düzenlenmiştir.", "success");
                        return RedirectToAction("UserList");

                    }
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                    ViewBag.Roles = await _roleManager.Roles.Select(r => r.Name).ToListAsync();
                    return View(userModel);
                }
                TempData["AlertMessage"] = Jobs.CreateMessage("Hata!", "Böyle bir kullanıcı bulunamadı!", "danger");
            }
            ViewBag.Roles = await _roleManager.Roles.Select(r => r.Name).ToListAsync();
            return View(userModel);
        }
        public async Task<IActionResult> ChangeUserPassword(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            ChangePasswordModel changePasswordModel = new ChangePasswordModel() { UserId = user.Id };
            return View(changePasswordModel);
        }
        [HttpPost]
        public async Task<IActionResult> ChangeUserPassword(ChangePasswordModel changePasswordModel)
        {
            //var user = await _userManager.FindByIdAsync(changePasswordModel.UserId);
            //user.PasswordHash = _userManager.PasswordHasher.HashPassword(user, changePasswordModel.NewPassword);
            //var result = await _userManager.UpdateAsync(user);
            //if (result.Succeeded)
            //{
            //    TempData["AlertMessage"] = Jobs.CreateMessage("Başarılı!", "Tebrikler, şifre değişti", "success");
            //    return RedirectToAction("UserList");
            //}
            //return View(changePasswordModel);

            var user = await _userManager.FindByIdAsync(changePasswordModel.UserId);
            var userPassToken = await _userManager.GeneratePasswordResetTokenAsync(user);
            var result = await _userManager.ResetPasswordAsync(user, userPassToken, changePasswordModel.NewPassword);
            if (result.Succeeded)
            {
                TempData["AlertMessage"] = Jobs.CreateMessage("Başarılı!", "Tebrikler, şifre değişti", "success");
                return RedirectToAction("UserList");
            }
            return View(changePasswordModel);

        }
        public async Task<IActionResult> UserDelete(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user == null) { return NotFound(); }
            
            var result = await _userManager.DeleteAsync(user);
            if (result.Succeeded)
            {
                TempData["AlertMessage"] = Jobs.CreateMessage("Başarılı!", "Silme işlemi tamamlandı.", "success");
            }
            return RedirectToAction("UserList");
        }
        #endregion
        public IActionResult Index()
        {
            return View();
        }

        #region Subject 
        public async Task<IActionResult> SubjectList(bool isDeleted = false)
        {
            var subjects = await _subjectService.GetAllAsync(s => s.IsDeleted == isDeleted);
            ViewBag.IsDeleted = isDeleted;
            return View(subjects);
        }
        public async Task<IActionResult> SubjectEdit(int id)
        {
            var subject = await _subjectService.GetSubejctWithCategoryAsync(id);
            SubjectWithCategoryModel subjectModel = new SubjectWithCategoryModel()
            {
                Id = subject.Id,
                Name = subject.Name,         
                IsActive = subject.IsDeleted               
            };
            ViewBag.Categories = await _categoryService.GetAllAsync(c => c.IsDeleted == false);
            return View(subjectModel);
        }

        [HttpPost]
        public async Task<IActionResult> SubjectEdit(SubjectWithCategoryModel subjectWithCategoryModel, int[] categoryIds)
        {          
            string url = Jobs.MakeUrl(subjectWithCategoryModel.Name);
            if (ModelState.IsValid && categoryIds.Length > 0)
            {
                var subject = await _subjectService.GetByIdAsync(subjectWithCategoryModel.Id);
                
                if (subject == null)
                {
                    return NotFound();
                }
               
                subject.Name = subjectWithCategoryModel.Name;
                subject.IsDeleted = subjectWithCategoryModel.IsActive;
                subject.Url = url;
                
                await _subjectService.UpdateAsync(subject, categoryIds);
                return RedirectToAction("SubjectList");
            }
            if (categoryIds.Length == 0)
            {
                ViewBag.CategoryErrorMessage = "Kategori Seçin!";
            }
            else
            {
                subjectWithCategoryModel.SelectedCategories = categoryIds.Select(catId => new Category()
                {
                    Id = catId,
                }).ToList();
            }
            ViewBag.Categories = await _categoryService.GetAllAsync(c => c.IsDeleted == false);
            return View(subjectWithCategoryModel);
        }
        public async Task<IActionResult> SubjectCreate()
        {
            ViewBag.Categories = await _categoryService.GetAllAsync(c => c.IsDeleted == false);
            return View();
        }
       
        [HttpPost]
        public async Task<IActionResult> SubjectCreate(SubjectWithCategoryModel subjectModel, int[] categoryIds)
        {
            if (ModelState.IsValid && categoryIds.Length > 0)
            {
                var url = Jobs.MakeUrl(subjectModel.Id + subjectModel.Name);
                Subject subject = new Subject()
                {
                    Name = subjectModel.Name,                   
                    Url = url,           
                    IsDeleted=!subjectModel.IsActive
                };
                await _subjectService.CreateAsync(subject, categoryIds);
                return RedirectToAction("SubjectList");
            }
            
            if (categoryIds.Length == 0)
            {
                ViewBag.CategoryErrorMessage = "Lütfen bir kategori seç!";
            }
            else
            {
                ViewData["SelectedCategories"] = categoryIds;
            }
            ViewBag.Categories = await _categoryService.GetAllAsync(c => c.IsDeleted == false);
            return View(subjectModel);
        }
        public async Task<IActionResult> SubjectDelete(int id)
        {
            Subject subject = await _subjectService.GetByIdAsync(id);
            if (subject != null)
            {
                subject.IsDeleted = subject.IsDeleted ? false : true;
                _subjectService.IsDelete(subject);
            }
            return RedirectToAction("SubjectList");
        }
        public async Task<IActionResult> SubjectDeletePermanently(int id)
        {
            var subject = await _subjectService.GetByIdAsync(id);
            if (subject == null)
            {
                return NotFound();
            }
            _subjectService.Delete(subject);
            return Redirect("/Admin/SubjectList?isDeleted=true");
        }
        #endregion


        #region Category 

        public IActionResult CategoryCreate()
        {
            return View();
        }
        public async Task<IActionResult> CategoryList(bool isDeleted = false)
        {
            var categories = await _categoryService.GetAllCategoriesAsync(isDeleted);
            ViewBag.IsDeleted = isDeleted;
            return View(categories);
        }
        [HttpPost]
        public async Task<IActionResult> CategoryCreate(CategoryModel categoryModel)
        {
            if (ModelState.IsValid)
            {
                var url = Jobs.MakeUrl(categoryModel.Id + categoryModel.Name);
                Category category = new Category()
                {
                    Name = categoryModel.Name,
                    Url = url
                };
                await _categoryService.CreateAsync(category);
                return RedirectToAction("CategoryList");
            }

            return View(categoryModel);
        }
        public async Task<IActionResult> CategoryEdit(int id)
        {
            var category = await _categoryService.GetCategoryWithOneSubjectAsync(id);
            CategoryModel categoryModel = new CategoryModel()
            {
                Id = category.Id,
                Name = category.Name,
                IsDeleted = category.IsDeleted,
                Subjects = category
                    .SubjectCategories
                    .Select(sc => sc.Subject)
                    .ToList()
            };
            return View(categoryModel);

        }
        [HttpPost]
        public async Task<IActionResult> CategoryEdit(CategoryModel categoryModel)
        {

            if (ModelState.IsValid)
            {
                string url = Jobs.MakeUrl(categoryModel.Id + categoryModel.Name);
                var category = await _categoryService.GetByIdAsync(categoryModel.Id);
                if (category == null)
                {
                    return NotFound();
                }
                category.Name = categoryModel.Name;              
                category.Url = url;
                _categoryService.Update(category);
                return RedirectToAction("CategoryList");
            }
            return View(categoryModel);
        }
       
        public async Task<IActionResult> CategoryDelete(int id)
        {
            Category category = await _categoryService.GetByIdAsync(id);
            if (category == null)
            {
                return NotFound();
            }
            category.IsDeleted = category.IsDeleted ? false : true;
            _categoryService.IsDelete(category);
            return RedirectToAction("CategoryList");
        }
        public async Task<IActionResult> CategoryDeletePermanently(int id)
        {
            var category = await _categoryService.GetByIdAsync(id);
            if (category == null)
            {
                return NotFound();
            }
            _categoryService.Delete(category);
            return Redirect("/Admin/CategoryList?isDeleted=true");
        }
        #endregion

    }
}
