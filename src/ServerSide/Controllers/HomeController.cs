using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Authorization;
using ToiletProject.Models.ViewModels;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace ToiletProject.Controllers
{
    public class HomeController : Controller
    {
        
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }
        

    }
}
