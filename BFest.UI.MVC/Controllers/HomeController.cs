using BFest.BLL.Abstract;
using MusicStoreSites.UI.MVC.CustomFilter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BFest.UI.MVC.Controllers
{
    public class HomeController : Controller
    {
        ISeasonService seasonService;
        IFestivalService festivalService;

        public HomeController(ISeasonService season, IFestivalService festival)
        {
            seasonService = season;
            festivalService = festival;
        }

        // GET: Home
        public ActionResult Index(int seasonID = 0)
        {
            ViewBag.Seasons = seasonService.GetAll();
            if (seasonID == 0)
            {
                //It gets all festivals which will happen.
                return View(festivalService.GetAll());
            }
            else
            {
                //It gets all festivals according to seasonID.
                return View(festivalService.GetAll().Where(z => z.SeasonID == seasonID).ToList());
            }
        }

        public ActionResult AboutUs()
        {
            return View();
        }
        public ActionResult Contact()
        {
            return View();
        }
    }
}