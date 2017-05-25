using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CarRental.Models;
using CarRental.Dtos;

namespace CarRental.Controllers.Api
{
    public class NewRentalsController : ApiController
    {
        private ApplicationDbContext _context;

        public NewRentalsController()
        {
            _context = new ApplicationDbContext();
        }
        [HttpPost]
        public IHttpActionResult CreateNewRentals(NewRentalDTo newRental)
        {
            var customer = _context.Customers.Single(
                c => c.Id == newRental.CustomerID);

            var cars = _context.Cars.Where(
                c => newRental.CarIds.Contains(c.Id)).ToList();

            foreach(var car in cars)
            {
                if(car.NumberAvailable == 0)
                {
                    return BadRequest();
                }

                car.NumberAvailable--;

                var rental = new Rental
                {
                    Customer = customer,
                    Car = car,
                    DateRented = DateTime.Now
                };

                _context.Rentals.Add(rental);
            }

            _context.SaveChanges();

            return Ok();
        }
    }
}
