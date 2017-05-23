using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace CarRental.Models
{
    public class Type
    {
        public int Id { get; set; }
        [Required]
        public string carType { get; set; }
    }
}