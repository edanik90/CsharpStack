using ProductsAndCategories.Models;
using Microsoft.EntityFrameworkCore;

public class HomeContext:DbContext
{
    public HomeContext(DbContextOptions options):base(options){}
    public DbSet<Product> Products {get;set;}
    public DbSet<Category> Categories {get;set;}
    public DbSet<Association> Associations {get;set;}
}