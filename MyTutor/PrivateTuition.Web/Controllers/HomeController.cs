using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using PrivateTuition.Business.Abstract;
using PrivateTuition.Entity;
using PrivateTuition.Web.Models;
using System.Diagnostics;

namespace PrivateTuition.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IShowCardService _showCardService;
        private readonly ICategoryService _categoryService;
       

        public HomeController(IShowCardService showCardService, ICategoryService categoryService)
        {
            _showCardService = showCardService;
            _categoryService = categoryService;
             
        }

        public async Task<IActionResult> Index()
        {
            
            //ShowCardları ana sayfada göstermek istiyoruz
            var homeShowCards = await _showCardService.GetHomeShowCardsAsync(null);

            return View(homeShowCards);
        }

        //public async Task<IActionResult> ShowCardList(string category,int page,int pageSize)
        //{         
        //    var homeShowCards = await _showCardService.GetShowCardsByCategoryAsync(category,page,pageSize);


        //    return View("Index", homeShowCards);
        //}

        public async Task<IActionResult> ShowCardList(string category)
        {
            var homeShowCards = await _showCardService.GetHomeShowCardsAsync(category);


            return View("Index", homeShowCards);
        }
        

    }
}