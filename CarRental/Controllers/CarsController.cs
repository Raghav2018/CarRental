using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CarRental.Models;
using CarRental.ViewModels;
using System.Data.Entity;

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
            var cars = _context.Cars.Include(c =>c.Type).ToList();
            return View(cars);
        }

        public ActionResult Details(int id)
        {
            var cars = _context.Cars.Include(c => c.Type).SingleOrDefault(c => c.Id == id);
            if (cars == null)
                return HttpNotFound();

            return View(cars);
        }

    }
}