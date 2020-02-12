using System;
using System.ComponentModel.DataAnnotations;
namespace DateValidator.Models

{
    public class User
    {
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
        [DataType(DataType.Date)]
        public DateTime Birthday {get;set;}

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress]
        public string Email {get;set;}

        [Required(ErrorMessage = "Password is required")]
        [MinLength(4, ErrorMessage = "Password should be at least 8 characters long")]
        [DataType(DataType.Password)]
        public string Password {get;set;}

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
                    return new ValidationResult("Birthday cannot be in the future!");
                }
                return ValidationResult.Success;
            }
            return new ValidationResult("Invalid date");
        }
    }
}