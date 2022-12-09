using Microsoft.AspNetCore.Mvc;
using PrivateTuition.Business.Abstract;

namespace PrivateTuition.Web.Component
{
    public class CategoriesViewComponent : ViewComponent
    {
        private readonly ICategoryService _categoryService;
        private readonly ISubjectService _subjectService;

        public CategoriesViewComponent(ICategoryService categoryService, ISubjectService subjectService)
        {
            _categoryService = categoryService;
            _subjectService = subjectService;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            if (RouteData.Values["category"] != null)
            {
                ViewBag.SelectedCategory = RouteData.Values["category"];
            }
            var categories = await _categoryService.GetAllAsync(c => c.IsDeleted == false);


            return View(categories);

        }
        //public async Task<IViewComponentResult> InvokeSubAsync()
        //{
        //    if (RouteData.Values["subject"] != null)
        //    {
        //        ViewBag.SelectedSubject = RouteData.Values["subject"];
        //    }
        //    var subjects = await _subjectService.GetAllAsync(c => c.IsDeleted == false);

        //    return View(subjects);
        //}

         

    }
}

