using GymMangementPLL.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GymMangementPL.Controllers
{
    public class HomeController : Controller
    {
        public IAnalaticalService _analaticalService { get; set; }
        public HomeController(IAnalaticalService analaticalService)
        {
            _analaticalService = analaticalService;
        }


        public IActionResult Index()
        {
            var model = _analaticalService.GetAnalaticalData();
            return View(model);
        }
    }
}
