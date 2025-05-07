using Microsoft.AspNetCore.Mvc;

namespace Homework1.Controllers
{
    public class ContactController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SubmitComplaint(string Name, string Email, string Subject, string Message)
        {
            if(ModelState.IsValid){
            return View("Thanks");
            }
            else{
                return View("Index");
            }
        }
                public IActionResult Thanks(){
            return View();
        }

    }
}