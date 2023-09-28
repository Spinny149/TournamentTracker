using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TrackerLibrary;
using TrackerLibrary.Models;

namespace MVCUI.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            List<TournamentModel> tournaments = GlobalConfig.Connection.GetTournament_All();

            return View(tournaments);
        }      
    }
}