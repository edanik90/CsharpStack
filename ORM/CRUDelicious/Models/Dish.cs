using System;
using System.ComponentModel.DataAnnotations;

namespace CRUDelicious.Models
{
    public class Dish
    {
        [Key]
        public int DishId {get;set;}
        [Required(ErrorMessage = "Name is required")]
        [MinLength(3, ErrorMessage = "Name must be at least 3 characters")]
        public string Name {get;set;}

        [Required(ErrorMessage = "Chef is required")]
        [MinLength(3, ErrorMessage = "Chef's name must be at least 3 characters")]
        public string Chef {get;set;}
        [Required(ErrorMessage = "Tastiness is required")]
        [Range(1,5,ErrorMessage = "Tastiness must be between 1 and 5")]
        public int Tastiness {get;set;}

        [Required(ErrorMessage = "Calories required")]
        [Range(0,1000000,ErrorMessage = "Calories cannot have negative value")]
        public int Calories {get;set;}

        [Required(ErrorMessage = "Description is required")]
        public string Description {get;set;}
        public DateTime CreatedAt {get;set;} = DateTime.Now;
        public DateTime UpdatedAt {get;set;} = DateTime.Now;
    }
}

