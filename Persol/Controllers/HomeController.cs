using Persol.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Persol.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Update(int carId, string carName, string carMake, string carYear, string carModel)
        {
            ViewBag.Details = new Car()
            {
                Id = carId,
                Name = carName,
                Make = carMake,
                Year = carYear,
                Model = carModel,
            };

            return View();
        }

        public ActionResult Store()
        {
            return View();
        }
    }
}