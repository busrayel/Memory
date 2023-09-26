using AutoMapper;
using Memory.Business.Abstract;

using Memory.Entites.Concrete.Dtos;
using Memory.WebUI.Models;
using Microsoft.AspNetCore.Mvc;

namespace Memory.WebUI.Controllers
{
    public class CityController : Controller
    {
        private readonly ICityService _cityService;
        

        public CityController(ICityService cityService, Mapper mapper)
        {
            _cityService = cityService;
            
        }
        public IActionResult Index()
        {

            return View();
        }
        [HttpGet] public IActionResult AddCity() => View();



        [HttpPost]
        public async Task<IActionResult> AddCity(CityDto cityDto)
        {
            bool isTrue = await _cityService.AddCityAsync(cityDto);
            return isTrue ? RedirectToAction("Index") : View();
        }
    }
}
