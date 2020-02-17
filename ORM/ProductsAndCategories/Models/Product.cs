using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProductsAndCategories.Models
{
    public class Product
    {
        [Key]
        public int ProductId {get;set;}

        [Required(ErrorMessage="Product name is required")]
        [MinLength(3, ErrorMessage="Product name must be at least 3 characters")]
        public string Name {get;set;}

        [MinLength(10, ErrorMessage="Description must be at least 10 characters")]
        public string Description {get;set;}

        [Range(0,100000000, ErrorMessage="Price cannot be negative")]
        public double Price {get;set;}
        public List<Association> Categories {get;set;}

        public DateTime CreatedAt {get;set;} = DateTime.Now;
        public DateTime UpdatedAt {get;set;} = DateTime.Now;
    }
}