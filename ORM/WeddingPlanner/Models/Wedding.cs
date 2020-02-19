using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WeddingPlanner.Models
{
    public class Wedding
    {
        [Key]
        public int WeddingId {get;set;}

        [Required(ErrorMessage="Wedder One is required")]
        [Display(Name="Wedder One: ")]
        public string WedderOne {get;set;}

        [Required(ErrorMessage="Wedder Two is required")]
        [Display(Name="Wedder Two: ")]
        public string WedderTwo {get;set;}

        [FutureDate]
        [DataType(DataType.Date)]
        [Display(Name="Date: ")]
        public DateTime Date {get;set;}

        [Required(ErrorMessage="Wedding address is required")]
        [Display(Name="Wedding address: ")]
        public string Address {get;set;}

        public int UserId {get;set;}

        public User Creator {get;set;}
        public List<Association> Guests {get;set;}
        public DateTime CreatedAt {get;set;} = DateTime.Now;
        public DateTime UpdatedAt {get;set;} = DateTime.Now;

    }

    public class FutureDateAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            DateTime currentDate;
            if(value is DateTime)
            {
                currentDate = DateTime.Now;
                if((DateTime)value < currentDate)
                {
                    return new ValidationResult("Date must be in the future");
                }
                return ValidationResult.Success;
            }
            return new ValidationResult("Invalid date");
        }
    }
}