using Microsoft.AspNetCore.Mvc;
using PrivateTuition.Business.Abstract;
using Newtonsoft.Json;
using PrivateTuition.Entity;

namespace PrivateTuition.Web.Controllers
{
    public class CitiesController : Controller
    {
        private ICitiesService _citiesService;
        private IDistrictService _districtService;
        public CitiesController(ICitiesService citiesService, IDistrictService districtService)
        {
            _citiesService = citiesService;
            _districtService = districtService;
        }
        public IActionResult Index()
        {
            //var path = Path.Combine(Directory.GetCurrentDirectory(), $"wwwroot/il.json");


            //JsonSerializer serializer = new JsonSerializer();
            //Root o = new();
            //using (FileStream s = new FileStream(path, FileMode.Open))
            //using (StreamReader sr = new StreamReader(s))
            //using (JsonReader reader = new JsonTextReader(sr))
            //{
            //    while (reader.Read())
            //    {
            //        // deserialize only when there's "{" character in the stream
            //        if (reader.TokenType == JsonToken.StartObject)
            //        {
            //            o = serializer.Deserialize<Root>(reader);
            //        }
            //    }
            //}

            //_citiesService.BulkInsert(o.data);
            var response = _citiesService.GetAllAsync(q => q.Id > 0);
            return Ok(response.Result);
        }
        [HttpGet]
        public  IActionResult GetDistrictByCityId(int id)
        {
            var response = _districtService.GetDistrictByCity(id).Result;
            return Ok(response);
        }
    }
}
