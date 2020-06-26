using System;
using System.Globalization;
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
            objMessurementService.CalculateRooms();
            objMessurementService.CalculateBath();
            objMessurementService.CalculateCloset();
            objMessurementService.CalculateOffice();
            objMessurementService.CalculateTheater();
            objMessurementService.CalculateLiving();
            objMessurementService.CalculateBalcony();
            objMessurementService.CalculateGarage();
            objMessurementService.CalculateKitchen();
            objMessurementService.CalculatePool();
            objMessurementService.SumPartialArea();
            objMessurementService.CalculateComplementaryArea();
            objMessurementService.CalculateTotalArea();
            objMessurementService.CalculateTerrainPrice();
            objMessurementService.CalculateConstructionPrice();
            objMessurementService.CalculateTotalPrice();
            var terrainPrice= string.Format(CultureInfo.GetCultureInfo("pt-BR"), "{0:C}", objMessurementService.TerrainPrice);
            var contructionPrice = string.Format(CultureInfo.GetCultureInfo("pt-BR"), "{0:C}", objMessurementService.ConstructionPrice);
            var totalPrice = string.Format(CultureInfo.GetCultureInfo("pt-BR"), "{0:C}", objMessurementService.TotalPrice);

            var resultadoCalculo = "Area Total: "
                + objMessurementService.TotalArea.ToString("F2")
                + " m² \n"
                + "Preço do Terreno: "
                + terrainPrice
                + "\n"
                + "Preço da Construção: "
                + contructionPrice
                + "\n"
                + "Preço Total: "
                + totalPrice;//Exemplo de resultado

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
