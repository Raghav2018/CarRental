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
        public string Name { get; set; }
        [Display(Name ="Model Year")]
        public int year { get; set; }
        public carType carType { get; set; }
        [Required]
        [Display(Name = "Number of stock")]
        public int stock { set; get; }
        [Display(Name ="Car Type")]
        public int carTypeId { get; set; }
    }
}