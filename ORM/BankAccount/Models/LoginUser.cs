using System.ComponentModel.DataAnnotations;

namespace BankAccount.Models
{
    public class LoginUser
    {
        [EmailAddress]
        [Display(Name = "Email: ")]
        public string LoginEmail {get;set;}

        [DataType(DataType.Password)]
        [Display(Name = "Password: ")]
        public string LoginPassword {get;set;}
    }
}