using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProductsAndCategories.Models
{
    public class Category
    {
        [Key]
        public int CategoryId {get;set;}

        [Required(ErrorMessage = "Category name is required")]
        [MinLength(3, ErrorMessage = "Category name must be at least 3 characters")]
        public string Name {get;set;}
        public List<Association> Products {get;set;}
        public DateTime CreatedAt {get;set;} = DateTime.Now;
        public DateTime UpdatedAt {get;set;} = DateTime.Now;
    }
}