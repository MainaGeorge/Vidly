using System;
using System.ComponentModel.DataAnnotations;
using Vidly.DTOs;

namespace Vidly.Models
{
    public sealed class Ensure18YearsOfAgeWithAnySubscription : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var customer = (CustomerDto)validationContext.ObjectInstance;

            if (customer.MembershipTypeId == MembershipType.PayAsYouGo
                || customer.MembershipTypeId == MembershipType.UnknownSubscription)
            {
                return ValidationResult.Success;
            }
            else
            {
                if (customer.BirthDate == null)
                {
                    return new ValidationResult(errorMessage: "Date of birth is required");
                }
                else
                {
                    var age = DateTime.Now.Year - customer.BirthDate.Value.Year;

                    return age < 18 ? new ValidationResult("You must be at least 18 years old to have a subscription") : ValidationResult.Success;
                }
            }


        }
    }
}