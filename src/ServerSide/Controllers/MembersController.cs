using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using ToiletProject.Models.ViewModels;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.IO;


// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace ToiletProject.Controllers
{

    public class MembersController : Controller
    {
           
        string path = "C:\\Users\\Alexander\\Desktop\\Toilet-Github\\";
        string filename = "qNumber.txt";

        int qNumber;

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
                
                    cl.SendMessage("1", User.Identity.Name, "10.42.104.192", 8145);

                    

                List<String> list = System.IO.File.ReadLines(path + filename).ToList();
                {

                    foreach (string item in list)
                    {

                        qNumber = Int32.Parse(item);
                    }

                }
                if (qNumber > 0)
                {
 
                    return RedirectToAction("queue");
                }
                else
                    return View("index");

            }
            else
                return Content ("Wrong Ussername or Password");
            

          




        }
        public IActionResult queue()
        {
            List<String> list = System.IO.File.ReadLines(path + filename).ToList();
            {

                foreach (string item in list)
                {

                    qNumber = Int32.Parse(item);
                }

            }
            ViewData["Queue"] = qNumber;
            return View(ViewData["Queue"]);
            
        }


        [HttpPost]
        public IActionResult retry()
        {
            return RedirectToAction(nameof(AccountController.Login), "Account");

        }


        public IActionResult logout()
        {

            _signInManager.SignOutAsync();
            cl.SendMessage("2", User.Identity.Name, "10.42.104.192", 8145);
            return View();

            
                
            }
        
    }
    }
