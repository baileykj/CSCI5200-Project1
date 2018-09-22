using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MamaJanePizza.Models;


namespace MamaJanePizza.Controllers
{
    public class LoginController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Index(CustomerModel customer)
        {
            if (String.IsNullOrEmpty(customer.Email) || String.IsNullOrEmpty(customer.Password))
            {
                ViewBag.Message = "Error! Please Enter Both Email and Password";
                return Redirect("/Login");
            }
            else
            {
                CustomerModel user = GlobalCustomerListModel.SearchByEmail(customer.Email);
                if (user != null)
                {
                    GlobalCustomerListModel.CurrentUser = user;//This should be the only time we set a new current user
                    return View();
                }
                else
                {
                    ViewBag.Message = "Error! Email or Password invalid";
                    return View();
                }
            }

        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(CustomerModel customer)
        {
            if(customer.IsValid(customer))
            {
                GlobalCustomerListModel.Add(customer);

                return Redirect("/");
            }
            else
            {
                ViewBag.Message = "Error! Please Enter Valid Information";
                return View();
            }
        }

        public ActionResult Manage()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Manage(CustomerModel customer)
        {
            GlobalCustomerListModel.RemoveCustomer();

            return Redirect("/");
        }
    }
}