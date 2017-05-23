using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CarRental.Models;

namespace CarRental.ViewModels
{
    public class CarFormViewModel
    {
        public Caar car { get; set; }
        public IEnumerable<CarRental.Models.carType> carTypes { get; set; }
    }
}