using Microsoft.EntityFrameworkCore;
using BankAccount.Models;

namespace BankAccount.Contexts
{
    public class HomeContext : DbContext
    {
        public HomeContext(DbContextOptions options) : base(options){}

        public DbSet<User> Users {get;set;}

        public DbSet<Transaction> Transactions {get;set;}
    }
}