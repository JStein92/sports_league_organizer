using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using SportsLeagueOrganizer.Models;

namespace SportsLeagueOrganizer.Controllers
{
	public class TeamController : Controller
	{
		private SportsLeagueOrganizerContext db = new SportsLeagueOrganizerContext();

		public IActionResult Create(int DivisionId)
		{
            var thisDivision = db.Divisions.FirstOrDefault(Division => Division.DivisionId == DivisionId);
            ViewBag.thisDivision = thisDivision;
            return View();
		}

		[HttpPost]
		public IActionResult Create(Team team)
		{
			db.Teams.Add(team);
			db.SaveChanges();
			return RedirectToAction("Index", "Division");
		}

        public IActionResult Details(int TeamId){
            var thisTeam = db.Teams.FirstOrDefault(Team => Team.TeamId == TeamId);
            ViewBag.Division = db.Divisions.FirstOrDefault(Division => Division.DivisionId == thisTeam.DivisionId); ;
            return View(thisTeam);
        }

		public IActionResult Delete(int TeamId)
		{
			var thisTeam = db.Teams.FirstOrDefault(Team => Team.TeamId == TeamId);
			return View(thisTeam);
		}

		[HttpPost, ActionName("Delete")]
		public IActionResult DeleteConfirmed(int TeamId)
		{
			var thisTeam = db.Teams.FirstOrDefault(Team => Team.TeamId == TeamId);
			ViewBag.Division = db.Divisions.FirstOrDefault(Division => Division.DivisionId == thisTeam.DivisionId); 
			db.Teams.Remove(thisTeam);
			db.SaveChanges();
            return RedirectToAction("Details", "Division",new {DivisionId = thisTeam.DivisionId});
		}

		public IActionResult Update(int TeamId)
		{
			var thisTeam = db.Teams.FirstOrDefault(Team => Team.TeamId == TeamId);
			return View(thisTeam);
		}

		[HttpPost]
		public IActionResult Update(Team team)
		{

			db.Entry(team).State = EntityState.Modified;
			db.SaveChanges();

            return RedirectToAction("Details", "Team", new {TeamId = team.TeamId});
		}

	}
}