using System.ComponentModel.DataAnnotations;
namespace FormSubmission.Models
{
    public class User
    {
        [Required]
        [MinLength(4)]
        [Display(Name = "First Name:")]
        public string FirstName {get;set;}

        [Required]
        [MinLength(4)]
        [Display(Name = "Last Name:")]
        public string LastName {get;set;}

        [Required]
        [Range(0,1000)]
        public int Age {get;set;}

        [Required]
        [EmailAddress]
        public string Email {get;set;}

        [Required]
        // [Range(8,60)]
        [DataType(DataType.Password)]
        public string Password {get;set;}

    }
}