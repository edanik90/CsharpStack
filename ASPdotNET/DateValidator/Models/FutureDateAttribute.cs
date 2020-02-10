using System.ComponentModel.DataAnnotations;
namespace DateValidator.Models
{
    public class FutureDateAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            // You first may want to unbox "value" here and cast to to a DateTime variable!
        if(value is Date)
        {
            Date currentDate = Date.Now;
            if(DateTime.Compare(value, currentDate) > 0)
            {
                return new ValidationResult("Birthday cannot be in the future!");
            }
            return ValidationResult.Success;
        }
        }
    }
}

