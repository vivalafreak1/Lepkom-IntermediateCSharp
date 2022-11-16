using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using MySql.Data.MySqlClient;

namespace pert5_50420221.Controllers
{
    public class HomeController : Controller
    {
        private MySqlConnection conn = Models.Database.Connection();
        private Models.UserDB db;

        public HomeController()
        {
            this.db = new Models.UserDB(this.conn);
        }
        // GET: /Home/
        public ActionResult Index()
        {
            if (Session["auth"] == null)
            {
                return RedirectToAction("Login");
            }
            return View();
        }

        // GET: /Home/Login
        public ActionResult Login()
        {
            return View();
        }

        // POST; /Home/Login
        [HttpPost]
        public ActionResult Login(FormCollection collection)
        {
            var user = this.db.FindUserByUsername(collection["Username"]);

            if (user != null)
            {
                if (user.Password == collection["Password"])
                {
                    Session["auth"] = "true";
                    return RedirectToAction("Index");
                }
            }

            return View();
        }

        // GET: /Home/Register
        public ActionResult Register()
        {
            return View();
        }

        //POST : /Home/Register

        [HttpPost]
        public ActionResult Register(FormCollection collection)
        {
            var user = new Models.User();
            user.Username = collection["Username"];
            user.Password = collection["Password"];

            try
            {
                this.db.InsertUser(user);
                return RedirectToAction("Login");
            }
            catch (Exception e)
            {
                return View(e);
            }
        }
    }
}
