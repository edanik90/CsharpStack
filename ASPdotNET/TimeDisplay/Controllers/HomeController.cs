using Microsoft.AspNetCore.Mvc;
namespace TimeDisplay
{
    public class HomeController : Controller
    {
        [HttpGet("")]

        public ViewResult Index()
        {
            return View();
        }
    }
}