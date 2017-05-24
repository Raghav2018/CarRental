using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CarRental.Models;
using CarRental.Dtos;
using CarRental.Controllers;
using AutoMapper;

namespace CarRental.Controllers.Api
{
    public class CarsController : ApiController
    {
        private ApplicationDbContext _context;

        public CarsController()
        {
            _context = new ApplicationDbContext();
        }
        //GET /api/cars
        public IHttpActionResult GetCars()
        {
            var carDto = _context.Cars.ToList().Select(Mapper.Map<Caar, CarDto>);
            return Ok(carDto);
        }

        //GET /api/cars/1
        public IHttpActionResult GetCar(int id)
        {
            var car = _context.Cars.SingleOrDefault(c => c.Id == id);
            if (car == null)
                return NotFound();

            return Ok(Mapper.Map<Caar, CarDto>(car));
        }

        //POST /api/cars 
        [HttpPost]
        public IHttpActionResult CreateCar(CarDto carDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var car = Mapper.Map<CarDto, Caar>(carDto);
            _context.Cars.Add(car);
            _context.SaveChanges();

            carDto.Id = car.Id;
            return Created(new Uri(Request.RequestUri + "/" + car.Id), carDto);
        }

        //PUT /api/cars/1
        [HttpPut]
        public IHttpActionResult updateCar(int id, CarDto carDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var carInDb = _context.Cars.SingleOrDefault(c => c.Id == id);

            if (carInDb == null)
                return NotFound();

            Mapper.Map<CarDto, Caar>(carDto, carInDb);

            _context.SaveChanges();

            return Ok();
        }

        // DELETE /api/cars/1
        [HttpDelete]
        public IHttpActionResult DeleteCar(int id)
        {
            var carInDb = _context.Cars.SingleOrDefault(c => c.Id == id);

            if (carInDb == null)
                return BadRequest();

            _context.Cars.Remove(carInDb);
            _context.SaveChanges();

            return Ok();
        }
    }
}
