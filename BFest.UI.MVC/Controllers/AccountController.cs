using BFest.BLL.Abstract;
using BFest.Model;
using BFest.UI.MVC.Tools;
using MusicStoreSites.UI.MVC.CustomFilter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;

namespace BFest.UI.MVC.Controllers
{
    public class AccountController : Controller
    {
        IUserService userService;
        IFestivalService festivalService;
        ITicketService ticketService;
        IEvaluationService evaluationService;

        public AccountController(IUserService UserService, IFestivalService festival, ITicketService TicketService, IEvaluationService evaluation)
        {
            userService = UserService;
            festivalService = festival;
            ticketService = TicketService;
            evaluationService = evaluation;

        }
        // GET: Account
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(User user)
        {


            #region name

            #region nameCheck
            //This region checks whether or not name is entered.
            if (string.IsNullOrEmpty(user.Name))
            {
                ModelState.AddModelError("Name", "Name is required");
            }
            #endregion

            #region nameLength
            // This region checks length of the name.
            if (user.Name.Length < 2)
            {
                ModelState.AddModelError("Name", "Name should have minimum two characters.");
            }
            #endregion

            #region numberOfSymbols
            // This region checks how many symbols are took part in name.
            //These symbols are "!'^%&()=?_#${[]}+-*/.,:;<>|~@;
            int symbolLengthInName = 0;

            foreach (char item in user.Name)
            {
                if (char.IsSymbol(item))
                {
                    symbolLengthInName++;
                }
            }

            if (symbolLengthInName > 1)
            {
                ModelState.AddModelError("Name", "Name cannot contain any symbol.");
            }
            #endregion

            #region numberOfNumbers
            // This region checks how many numbers are took part in name.
            int numberLengthInName = 0;

            foreach (char item in user.Name)
            {
                if (char.IsNumber(item))
                {
                    numberLengthInName = numberLengthInName + 1;
                }
            }

            if (numberLengthInName > 1)
            {
                ModelState.AddModelError("Name", "Name cannot contain any number.");
            }
            #endregion

            #endregion

            #region surname

            #region surnameCheck
            //This region checks whether or not surname is entered.
            if (string.IsNullOrEmpty(user.Surname))
            {
                ModelState.AddModelError("Surname", "Surname is required");
            }
            #endregion

            #region surnameLength
            // This region checks length of the surname.
            if (user.Surname.Length < 2)
            {
                ModelState.AddModelError("Surname", "Surname should have minimum two characters.");
            }
            #endregion

            #region numberOfSymbols
            // This region checks how many symbols are took part in surname.
            //These symbols are "!'^%&()=?_#${[]}+-*/.,:;<>|~@;
            int symbolLengthInSurname = 0;

            foreach (char item in user.Surname)
            {
                if (char.IsSymbol(item))
                {
                    symbolLengthInSurname++;
                }
            }

            if (symbolLengthInSurname > 1)
            {
                ModelState.AddModelError("Surname", "Surname cannot contain any symbol.");
            }
            #endregion

            #region numberOfNumbers
            // This region checks how many numbers are took part in surname.
            int numberLengthInSurname = 0;

            foreach (char item in user.Surname)
            {
                if (char.IsNumber(item))
                {
                    numberLengthInSurname = numberLengthInSurname + 1;
                }
            }

            if (numberLengthInSurname > 1)
            {
                ModelState.AddModelError("Surname", "Surname cannot contain any number.");
            }
            #endregion

            #endregion

            #region password

            #region passwordCheck
            //This region checks whether or not password is entered.
            if (string.IsNullOrEmpty(user.Password))
            {
                ModelState.AddModelError("Password", "Password is required");
            }
            #endregion

            #region passwordLength
            // This region checks length of the password.
            bool k;
            if ((k = user.Password.Length < 6) || user.Password.Length > 14)
            {
                if (k)
                {
                    ModelState.AddModelError("Password", "Password should have minimum six characters.");
                }
                else
                {
                    ModelState.AddModelError("Password", "Password should have maximum fourteen characters.");
                }
            }
            #endregion

            #region numberOfLetters
            // This region checks how many letters are took part in password.
            string allLetters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            int letterLength = 0;

            foreach (char item in user.Password)
            {
                if (allLetters.Contains(char.ToUpper(item)))
                {
                    letterLength += 1;
                }
            }

            if (letterLength < 3)
            {
                ModelState.AddModelError("Password", "Password should have minimum three letters.");
            }
            #endregion

            #region numberOfSymbols
            // This region checks how many symbols are took part in password.
            //These symbols are "!'^%&()=?_#${[]}+-*/.,:;<>|~@;
            //int symbolLengthInPassword = 0;

            //foreach (char item in user.Password)
            //{
            //    if (char.IsSymbol(item))
            //    {
            //        symbolLengthInPassword++;
            //    }
            //}

            //if (symbolLengthInPassword < 1)
            //{
            //    ModelState.AddModelError("Password", "Password should have minimum one symbol.");
            //}
            #endregion

            #region numberOfNumbers
            // This region checks how many numbers are took part in password.
            int numberLengthInPassword = 0;

            foreach (char item in user.Password)
            {
                if (char.IsNumber(item))
                {
                    numberLengthInPassword = numberLengthInPassword + 1;
                }
            }

            if (numberLengthInPassword < 2)
            {
                ModelState.AddModelError("Password", "Password should have minimum two numbers.");
            }
            #endregion

            #endregion

            #region phone

            #region phoneCheck
            //This region checks whether or not phone is entered.
            if (string.IsNullOrEmpty(user.Phone))
            {
                ModelState.AddModelError("Phone", "Phone is required");
            }
            #endregion

            #region phoneLength
            // This region checks length of the phone.
            if (user.Phone.Length != 11)
            {
                ModelState.AddModelError("Phone", "Phone should consist of eleven numbers.");
            }
            #endregion

            #region phoneStart

            if (user.Phone.Substring(0, 1) != "0")
            {
                ModelState.AddModelError("Phone", "Phone should start with zero.");
            }

            #endregion

            #region numberOfLetters
            // This region checks how many letters are took part in phone.

            int letterLengthInPhone = 0;

            foreach (char item in user.Phone)
            {
                if (allLetters.Contains(char.ToUpper(item)))
                {
                    letterLengthInPhone += 1;
                }
            }

            if (letterLengthInPhone > 1)
            {
                ModelState.AddModelError("Phone", "Phone cannot contain any letter.");
            }
            #endregion

            #region numberOfSymbols
            // This region checks how many symbols are took part in phone.
            //These symbols are "!'^%&()=?_#${[]}+-*/.,:;<>|~@;
            int symbolLengthInPhone = 0;

            foreach (char item in user.Phone)
            {
                if (char.IsSymbol(item))
                {
                    symbolLengthInPhone++;
                }
            }

            if (symbolLengthInPhone > 1)
            {
                ModelState.AddModelError("Phone", "Phone cannot contain any symbol.");
            }
            #endregion

            #endregion

            #region IDnumber

            #region IDnumberCheck
            //This region checks whether or not ID number is entered.
            if (string.IsNullOrEmpty(user.TCNo))
            {
                ModelState.AddModelError("TCNo", "ID number is required");
            }
            #endregion

            #region IDnumberStart

            if (user.TCNo.Substring(0, 1) == "0")
            {
                ModelState.AddModelError("TCNo", "ID number should not start with zero.");
            }

            #endregion

            #region numberOfLetters
            // This region checks how many letters are took part in ID number.

            int letterLengthInID = 0;

            foreach (char item in user.TCNo)
            {
                if (allLetters.Contains(char.ToUpper(item)))
                {
                    letterLengthInID += 1;
                }
            }

            if (letterLengthInID > 1)
            {
                ModelState.AddModelError("TCNo", "ID number cannot contain any letter.");
            }
            #endregion

            #region numberOfSymbols
            // This region checks how many symbols are took part in ID number.
            //These symbols are "!'^%&()=?_#${[]}+-*/.,:;<>|~@;
            int symbolLengthInID = 0;

            foreach (char item in user.TCNo)
            {
                if (char.IsSymbol(item))
                {
                    symbolLengthInID++;
                }
            }

            if (symbolLengthInID > 0)
            {
                ModelState.AddModelError("TCNo", "ID number cannot contain any symbol.");
            }
            #endregion

            #region IDnumberLength
            // This region checks length of the ID number.
            if (user.TCNo.Length != 11)
            {
                ModelState.AddModelError("TCNo", "ID number consists of eleven numbers.");
            }
            #endregion

            #endregion

            #region email

            #region emailCheck
            //This region checks whether or not email is entered.
            if (string.IsNullOrEmpty(user.Email))
            {
                ModelState.AddModelError("Email", "Email is required");
            }
            else
            {
                //And this section checks whether or not email is in correct format.
                if (!Regex.IsMatch(user.Email, @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$"))
                {
                    ModelState.AddModelError("Email", "Email address is not in correct format.");
                }
            }
            #endregion            

            #region emailCheck
            User checkUser = userService.GetUserByEmail(user.Email);

            if (checkUser != null)
            {
                ModelState.AddModelError("Email", "Email address already exits.");
            }

            #endregion

            #endregion

            #region birthdate

            #region birthdateCheck
            //This region checks whether or not birthdate is entered.
            if (string.IsNullOrEmpty(user.BirthDate.ToString()))
            {
                ModelState.AddModelError("BirthDate", "Birthdate is required");
            }
            else
            {
                //And this section checks whether or not user age is higher or equal than eightteen.
                if (DateTime.Now.Year - user.BirthDate.Year < 18)
                {
                    ModelState.AddModelError("BirthDate", "User age cannot be less than eightteen.");
                }
            }
            #endregion

            #endregion


            if (ModelState.IsValid)
            {
                userService.Insert(user);
                bool sonuc = MailIcin.SendConfirmationMail(user.Name, user.Password, user.Email, user.ID);
                if (!sonuc)
                {
                    return View();
                }
                return RedirectToAction("Login", "Account");
            }

            else
            {
                return View();
            }

        }

        [HttpGet]
        public ActionResult Login()
        {
            if (Session["kullanici"] != null)
            {
                return RedirectToAction("Index", "Home");
            }

            return View();
        }


        [HttpPost]
        public ActionResult Login(User user)
        {
            var gelenKullanici = userService.GetUserByLogin(user.Name, user.Password);
            if (gelenKullanici != null)
            {
                Session["kullanici"] = gelenKullanici;

                return RedirectToAction("Index", "Home");
            }
            ViewBag.Error = "Kullanıcı bulunamadı";
            return View();
        }


        //public ActionResult Comments()
        //{


        //}


        public ActionResult Comment(int festivalID)
        {

            return PartialView(festivalService.Get(festivalID));
        }

        public ActionResult FestivalDetail(int festivalID)
        {
            ViewBag.Comments = evaluationService.GetAll().Where(x => x.FestivalID == festivalID);
            return View(festivalService.Get(festivalID));

        }

        public ActionResult ForgotPassword()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ForgotPassword(string email)
        {
            User kullanici = userService.GetUserByEmail(email);

            int yeni;
            bool sonuc = MailHelper.SendConfirmationMail(email, out yeni);

            kullanici.Password = yeni.ToString();
            userService.Update(kullanici);

            return RedirectToAction("Index", "Home");
        }

        [CustomFilter]
        public ActionResult UserUpdateInformation()
        {
            User kullaniciGetir = Session["kullanici"] as User;

            return View(kullaniciGetir);
        }

        [HttpPost]
        public ActionResult UserUpdateInformation(User user)
        {

            #region name

            #region nameCheck
            //This region checks whether or not name is entered.
            if (string.IsNullOrEmpty(user.Name))
            {
                ModelState.AddModelError("Name", "Name is required");
            }
            #endregion

            #region nameLength
            // This region checks length of the name.
            if (user.Name.Length < 2)
            {
                ModelState.AddModelError("Name", "Name should have minimum two characters.");
            }
            #endregion

            #region numberOfSymbols
            // This region checks how many symbols are took part in name.
            //These symbols are "!'^%&()=?_#${[]}+-*/.,:;<>|~@;
            int symbolLengthInName = 0;

            foreach (char item in user.Name)
            {
                if (char.IsSymbol(item))
                {
                    symbolLengthInName++;
                }
            }

            if (symbolLengthInName > 1)
            {
                ModelState.AddModelError("Name", "Name cannot contain any symbol.");
            }
            #endregion

            #region numberOfNumbers
            // This region checks how many numbers are took part in name.
            int numberLengthInName = 0;

            foreach (char item in user.Name)
            {
                if (char.IsNumber(item))
                {
                    numberLengthInName = numberLengthInName + 1;
                }
            }

            if (numberLengthInName > 1)
            {
                ModelState.AddModelError("Name", "Name cannot contain any number.");
            }
            #endregion

            #endregion

            #region surname

            #region surnameCheck
            //This region checks whether or not surname is entered.
            if (string.IsNullOrEmpty(user.Surname))
            {
                ModelState.AddModelError("Surname", "Surname is required");
            }
            #endregion

            #region surnameLength
            // This region checks length of the surname.
            if (user.Surname.Length < 2)
            {
                ModelState.AddModelError("Surname", "Surname should have minimum two characters.");
            }
            #endregion

            #region numberOfSymbols
            // This region checks how many symbols are took part in surname.
            //These symbols are "!'^%&()=?_#${[]}+-*/.,:;<>|~@;
            int symbolLengthInSurname = 0;

            foreach (char item in user.Surname)
            {
                if (char.IsSymbol(item))
                {
                    symbolLengthInSurname++;
                }
            }

            if (symbolLengthInSurname > 1)
            {
                ModelState.AddModelError("Surname", "Surname cannot contain any symbol.");
            }
            #endregion

            #region numberOfNumbers
            // This region checks how many numbers are took part in surname.
            int numberLengthInSurname = 0;

            foreach (char item in user.Surname)
            {
                if (char.IsNumber(item))
                {
                    numberLengthInSurname = numberLengthInSurname + 1;
                }
            }

            if (numberLengthInSurname > 1)
            {
                ModelState.AddModelError("Surname", "Surname cannot contain any number.");
            }
            #endregion

            #endregion

            #region password

            #region passwordCheck
            //This region checks whether or not password is entered.
            if (string.IsNullOrEmpty(user.Password))
            {
                ModelState.AddModelError("Password", "Password is required");
            }
            #endregion

            #region passwordLength
            // This region checks length of the password.
            bool k;
            if ((k = user.Password.Length < 6) || user.Password.Length > 14)
            {
                if (k)
                {
                    ModelState.AddModelError("Password", "Password should have minimum six characters.");
                }
                else
                {
                    ModelState.AddModelError("Password", "Password should have maximum fourteen characters.");
                }
            }
            #endregion

            #region numberOfLetters
            // This region checks how many letters are took part in password.
            string allLetters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            int letterLength = 0;

            foreach (char item in user.Password)
            {
                if (allLetters.Contains(char.ToUpper(item)))
                {
                    letterLength += 1;
                }
            }

            if (letterLength < 3)
            {
                ModelState.AddModelError("Password", "Password should have minimum three letters.");
            }
            #endregion

            #region numberOfSymbols
            // This region checks how many symbols are took part in password.
            //These symbols are "!'^%&()=?_#${[]}+-*/.,:;<>|~@;
            //int symbolLengthInPassword = 0;

            //foreach (char item in user.Password)
            //{
            //    if (char.IsSymbol(item))
            //    {
            //        symbolLengthInPassword++;
            //    }
            //}

            //if (symbolLengthInPassword < 1)
            //{
            //    ModelState.AddModelError("Password", "Password should have minimum one symbol.");
            //}
            #endregion

            #region numberOfNumbers
            // This region checks how many numbers are took part in password.
            int numberLengthInPassword = 0;

            foreach (char item in user.Password)
            {
                if (char.IsNumber(item))
                {
                    numberLengthInPassword = numberLengthInPassword + 1;
                }
            }

            if (numberLengthInPassword < 2)
            {
                ModelState.AddModelError("Password", "Password should have minimum two numbers.");
            }
            #endregion

            #endregion

            #region phone

            #region phoneCheck
            //This region checks whether or not phone is entered.
            if (string.IsNullOrEmpty(user.Phone))
            {
                ModelState.AddModelError("Phone", "Phone is required");
            }
            #endregion

            #region phoneLength
            // This region checks length of the phone.
            if (user.Phone.Length != 11)
            {
                ModelState.AddModelError("Phone", "Phone should consist of eleven numbers.");
            }
            #endregion

            #region phoneStart

            if (user.Phone.Substring(0, 1) != "0")
            {
                ModelState.AddModelError("Phone", "Phone should start with zero.");
            }

            #endregion

            #region numberOfLetters
            // This region checks how many letters are took part in phone.

            int letterLengthInPhone = 0;

            foreach (char item in user.Phone)
            {
                if (allLetters.Contains(char.ToUpper(item)))
                {
                    letterLengthInPhone += 1;
                }
            }

            if (letterLengthInPhone > 1)
            {
                ModelState.AddModelError("Phone", "Phone cannot contain any letter.");
            }
            #endregion

            #region numberOfSymbols
            // This region checks how many symbols are took part in phone.
            //These symbols are "!'^%&()=?_#${[]}+-*/.,:;<>|~@;
            int symbolLengthInPhone = 0;

            foreach (char item in user.Phone)
            {
                if (char.IsSymbol(item))
                {
                    symbolLengthInPhone++;
                }
            }

            if (symbolLengthInPhone > 1)
            {
                ModelState.AddModelError("Phone", "Phone cannot contain any symbol.");
            }
            #endregion

            #endregion

            #region IDnumber

            #region IDnumberCheck
            //This region checks whether or not ID number is entered.
            if (string.IsNullOrEmpty(user.TCNo))
            {
                ModelState.AddModelError("TCNo", "ID number is required");
            }
            #endregion

            #region IDnumberStart

            if (user.TCNo.Substring(0, 1) == "0")
            {
                ModelState.AddModelError("TCNo", "ID number should not start with zero.");
            }

            #endregion

            #region numberOfLetters
            // This region checks how many letters are took part in ID number.

            int letterLengthInID = 0;

            foreach (char item in user.TCNo)
            {
                if (allLetters.Contains(char.ToUpper(item)))
                {
                    letterLengthInID += 1;
                }
            }

            if (letterLengthInID > 0)
            {
                ModelState.AddModelError("TCNo", "ID number cannot contain any letter.");
            }
            #endregion

            #region numberOfSymbols
            // This region checks how many symbols are took part in ID number.
            //These symbols are "!'^%&()=?_#${[]}+-*/.,:;<>|~@;
            int symbolLengthInID = 0;

            foreach (char item in user.TCNo)
            {
                if (char.IsSymbol(item))
                {
                    symbolLengthInID++;
                }
            }

            if (symbolLengthInID > 0)
            {
                ModelState.AddModelError("TCNo", "ID number cannot contain any symbol.");
            }
            #endregion

            #region IDnumberLength
            // This region checks length of the ID number.
            if (user.TCNo.Length != 11)
            {
                ModelState.AddModelError("TCNo", "ID number consists of eleven numbers.");
            }
            #endregion

            #endregion

            #region email

            #region emailCheck
            //This region checks whether or not email is entered.
            if (string.IsNullOrEmpty(user.Email))
            {
                ModelState.AddModelError("Email", "Email is required");
            }
            else
            {
                //And this section checks whether or not email is in correct format.
                if (!Regex.IsMatch(user.Email, @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$"))
                {
                    ModelState.AddModelError("Email", "Email address is not in correct format.");
                }
            }
            #endregion            

            #region emailCheck
            User sessionUser = Session["kullanici"] as User;
            if (sessionUser.Email != user.Email)
            {
                User checkUser = userService.GetUserByEmail(user.Email);

                if (checkUser != null)
                {
                    ModelState.AddModelError("Email", "Email address already exits.");
                }
            }

            #endregion

            #endregion

            if (ModelState.IsValid)
            {
                User updateUser = userService.Get(user.ID);

                updateUser.TCNo = user.TCNo;
                updateUser.Name = user.Name;
                updateUser.Surname = user.Surname;
                updateUser.Email = user.Email;
                updateUser.Password = user.Password;
                updateUser.Phone = user.Phone;

                userService.Update(updateUser);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View();
            }
        }

        public ActionResult PostComment(string comment, int festivalID)
        {
            User user = Session["kullanici"] as User;
            Evaluation newComment = new Evaluation();

            newComment.Comment = comment;
            newComment.FestivalID = festivalID;
            newComment.UserID = user.ID;
            newComment.Date = DateTime.Now;

            evaluationService.Insert(newComment);

            return RedirectToAction("Comment", "Account", new { festivalID });
        }

        public ActionResult AddTicket(int festID, int userID)
        {
            Ticket ticket = new Ticket();

            ticket.FestivalID = festID;
            ticket.UserID = userID;

            ticketService.Insert(ticket);

            return RedirectToAction("Index", "Home");
        }

        public ActionResult Logout()
        {
            Session["kullanici"] = null;
            return RedirectToAction("Index", "Home");
        }
    }
}