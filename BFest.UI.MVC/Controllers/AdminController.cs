using BFest.BLL.Abstract;
using BFest.Model;
using BFest.UI.MVC.CustomFilter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BFest.UI.MVC.Controllers
{
    public class AdminController : Controller
    {
        ISeasonService seasonService;
        IUserService userService;
        IFestivalService festivalService;
        ITicketService ticketService;
        public AdminController(IUserService UserService, IFestivalService festival, ITicketService TicketService, ISeasonService season)
        {
            userService = UserService;
            festivalService = festival;
            ticketService = TicketService;
            seasonService = season;
        }

        [CustomFilterAdmin]
        // GET: Home
        public ActionResult Index(int seasonID = 0)
        {
            ViewBag.Seasons = seasonService.GetAll();
            if (seasonID == 0)
            {
                return View(festivalService.GetAll());
            }

            else
            {
                return View(festivalService.GetFestivalsBySeasonID(seasonID));
            }

        }

        [HttpGet]
        public ActionResult Login()
        {
            if (Session["admin"] != null)
            {
                return RedirectToAction("Index");
            }
            return View();
        }


        [HttpPost]
        public ActionResult Login(User user)
        {
            var gelenKullanici = userService.GetAdminByLogin(user.Name, user.Password);
            if (gelenKullanici != null && gelenKullanici.Authority != false)
            {
                Session["admin"] = gelenKullanici;
                return RedirectToAction("Index", "Admin");
            }
            ViewBag.Error = "Admin bulunamadı!";
            return View();
        }

        public ActionResult Logout()
        {
            Session["admin"] = null;
            return RedirectToAction("Index", "Home");
        }


        [CustomFilterAdmin]
        public ActionResult ManageUsers()
        {
            return View(userService.GetAll());
        }

        [CustomFilterAdmin]
        public ActionResult Delete(int userID)
        {
            userService.DeleteByID(userID);
            return RedirectToAction("ManageUsers", "Admin");
        }

        [CustomFilterAdmin]
        public ActionResult Update(int UserID)
        {
            User updatedUser = userService.Get(UserID);
            return View(updatedUser);
        }

        [CustomFilterAdmin]
        [HttpPost]
        public ActionResult Update(User updatedUser)
        {
            if (updatedUser != null)
            {
                User Update = userService.Get(updatedUser.ID);

                Update.Name = updatedUser.Name;
                Update.Surname = updatedUser.Surname;
                Update.Email = updatedUser.Email;
                Update.Phone = updatedUser.Phone;
                Update.Authority = updatedUser.Authority;

                userService.Update(Update);
            }

            return RedirectToAction("ManageUsers", "Admin");
        }

        [CustomFilterAdmin]
        [HttpGet]
        public ActionResult AddFestival()
        {
            var AllSeasons = seasonService.GetAll();
            SelectList list = new SelectList(AllSeasons, "ID", "SeasonName");
            ViewBag.Seasons = list;

            return View();
        }

        [HttpPost]
        public ActionResult AddFestival(Festival festival)
        {
            if (string.IsNullOrEmpty(festival.Name))
            {
                ModelState.AddModelError("Name", "Name is required");
            }

            if (ModelState.IsValid)
            {
                festivalService.Insert(festival);
                return RedirectToAction("Index", "Admin");
            }
            else
            {
                return View();
            }

        }

        [CustomFilterAdmin]
        public ActionResult DeleteFestival(int festivalID)
        {
            festivalService.DeleteByID(festivalID);
            return RedirectToAction("Index", "Admin");
        }

        [CustomFilterAdmin]
        public ActionResult UpdateFestival(int festivalID)
        {
            var AllSeasons = seasonService.GetAll();
            SelectList list = new SelectList(AllSeasons, "ID", "SeasonName");
            ViewBag.Seasons = list;

            Festival updatedFestival = festivalService.Get(festivalID);
            return View(updatedFestival);
        }

        [CustomFilterAdmin]
        [HttpPost]
        public ActionResult UpdateFestival(Festival updatedFestival)
        {
            if (updatedFestival != null)
            {
                Festival Update = festivalService.Get(updatedFestival.ID);

                Update.Name = updatedFestival.Name;
                Update.Description = updatedFestival.Description;
                Update.SeasonID = updatedFestival.SeasonID;
                Update.StartDate = updatedFestival.StartDate;
                Update.EndDate = updatedFestival.EndDate;
                Update.Photo = updatedFestival.Photo;
                Update.AgeLimit = updatedFestival.AgeLimit;

                festivalService.Update(Update);
            }

            return RedirectToAction("Index", "Admin");
        }
    }
}