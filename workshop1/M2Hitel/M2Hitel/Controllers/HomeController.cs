using M2Hitel.Models;
using M2Hitel.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace M2Hitel.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Process(HitelModel model)
        {
            if (!ModelState.IsValid)
            {
                return View("Index", model);
            }
            double[,] matrix = new double[model.T, 5];
            double toketorlesztes = model.PV * (model.R / 100);
            double tartozas = model.PV;
            double osszfizetes = 0;
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                matrix[i, 0] = i + 1;
                matrix[i, 1] = tartozas;
                matrix[i, 2] = tartozas * (model.R / 100);
                matrix[i, 3] = toketorlesztes;
                matrix[i, 4] = toketorlesztes + (tartozas * (model.R / 100));
                osszfizetes += toketorlesztes + (tartozas * (model.R / 100));
                tartozas -= toketorlesztes;
            }

            var vm = new HitelViewModel()
            {
                Matrix = matrix,
                Nev = model.Nev,
                OsszBefizetes = osszfizetes
            };
            
            return View(vm);
        }
    }
}
