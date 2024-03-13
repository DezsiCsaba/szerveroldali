using EtelTarolas.Data;
using EtelTarolas.Models;
using Microsoft.AspNetCore.Mvc;

namespace Feladat.Controllers
{
    public class HomeController : Controller
    {
        IFoodRepository repository;

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {

            return View();
        }

        [HttpPost]
        public IActionResult Create(Food food)
        {
            repository.Create(food);
            return RedirectToAction(nameof(Index));
        }

    }
}
