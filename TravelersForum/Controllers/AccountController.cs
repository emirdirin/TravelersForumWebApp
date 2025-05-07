using System.Net.Http.Headers;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Homework1.Models;
using Homework1.ViewModels;

public class AccountController : Controller{
    private readonly SignInManager<IdentityUser> _signInManager;
    private readonly UserManager<IdentityUser> _userManager;

    public AccountController(SignInManager<IdentityUser> signInManager, UserManager<IdentityUser> userManager){
        _signInManager = signInManager;
        _userManager = userManager;
    }

    [HttpGet]
    public IActionResult Login(){
        
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Login(LoginViewModel model){
        if (ModelState.IsValid){
            var user = await _userManager.FindByNameAsync(model.UserName);

            if (user != null){
                var result = await _signInManager.PasswordSignInAsync(user, model.Password, false, false);

               if (result.Succeeded){

                    return RedirectToAction("Index", "Home"); // return the homepage after successful login
                }
                else{
                    ModelState.AddModelError(string.Empty, "Try again.");
                }
            }
            else{
                ModelState.AddModelError(string.Empty, "Try again.");
            }
        }

        return View(model); 
    }


    [HttpPost]
    public async Task<IActionResult> Logout(){
        await _signInManager.SignOutAsync();
        return RedirectToAction("Login", "Account");
    }


    [HttpGet]
    public IActionResult Register()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Register(RegisterViewModel model)
    {
        if (ModelState.IsValid){
            var user = new IdentityUser
            {
                UserName = model.UserName,
                Email = model.Email
            }; 

            var result = await _userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(user, "User");
                
                return View("Thanks"); // after successful registration, open Thanks page
            }

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }
        }

        return View(model);
    }
}