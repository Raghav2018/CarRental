using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CarRental.Models;
using CarRental.ViewModels;

namespace CarRental.Controllers
{
    public class CarsController : Controller
    {
        // GET: Cars/Random 
        public ViewResult Index()
        {
            var cars = GetCars();
            return View(cars);
        }

        [Route("cars/byyear/{year}")]
        public ActionResult ByYear(int year)
        {
            return Content(GetCars().SingleOrDefault(c => c.year == year).Name);
        }

        public IEnumerable<Car> GetCars()
        {
            return new List<Car>
            {
                new Car {Id=1, Name="Mustang", year = 2014 },
                new Car {Id =2, Name ="Camero", year=2013 }
            };
        }

    }
}