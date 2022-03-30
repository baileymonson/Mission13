using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Mission13.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission13.Components
{
    // view component for the filter searching 
    public class TeamsViewComponent : ViewComponent
    {
        private IBowlersRepository repo;

        public TeamsViewComponent(IBowlersRepository temp)
        {
            repo = temp;
        }

        public IViewComponentResult Invoke()
        {
            ViewBag.SelectedTeam = RouteData?.Values["teamName"];

            // doucle check and ask if you need have both 'include' and 'select'
            var teams = repo.Bowlers
                .Include(x => x.Team)
                .Select(x => x.Team)
                .Distinct()
                .OrderBy(x => x)
                .ToList();


            return View(teams);
        }
    }
}
