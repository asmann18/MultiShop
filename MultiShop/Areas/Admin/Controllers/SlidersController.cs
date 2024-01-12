using Microsoft.AspNetCore.Mvc;
using MultiShop.Services.Interfaces;
using MultiShop.ViewModels;

namespace MultiShop.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SlidersController : Controller
    {
        private readonly ISliderService _service;

        public SlidersController(ISliderService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            var sliders = await _service.GetAllSlidersAsync();
            return View(sliders);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(SliderPostVM vm)
        {
            var isSucceded = await _service.CreateAsync(vm, ModelState);
            if (isSucceded)
            {
                return RedirectToAction("Index");
            }
            return View(vm);
        }
        public async Task<IActionResult> Update(int id)
        {
            var vm =await _service.GetPutSliderAsync(id);
            return View(vm);
        }
        [HttpPost]
        public async Task<IActionResult> Update(SliderPutVM vm)
        {
            var isSucceded=await _service.UpdateAsync(vm, ModelState);
            if (isSucceded)
            {
                return RedirectToAction("Index");
            }
            return View(vm);
        }
        public async Task<IActionResult> Delete(int id)
        {
            await _service.DeleteAsync(id);
            return RedirectToAction("Index");
        }
    }
}
