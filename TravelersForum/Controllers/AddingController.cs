using Microsoft.AspNetCore.Mvc;
using Homework1.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace Homework1.Controllers{
	
	public class AddingController : Controller {
        [Authorize]
        [HttpGet]
        public IActionResult Index(){
            
           return View();
        }
        
        
        [HttpPost]
        
         public IActionResult Index(Place model){
            if (!User.Identity.IsAuthenticated)
            {
                 return RedirectToAction("Login", "Account");
             }

            
            if(ModelState.IsValid){
            Repository.createPlace(model);
            model.submissionDate=DateTime.Now;
            return View("Thanks", model);
            }
            else{
                return View("Index", model);
            }
        }
        public IActionResult List(int page=1,int pageSize = 5){
            
            var _Places =Repository.Places.ToList();
            var paginatedPlaces = PaginatedList<Place>.Create(_Places, page, pageSize);
            
            ViewBag.CurrentPage = page;
            ViewBag.TotalPages = paginatedPlaces.TotalPages;
            ViewBag.NoP2 = _Places.Count();

            return View(paginatedPlaces);

            /*int placeCount = Repository.Places.Count();
            ViewBag.NoP2 = placeCount;
            return View(model: Repository.Places);  */      
        }
        public IActionResult Thanks(){
            return View();
        }
        public IActionResult Details(int id){
            return View(Repository.getById(id));
        }

        
    }
}