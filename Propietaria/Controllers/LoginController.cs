using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Propietaria.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Login()
        {
            return View();
        }

        public ActionResult Logoff()
        {
            Session["User"] = null;
            return RedirectToAction("Login", "Login");
        }

        [HttpPost]
        public ActionResult Login(string email, string password)
        {
            try
            {
                using (Models.ReclaimsAndComplaints2Entities db = new Models.ReclaimsAndComplaints2Entities())
                {
                    var oUser = (from d in db.Users
                                 where d.Email == email && d.Password == password
                                 select d).FirstOrDefault();

                    if (oUser == null)
                    {
                        ViewBag.Error = "Datos incorrectos o usuario no existe.";
                        return View();
                    }

                    Session["User"] = oUser;
                }

                return RedirectToAction("Index", "Home");
            }
            catch (Exception ex)
            {
                ViewBag.Error = ex.Message;
                return View();
            }
        }
    }
}