using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductsAndCategories.Models;

namespace ProductsAndCategories.Controllers
{
    public class HomeController : Controller
    {
        private HomeContext dbContext;
        public HomeController(HomeContext context)
        {
            dbContext = context;
        }
        public IActionResult Index()
        {
            ViewBag.ExistingProducts = dbContext.Products.ToList();
            return View();
        }

        [HttpPost("products/new")]
        public IActionResult CreateProduct(Product newProduct)
        {
            if(ModelState.IsValid)
            {
                dbContext.Products.Add(newProduct);
                dbContext.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.ExistingProducts = dbContext.Products.ToList();
                return View("Index");
            }

        }

        [HttpGet("categories")]
        public IActionResult Categories()
        {
            ViewBag.ExistingCategories = dbContext.Categories.ToList();
            return View();
        }

        [HttpPost("categories/new")]
        public IActionResult CreateCategory(Category newCategory)
        {
            if(ModelState.IsValid)
            {
                dbContext.Categories.Add(newCategory);
                dbContext.SaveChanges();
                return RedirectToAction("Categories");
            }
            else
            {
                ViewBag.ExistingCategories = dbContext.Categories.ToList();
                return View("Categories");
            }

        }

        [HttpGet("products/{productId}")]
        public IActionResult ProductInfo(int productId)
        {
            Product dbProduct = dbContext.Products
                .Include(p => p.Categories).ThenInclude(a => a.Category)
                .FirstOrDefault(p => p.ProductId == productId);
            ViewBag.OnProduct = dbProduct.Categories.ToList();
            ViewBag.NotOnProduct = dbContext.Categories
                .Include(c => c.Products).Where(c => c.Products.All(a => a.ProductId!=productId))
                .ToList();
            ViewBag.Product = dbProduct;
            return View();
        }

        [HttpPost("products/{productId}/addcategory")]
        public IActionResult AddCategory(Association newAssociation, int productId)
        {
            dbContext.Associations.Add(newAssociation);
            dbContext.SaveChanges();
            return Redirect($"/products/{productId}");
        }

        [HttpGet("categories/{categoryId}")]
        public IActionResult CategoryInfo(int categoryId)
        {
            Category dbCategory = dbContext.Categories
                .Include(c => c.Products).ThenInclude(a => a.Product)
                .FirstOrDefault(c => c.CategoryId == categoryId);
            ViewBag.InCategory = dbCategory.Products.ToList();
            ViewBag.NotInCategory = dbContext.Products
                .Include(p => p.Categories).Where(p => p.Categories.All(a => a.CategoryId!=categoryId))
                .ToList();
            ViewBag.Category = dbCategory;
            return View();
        }

        [HttpPost("categories/{categoryId}/addproduct")]
        public IActionResult AddProduct(Association newAssociation, int categoryId)
        {
            dbContext.Associations.Add(newAssociation);
            dbContext.SaveChanges();
            return Redirect($"/categories/{categoryId}");
        }


















        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
