using System;
using System.ComponentModel.DataAnnotations;

namespace BankAccount.Models
{
    public class Transaction
    {
        [Key]
        public int  TransactionId {get;set;}

        [Required(ErrorMessage = "Must enter an amount")]
        [Display(Name="Deposit/Withdraw: ")]
        public double Ammount {get;set;}

        public int UserId {get;set;}

        public User AccountHolder {get;set;}

        public DateTime CreatedAt {get;set;} = DateTime.Now;
        public DateTime UpdatedAt {get;set;} = DateTime.Now;
    }
}