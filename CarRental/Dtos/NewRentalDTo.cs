using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarRental.Dtos
{
    public class NewRentalDTo
    {
        public int CustomerID { get; set; }
        public List<int> CarIds { get; set; }
    }
}