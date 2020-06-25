using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ConstructionCalculator.Web.Models;
using ConstructionCalculator.Web.Services;

namespace ConstructionCalculator.Web.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult Calculator(CalculatorViewModel viewModel)
        {
            MessurementService objMessurementService = new MessurementService()
            {
                RoomsQte = viewModel.RoomsQte,
                BathQte = viewModel.BathQte,
                ClosetQte = viewModel.ClosetsQte,
                OfficeEx = viewModel.OfficeEx,
                TheaterEx = viewModel.TheaterEx,
                LivingTp = viewModel.LivinGtp,
                BalconyTp = viewModel.BalconyTp,
                GarageQte = viewModel.GarageQte,
                KitchenTp = viewModel.KitchenTp,
                PoolTp = viewModel.PoolTp
            };

            objMessurementService.CalculateRooms();

            var resultadoCalculo = 200; //Exemplo de resultado

            return new JsonResult(new 
            {
                resultadoCalculo
            });
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
