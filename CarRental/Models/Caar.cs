using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace CarRental.Models
{
    public class Caar
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [Display(Name ="Model Year")]
        [Required]
        [MinMaxCarAge]
        public int? year { get; set; }

        [Required]
        [Range(0, 20)]
        [Display(Name = "Number of stock")]
        public int? stock { set; get; }

        public carType carType { get; set; }       

        [Display(Name ="Type of Car")]
        public int carTypeId { get; set; }
    }
}