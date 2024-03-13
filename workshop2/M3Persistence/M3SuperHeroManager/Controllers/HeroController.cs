using M3SuperHeroManager.Data;
using M3SuperHeroManager.Models;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using System.IO;

namespace M3SuperHeroManager.Controllers
{
    public class HeroController : Controller
    {
        ISuperHeroRepository repository;

        public HeroController(ISuperHeroRepository repository)
        {
            this.repository = repository;
        }

        [OutputCache(Duration = 5, VaryByParam = "none")]
        public IActionResult Index()
        {
            return View(this.repository.Read());
        }

        [OutputCache(Duration = 5, VaryByParam = "none")]
        [HttpGet]
        public IActionResult Create()
        {
            
            return View();
        }

        [HttpPost]
        public IActionResult Create(SuperHero hero)
        {
            if (!ModelState.IsValid)
            {
                return View(hero);
            }
            repository.Create(hero);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Delete(string name)
        {
            repository.Delete(name);
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Update(string name)
        {
            var hero = repository.Read(name);
            return View(hero);
        }

        [HttpPost]
        public IActionResult Update(SuperHero hero)
        {
            if (!ModelState.IsValid)
            {
                return View(hero);
            }
            repository.Update(hero);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult GetImage(string id)
        {
            var hero = repository.ReadFromId(id);
            if (hero.ContentType.Length > 3)
            {
                return new FileContentResult(hero.Data, hero.ContentType);
            }
            else
            {
                return BadRequest();
            }
            
        }

        public IActionResult Error()
        {
            var exceptionHandlerPathFeature =
            HttpContext.Features.Get<IExceptionHandlerPathFeature>();
            var msg = exceptionHandlerPathFeature.Error.Message;
            return View("Error", msg);
        }



    }
}
