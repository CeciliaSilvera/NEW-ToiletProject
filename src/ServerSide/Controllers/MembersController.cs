using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using ToiletProject.Models.ViewModels;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace ToiletProject.Controllers
{
    public class MembersController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                client cl = new client();
                cl.SendMessage("1", "10.42.104.47", 8145);

                return View ("index");


            }
            else
                return View ("User not loged in...");

        }
        public IActionResult logout()
        {

            client cl = new client();
            cl.SendMessage("2", "10.42.104.47", 8145);
            return View();

            
                
        }
        
    }
    }
