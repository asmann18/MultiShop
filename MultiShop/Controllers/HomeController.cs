using Microsoft.AspNetCore.Mvc;
using MultiShop.Services.Interfaces;
using MultiShop.ViewModels;

namespace MultiShop.Controllers
{
    public class HomeController : Controller
    {
        private readonly ISliderService _sliderService;
        private readonly IServiceService _serviceService;

        public HomeController(ISliderService sliderService, IServiceService serviceService)
        {
            _sliderService = sliderService;
            _serviceService = serviceService;
        }

        public async Task<IActionResult> Index()
        {
            HomeVM vm = new()
            {
                Sliders = await _sliderService.GetAllSlidersAsync(),
                Services = await _serviceService.GetAllServicesAsync()
            };
            return View(vm);
        }
    }
}
