using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;


namespace MamaJanePizza.Controllers
{
    public class LoginController : Controller
    {

        private string userEmail = "";
        private string password = "";
        private string firstname = "";
        private string lastname = "";
        private string confirmpassword = "";

        public IActionResult Index()
        {
            return View();
        }

        public ActionResult Register()
        {
            return View();
        }

        public ActionResult UserReg()
        {
            userEmail = Convert.ToString(Request.Form["user"]);
            password = Convert.ToString(Request.Form["password"]);
            firstname = Convert.ToString(Request.Form["firstname"]);
            lastname = Convert.ToString(Request.Form["lastname"]);
            confirmpassword = Convert.ToString(Request.Form["confirmpassword"]);

            if (String.IsNullOrEmpty(userEmail) || String.IsNullOrEmpty(password) || String.IsNullOrEmpty(firstname) || String.IsNullOrEmpty(lastname) || String.IsNullOrEmpty(confirmpassword))
            {
                return Redirect("/Login/Register");
            }
            else
                return Redirect("/");
        }

        public ActionResult AuthUser()
        {
            userEmail = Convert.ToString(Request.Form["user"]);
            password = Convert.ToString(Request.Form["password"]);

            if (String.IsNullOrEmpty(userEmail) || String.IsNullOrEmpty(password))
            {
                return Redirect("/Login");
            }
            else
                return Redirect("/");

        }
    }
}