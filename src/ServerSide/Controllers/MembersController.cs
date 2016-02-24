using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using ToiletProject.Models.ViewModels;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace ToiletProject.Controllers
{
    public class MembersController : Controller
    {
        UserManager<IdentityUser> _userManager;
        SignInManager<IdentityUser> _signInManager;
        IdentityDbContext _identityContext;

        public MembersController(
          UserManager<IdentityUser> userManager,
          SignInManager<IdentityUser> signInManager,
          IdentityDbContext dbContext)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _identityContext = dbContext;
        }

        // GET: /<controller>/

        client cl = new client();
        public IActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                cl.SendMessage("1", "10.42.105.46", 8145);

                return View ("index");


            }
            else
                return Content ("Wrong Ussername or Password");

        }
        public IActionResult logout()
        {

            _signInManager.SignOutAsync();
            cl.SendMessage("2", "10.42.105.46", 8145);
            return View();

            
                
        }
        
    }
    }
