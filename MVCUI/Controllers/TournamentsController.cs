using MVCUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using TrackerLibrary;
using TrackerLibrary.Models;

namespace MVCUI.Controllers
{
    public class TournamentsController : Controller
    {
        // GET: Tournaments
        public ActionResult Index()
        {
            return RedirectToAction("Index", "Home");
        }

        public ActionResult Create()
        {
            TournamentMVCModel model = new TournamentMVCModel();
            List<TeamModel> allTeams = GlobalConfig.Connection.GetTeam_All();
            List<PrizeModel> allPrizes = GlobalConfig.Connection.GetPrizes_All();

            model.EnteredTeams = allTeams.Select(x => new SelectListItem { Text = x.TeamName, Value = x.Id.ToString() }).ToList();
            model.EnteredTeams = allPrizes.Select(x => new SelectListItem { Text = x.PlaceName, Value = x.Id.ToString() }).ToList();

            return View(model);
        }

        // POST: Tournament/Create
        [ValidateAntiForgeryToken()]
        [HttpPost]
        public ActionResult Create(TournamentMVCModel model)
        {
            try
            {
                if (ModelState.IsValid && model.SelectedEnteredTeams.Count > 0)
                {
                    TournamentModel t = new TournamentModel();
                    t.TournamentName = model.TournamentName;
                    t.EntryFee = model.EntryFee;
                    t.EnteredTeams = model.SelectedEnteredTeams.Select(x => new TeamModel { Id = int.Parse(x) }).ToList();
                    t.Prizes = model.SelectedPrizes.Select(x => new PrizeModel { Id = int.Parse(x) }).ToList();

                    TournamentLogic.CreateRounds(t);

                    GlobalConfig.Connection.CreateTournament(t);
                    return RedirectToAction("Index","Home");
                }
                else
                {
                    return RedirectToAction("Create");
                }
            }
            catch
            {
                return View();
            }
        }

    }
}