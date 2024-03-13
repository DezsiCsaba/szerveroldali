using M6SessionManagement.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace M6SessionManagement
{
    public class HomeController : Controller
    {
        static List<Person> people = new List<Person>();
        public IActionResult Index()
        {
            var person = new Person();
            HttpContext.Session.SetString("person", JsonConvert.SerializeObject(person));
            return View(person);
        }

        [HttpPost]
        public IActionResult Index(Person person)
        {
            HttpContext.Session.SetString("person", JsonConvert.SerializeObject(person));
            return RedirectToAction(nameof(Age));
        }

        public IActionResult Age()
        {
            var person = JsonConvert.DeserializeObject<Person>(HttpContext.Session.GetString("person"));
            return View(person);
        }

        [HttpPost]
        public IActionResult Age(Person person)
        {
            HttpContext.Session.SetString("person", JsonConvert.SerializeObject(person));
            return RedirectToAction(nameof(Job));
        }

        public IActionResult Job()
        {
            var person = JsonConvert.DeserializeObject<Person>(HttpContext.Session.GetString("person"));
            return View(person);
        }

        [HttpPost]
        public IActionResult Job(Person person)
        {
            HttpContext.Session.SetString("person", JsonConvert.SerializeObject(person));
            people.Add(person);
            return RedirectToAction(nameof(List));
        }

        public IActionResult List()
        {
            return View(people);
        }
    }
}
