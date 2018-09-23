using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace MamaJanePizza.Models
{
    //static means we can access this without initialization allowing it to be global and accessed anywhere
    public static class GlobalCustomerListModel
    {
        private static List<CustomerModel> _CustomerList = new List<CustomerModel>();
        public static CustomerModel CurrentUser { get; set; }

        //Might want to add some logic to prevent adding dups
        public static void Add(CustomerModel customer)
        {
            _CustomerList.Add(customer);
        }

        public static void RemoveByEmail(string email)
        {
            foreach (var item in _CustomerList)
            {
                if (item.Email.ToLower() == email.ToLower())
                {
                    _CustomerList.Remove(item);
                    break;
                }
            }
        }

        public static CustomerModel SearchByEmail(string email)
        {
            CustomerModel found = null;
            foreach (var item in _CustomerList)
            {
                if (item.Email.ToLower() == email.ToLower())
                {
                    found = item;
                    break;
                }
            }
            return found;
        }

        /// <summary>
        /// Removes the current user from the gloabl list then set current user to null
        /// </summary>
        /// <returns></returns>
        public static bool RemoveCustomer()
        {
            _CustomerList.Remove(CurrentUser);
            CurrentUser = null;
            return true;
        }

    }
}