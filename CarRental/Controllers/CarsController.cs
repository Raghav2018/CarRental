using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CarRental.Models;
using CarRental.ViewModels;
using System.Data.Entity;
using CarRental.Migrations;

namespace CarRental.Controllers
{
    public class CarsController : Controller
    {
        private ApplicationDbContext _context;

        public CarsController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Cars/Random 
        public ViewResult Index()
        {
            if (User.IsInRole(RoleName.CanManageCars))
                return View("List");

            return View("ReadOnlyList");
        }

        [Authorize(Roles = RoleName.CanManageCars)]
        public ActionResult New()
        {
            var carTypes = _context.carTypes.ToList();
            var viewModel = new CarFormViewModel()
            {
                car = new Caar(),
                carTypes = carTypes
            };
            return View("CarForm", viewModel);
        }

        [Authorize(Roles = RoleName.CanManageCars)]
        public ActionResult Edit(int id)
        {
            var car = _context.Cars.SingleOrDefault(c => c.Id == id);

            if (car == null)
                return HttpNotFound();

            var viewModel = new CarFormViewModel()
            {
                car = car,
                carTypes = _context.carTypes.ToList()
            };
            return View("CarForm", viewModel);
        }

        public ActionResult Details(int id)
        {
            var cars = _context.Cars.Include(c => c.carType).SingleOrDefault(c => c.Id == id);
            if (cars == null)
                return HttpNotFound();

            return View(cars);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = RoleName.CanManageCars)]
        public ActionResult Save(Caar car)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new CarFormViewModel
                {
                    car = car,
                    carTypes = _context.carTypes.ToList()
                };

                return View("CarForm", viewModel);
            }

            if (car.Id == 0)
            {
                _context.Cars.Add(car);
            }
            //else
            //{
            //    var carinDb = _context.Cars.Single(c => c.Id == car.Id);
            //    carinDb.Name = car.Name;
            //    carinDb.year = car.year;
            //    carinDb.carTypeId = car.carTypeId;
            //    carinDb.stock = car.stock;
            //}
            _context.SaveChanges();
            return RedirectToAction("Index", "Cars");
        }
    }
}