using Feladat.ViewModels;
using M2Hitel.Models;
using M2Hitel.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Feladat.Controllers
{
    public class HomeController : Controller
    {
        static List<TevekenysegViewModel> tevekenysegLista = new List<TevekenysegViewModel>();
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Process(string tevekenyseg, int idotartam, int befejezes)
        {
            //var vm = new HitelViewModel()
            //{
            //    Nev = tevekenyseg
            //};

            var vm = new TevekenysegViewModel()
            {
                tevekenysegNev = tevekenyseg,
                idotartam = idotartam,
                befejezes = befejezes
            };

            if (tevekenysegLista.Count() != 0 ) {
                var utolso = tevekenysegLista[tevekenysegLista.Count() - 1];
                if (utolso.befejezes + vm.idotartam <= 24
                    && utolso.befejezes + vm.idotartam <= vm.befejezes)
                {
                    tevekenysegLista.Add(vm);
                }
            }
            else { tevekenysegLista.Add(vm); }
            

            return View(tevekenysegLista);
        }
    }
}
