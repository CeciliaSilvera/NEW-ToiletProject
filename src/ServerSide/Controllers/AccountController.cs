using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using ToiletProject.Models.ViewModels;
using Microsoft.AspNet.Authorization;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace ToiletProject.Controllers
{
    public class AccountController : Controller
    {
        UserManager<IdentityUser> _userManager;
        SignInManager<IdentityUser> _signInManager;
        IdentityDbContext _identityContext;

        public AccountController(
          UserManager<IdentityUser> userManager,
          SignInManager<IdentityUser> signInManager,
          IdentityDbContext dbContext)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _identityContext = dbContext;
        }
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            

            if (!ModelState.IsValid)
                return View(model);

            await _identityContext.Database.EnsureCreatedAsync();
            var result = await _userManager.CreateAsync(new IdentityUser(model.UserName), model.Password);
            if(!result.Succeeded)
            {
                ModelState.AddModelError("UserName", result.Errors.First().Description);
                return View(model);
            }
                
            return RedirectToAction("login");




            


        }
        [AllowAnonymous]
        public IActionResult Login()
        {
            if (User.Identity.Name != null)
                return RedirectToAction(nameof(MembersController.Index), "Members");

            return View();
        }
        [AllowAnonymous]
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Login(LoginViewModel viewModel)
        {
            if (!ModelState.IsValid)
                return View(viewModel);


            await _signInManager.PasswordSignInAsync(viewModel.UserName, viewModel.Password, false, false);
            return RedirectToAction(nameof(MembersController.Index), "Members");
            

        }
    }
}
