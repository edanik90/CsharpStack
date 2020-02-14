using CRUDelicious.Models;
using Microsoft.EntityFrameworkCore;

public class HomeContext : DbContext
{
    public HomeContext(DbContextOptions options):base(options){}
    public DbSet<Dish> Dishes {get;set;}
}