using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Web;

namespace ElectionWeb.Controllers
{
    public class VotingController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        electionContext db = new electionContext();
        public IActionResult Tour()
        {
            IEnumerable<Election> elections = db.Election;
            ViewBag.Election = elections;

            return View();
        }
        public IActionResult Voting()
        {
            IEnumerable<Election> elections = db.Election;
            IEnumerable<Nation> nations = db.Nation;


            ViewBag.Nation = nations;
            ViewBag.Election = elections;

            IEnumerable<Candidate> candidates = db.Candidate;
            IEnumerable<Person> people = db.Person;
            ViewBag.Person = people;
            ViewBag.Candidate = candidates;
            
            //int st= Request.Form["tech"];
            //string selectedGender = Request.Form["tech"].ToString();
            
            return View();
        }
        [HttpPost]
        public ActionResult Vote(string tech)
        {
            
            return View();
        }
        [HttpGet]
        public ActionResult TyForVoting(int tech)
        {
            //ТУТ КРЧ ЗАкоМЕНТОВАНЕ ДОДАВАННЯ В БД
            //АЙДІ І СІТІ АЙДІ ТРЕБА БРАТИ ВІД АККАУНТА ПІД ЯКИМ ТИ ЗАЙШОВ
            

            //Bulletin bulletin = new Bulletin();
            //bulletin.Id = 99; //
            //bulletin.CityId = 7; //  має бути реєстрація для того щоб отримати ці дані
            //bulletin.ElectionId = 1; 
            //bulletin.CandidateId = tech;
            //db.Add(bulletin);
            //db.SaveChanges();
            

            return View();
        }
       
    }

}