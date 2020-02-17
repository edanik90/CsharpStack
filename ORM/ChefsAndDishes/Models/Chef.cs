using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ChefsAndDishes.Models
{
    public class Chef
    {
        [Key]
        public int ChefId {get;set;}

        [Required(ErrorMessage = "First Name is required")]
        [MinLength(4, ErrorMessage = "First Name should be at least 4 characters")]
        [Display(Name = "First Name:")]
        public string FirstName {get;set;}

        [Required(ErrorMessage = "Last Name is required")]
        [MinLength(4, ErrorMessage = "Last Name should be at least 4 characters")]
        [Display(Name = "Last Name:")]
        public string LastName {get;set;}

        [Required(ErrorMessage = "Birthday is required")]
        [FutureDate]
        [AgeCheck]
        [DataType(DataType.Date)]
        public DateTime Birthday {get;set;}

        public List<Dish> Dishes {get;set;}
    }

    public class FutureDateAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            DateTime currentDate;
            if(value is DateTime)
            {
                currentDate = DateTime.Now;
                if((DateTime)value > currentDate)
                {
                    return new ValidationResult("Birthday must be in the past");
                }
                return ValidationResult.Success;
            }
            return new ValidationResult("Invalid date");
        }
    }

    public class AgeCheckAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            DateTime today = DateTime.Today;
            if(value is DateTime)
            {
                DateTime birthdate = (DateTime)value;
                var age = today.Year - birthdate.Year;
                if (birthdate.Date > today.AddYears(-age))
                    {
                        age--;
                    }
                if(age < 18)
                {
                    return new ValidationResult("Chef must be 18 y/o or older");
                }
                return ValidationResult.Success;
            }
            return new ValidationResult("Invalid date");
        }
    }
}