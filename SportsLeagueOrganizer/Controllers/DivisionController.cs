using Microsoft.AspNetCore.Mvc;
using SportsLeagueOrganizer.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace SportsLeagueOrganizer.Controllers
{
	public class DivisionController : Controller
	{
        private SportsLeagueOrganizerContext db = new SportsLeagueOrganizerContext();

		public IActionResult Index()
        {
            ViewBag.AllDivisions = db.Divisions.ToList();
			return View();
		}

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Division division)
        {
            db.Divisions.Add((division));
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int DivisionId)
        {
            var thisDivision = db.Divisions.FirstOrDefault(Division => Division.DivisionId == DivisionId);
            return View(thisDivision);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int DivisionId)
        {
            var thisDivision = db.Divisions.FirstOrDefault(Division => Division.DivisionId == DivisionId);
            db.Divisions.Remove(thisDivision);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Details(int DivisionId)
        {
			var thisDivision = db.Divisions
				   .Include(x => x.Teams)
				   .FirstOrDefault(x => x.DivisionId == DivisionId);

            return View(thisDivision);
        }

        public IActionResult Update(int DivisionId)
        {
            var thisDivision = db.Divisions.FirstOrDefault((Division => Division.DivisionId == DivisionId));
            return View(thisDivision);
        }

        [HttpPost]
        public IActionResult Update(Division division)
        {

            db.Entry(division).State = EntityState.Modified;
            db.SaveChanges();

			return RedirectToAction("Index");
        }
        
	}
}