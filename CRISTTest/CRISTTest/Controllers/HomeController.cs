using CRISTTest.DAL;
using CRISTTest.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
//using System.Web.Mvc;

namespace CRISTTest.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            //DataAccessRepository repository = new DataAccessRepository();
            //DataSet ds = repository.GetExposureForecastData();
            //List<ExposureForecast> exposureForecasts = repository.ExposureForecastDataSetToEntity(ds);
            //ViewBag.exposureForecasts = exposureForecasts;
            return View();
        }
        
        public JsonResult GetForecastData(DateTime startDate, DateTime endDate)
        {
            DataAccessRepository repository = new DataAccessRepository();
            DataSet ds = repository.GetExposureForecastData(startDate, endDate);
            List<ExposureForecast> exposureForecasts = repository.ExposureForecastDataSetToEntity(ds);
            var json = JsonConvert.SerializeObject(exposureForecasts);
            //ViewBag.exposureForecasts = exposureForecasts;
            // return Json(json, System.Web.Mvc.JsonRequestBehavior.AllowGet); //Json.(json,JsonReque)
            return Json(json);
            
        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}