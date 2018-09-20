using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace MamaJanePizza.Models
{
    public class CustomerModel
    {
        public string Email {get; set;}
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ComfirmedPassword { get; set; }

        public CustomerModel()
        {
            Email = "";
            Password = "";
            FirstName = "";
            LastName = "";
        }

        public CustomerModel(String email, String password, String firstname, String lastname)
        {
            Email = email;
            Password = password;
            FirstName = firstname;
            LastName = lastname;
        }

        /// <summary>
        /// Checking to make sure all the data fields have input
        /// </summary>
        /// <param name="user"></param>
        /// <returns>Boolean</returns>
        public bool IsValid(CustomerModel user)
        {
            if(String.IsNullOrEmpty(user.Email) || String.IsNullOrEmpty(user.Password) || 
                String.IsNullOrEmpty(user.FirstName) || String.IsNullOrEmpty(user.LastName))
            {
                return false;
            }

            return true;
        }

    }
}