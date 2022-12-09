using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PrivateTuition.Business.Abstract;
using PrivateTuition.Data.Concrete.EFCore;
using PrivateTuition.Entity;
using PrivateTuition.Entity.Enum;
using PrivateTuition.Web.ViewModels;


namespace PrivateTuition.Web.Controllers
{
    public class CategoryController : Controller
    {     
        private ICategoryService _categoryService;
        private IShowCardService _showCardService;
        private ISubjectService _subjectService;

        public CategoryController(ICategoryService categoryService, IShowCardService showCardService, ISubjectService subjectService)
        {
            _categoryService = categoryService;
            _showCardService = showCardService;
            _subjectService = subjectService;
        }

        public async Task<IActionResult> Index(bool isDeleted)
        {
            
            var categories = await _categoryService.GetAllCategoriesAsync(isDeleted);
            return View(categories);
            //Bu yol, view adını söylemememize rağmen Views/Category/Index.cshtml viewine categories modelini yollar.(Metot adı Index iken)
            //return View("index", categories);//Bu ise hem gidilecek view adını hem de gönderilecek modeli belirtmemizi sağlar

        }

        public async Task<IActionResult> List(string category, int page = 1)  //List by category
        {
            const int pageSize = 9; //Bir sayfada gösterilecek ilan sayısı
            List<ShowCard> showCards = await _showCardService.GetShowCardsByCategoryAsync(category, page, pageSize);

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
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var categories = await _categoryService.GetAllCategoriesAsync(false);
            return Ok(categories);
        }

        public async Task<IActionResult> GetSubject(string id)
        {

            var subjects = await _subjectService.GetSubjectsByCategory(Convert.ToInt32(id));
            var responseJson = JsonConvert.SerializeObject(subjects, new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore });
            return Ok(responseJson);
        }
        [HttpGet]
        public async Task<IActionResult> GetWorkMethod()
        {
            var response = Enum.GetValues(typeof(WorkMethods)).Cast<WorkMethods>().Select(q => q.ToString()).ToList();
            return Ok(response);
        }
    }
}
