using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace CarRental.Models
{
    public class MinMaxCarAge : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var car = (Caar)validationContext.ObjectInstance;

            var age = DateTime.Today.Year - car.year;

            if(age>20)
            {
                return new ValidationResult("Car is too old to be added to inventory");
            }
            else if(age<0)
            {
                return new ValidationResult("Please enter valid year. No later than current year");
            }
            else
            {
                return ValidationResult.Success;
            }

        }
    }
}