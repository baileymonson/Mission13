using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Mission13.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Mission13.Controllers
{
    public class HomeController : Controller
    {


        private IBowlersRepository _repo { get; set; }
        //constructor
        public HomeController(IBowlersRepository temp)
        {
            _repo = temp;
        }
        // main page that prints out all of the bowlers

        public IActionResult Index()
        {
            var blah = _repo.Bowlers.ToList();
            return View(blah);
        }
        // add bowler
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var editbowler = _repo.Bowlers.FirstOrDefault(x => x.BowlerID == id);
            return View(editbowler);
        }
        [HttpPost]
        public IActionResult Edit(Bowler bowl)
        {
            if (ModelState.IsValid)
            {
                _repo.SaveBowler(bowl);

                var bowlers = _repo.Bowlers.ToList();

                return View("Index", bowlers);
            }
            else
            {
                var bowlers = _repo.Bowlers.FirstOrDefault(x => x.BowlerID == x.BowlerID);
                return View("Index");

            }
        }
        // delete bowler
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var bowlers = _repo.Bowlers.FirstOrDefault(x => x.BowlerID == id);
            return View(bowlers);
        }
        [HttpPost]
        public IActionResult Delete(Bowler bowl)
        {


            _repo.DeleteBowler(bowl);

            var blah = _repo.Bowlers.ToList();

            return View("Index", blah);
        }

        //adding a new bowler

        [HttpGet]
        public IActionResult BowlerForm()
        {
            return View();
        }

        [HttpPost]
        public IActionResult BowlerForm(Bowler bowl)
        {
            if (ModelState.IsValid)
            {
                _repo.CreateBowler(bowl);
                var bowler = _repo.Bowlers.ToList();
                bowl.BowlerID = _repo.Bowlers.Count() + 1;

                return View("Index", bowler);
            }
            else
            {
                bowl.BowlerID = _repo.Bowlers.Count() + 1;
                return View();
            }
        }

        // filtering
        public IActionResult Filters(string teamName)
        {
            var bowler = _repo.Bowlers
                .Include(x => x.Team)
                .Where(x => x.Team.TeamName == teamName || teamName == null)
                .ToList();

            ViewBag.Team = teamName;

            return View(bowler);

        }
    }
}
