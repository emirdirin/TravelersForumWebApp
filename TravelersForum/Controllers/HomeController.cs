using Microsoft.AspNetCore.Mvc;
using Homework1.Models;

namespace Homework1.Controllers{
    public class HomeController : Controller {
        public IActionResult Index(){
            int placeCount = Repository.Places.Count();
            ViewBag.NoP = placeCount;
           return View(Repository.Places);
        }
    }
}