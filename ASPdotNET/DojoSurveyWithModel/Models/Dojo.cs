using System.ComponentModel.DataAnnotations;
namespace DojoSurveyWithModel.Models
{
    public class Dojo
    {
        [Required(ErrorMessage = "Name is required")]
        [MinLength(2, ErrorMessage = "Name should be at least 2 characters long.")]
        public string Name {get;set;}

        [Required(ErrorMessage = "Location is required")]
        public string Location {get;set;}

        [Required(ErrorMessage = "Language is required")]
        public string Language {get;set;}

        [MaxLength(20, ErrorMessage = "Comment cannot be more than 20 characters")]
        public string Comment {get;set;}
    }
}