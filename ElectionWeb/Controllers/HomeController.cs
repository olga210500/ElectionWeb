using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ElectionWeb.Models;

namespace ElectionWeb.Controllers
{
    public class HomeController : Controller
    {
        electionContext db = new electionContext();

        public ActionResult Index()
        {
            IEnumerable<Election>  elections= db.Election;
            IEnumerable<Nation> nations = db.Nation;
          

            ViewBag.Nation = nations;
            ViewBag.Election = elections;
           

            return View();
        }

        
        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
