using Microsoft.AspNetCore.Mvc;
using MultiShop.Services.Interfaces;
using MultiShop.ViewModels;

namespace MultiShop.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ServicesController : Controller
    {
        private readonly IServiceService _service;

        public ServicesController(IServiceService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _service.GetAllServicesAsync());
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(ServicePostVM vm)
        {
            var isSucceded = await _service.CreateAsync(vm,ModelState);
            if (isSucceded)
            {
                return RedirectToAction("Index");
            }
            return View(vm);
        }
        public async Task<IActionResult> Update(int id)
        {
            var service=await _service.GetPutServiceAsync(id);
            return View(service);
        }
        [HttpPost]
        public async Task<IActionResult> Update(ServicePutVM vm)
        {

            var isSucceded = await _service.UpdateAsync(vm, ModelState);
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
