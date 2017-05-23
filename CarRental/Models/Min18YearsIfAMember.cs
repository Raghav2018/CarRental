using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace CarRental.Models
{
    public class Min18YearsIfAMember : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var customer = (Customer)validationContext.ObjectInstance;

            if(customer.MembershipTypeId == MembershipType.Unknown || customer.MembershipTypeId == MembershipType.PayAsYouGo)
            {
                return ValidationResult.Success;
            }

            if(customer.Birthdate == null)
            {
                return new ValidationResult("Birthdate is Required");
            }

            var age = DateTime.Today.Year - customer.Birthdate.Value.Year;

            if(age>=25)
            {
                return ValidationResult.Success;
            }
            else
            {
                return new ValidationResult("Customer should be atleast 25 years old to become on a member");
            }
        }
    }
}