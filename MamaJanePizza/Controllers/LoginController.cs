using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MamaJanePizza.Models;
using System.Net.Http;
using System.Net.Mail;
using SendGrid;
using SendGrid.Helpers.Mail;

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
                    GlobalCustomerListModel.CurrentUser = user;
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

        public ActionResult Recover()
        {
            return View(); 
        }

        [HttpPost]
        public ActionResult Recover(CustomerModel customer)
        {
            var client = new SendGridClient("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");
            var msg = new SendGridMessage()
            {
                From = new EmailAddress("MamaJane@pizza.com", "Mama Jane's Pizza"),
                Subject = "Account Password Reset",
                HtmlContent = "Reset your password by <a href='https://localhost:44302/Login/Reset'>clicking here</a>"
            };
            msg.AddTo(new EmailAddress(customer.Email));

            client.SendEmailAsync(msg);

            ViewBag.Message = "Email Sent!";
            
            GlobalCustomerListModel.CurrentUser = GlobalCustomerListModel.SearchByEmail(customer.Email);

            return View();
        }

        public ActionResult Reset()
        {
            return View();
        }

        public ActionResult PasswordReset(CustomerModel customer)
        {

            if(customer.Password.ToLower().Equals(customer.ComfirmPassword.ToLower()))
            {
                GlobalCustomerListModel.CurrentUser.Password = customer.Password;//Updating with the new password
                GlobalCustomerListModel.CurrentUser.ComfirmPassword = customer.ComfirmPassword;//Updating with the new password
                return Redirect("/");
            }
            else
            {
                ViewBag.Message = "Error, Passwords Did Not Match!";
                return Redirect("/Login/Reset");            
            }

        }

    }
}