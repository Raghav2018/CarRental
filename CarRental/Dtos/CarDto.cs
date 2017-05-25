using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using CarRental.Models;

namespace CarRental.Dtos
{
    public class CarDto
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [Required]
//        [MinMaxCarAge]
        public int year { get; set; }

        [Required]
        public int carTypeId { get; set; }

        public CarTypeDto carType { get; set; }

        [Required]
        [Range(0, 20)]
        public int stock { set; get; }
    }
}