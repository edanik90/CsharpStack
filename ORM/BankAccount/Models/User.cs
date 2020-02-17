using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BankAccount.Models
{
    public class User
    {
        [Key]
        public int UserId {get;set;}
        [Required(ErrorMessage = "First Name is required")]
        [Display(Name = "First Name:")]
        [MinLength(3, ErrorMessage = "First name must be at least 3 characters")]
        
        public string FirstName {get;set;}
        [Required(ErrorMessage = "Last Name is required")]
        [Display(Name = "Last Name:")]
        [MinLength(3, ErrorMessage = "Last name must be at least 3 characters")]

        public string LastName {get;set;}
        [Required(ErrorMessage = "Email is required")]
        [EmailAddress]
        [Display(Name = "Email:")]
        public string Email {get;set;}
        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        [Display(Name = "Password:")]
        [MinLength(8, ErrorMessage = "Password must be at least 8 characters")]

        public string Password {get;set;}
        [NotMapped]
        [DataType(DataType.Password)]
        [Compare("Password")]
        [Required(ErrorMessage = "Please, confirm password")]
        [Display(Name = "Confirm password:")]

        public string ConfirmPassword {get;set;}

        public List<Transaction> MyTransactions {get;set;}
        public DateTime CreatedAt {get;set;} = DateTime.Now;
        public DateTime UpdatedAt {get;set;} = DateTime.Now;
    }
}