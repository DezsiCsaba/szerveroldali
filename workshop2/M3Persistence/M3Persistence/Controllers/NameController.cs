using M3Persistence.Data;
using Microsoft.AspNetCore.Mvc;

namespace M3Persistence.Controllers
{
    public class NameController : Controller
    {
        INameRepository repo;

        public NameController(INameRepository repo)
        {
            this.repo = repo;
        }

        [HttpGet]
        public IActionResult Add(string name)
        {
            this.repo.Add(name);
            return RedirectToAction(nameof(List));
        }

        [HttpGet]
        public string List()
        {
            return this.repo.List();
        }
    }
}
