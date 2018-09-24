using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MamaJanePizza.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MamaJanePizza.Controllers
{
    public class OrderController : Controller
    {
        static PizzaModel pizza = new PizzaModel();

        // GET: Order
        public ActionResult Index()
        {
            return View();
        }

        // GET: Order/Details/5
        public ActionResult Details()
        {
            //PizzaModel piz = new PizzaModel(pizza);
            return View(pizza);
        }

        public ActionResult Confirm()
        {
            return View();
        }

        // GET: Order/Create
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Checkout()
        {
            var firstName = Convert.ToString(Request.Form["firstName"]);
            var middleName = Convert.ToString(Request.Form["middleName"]);
            var lastName = Convert.ToString(Request.Form["lastName"]);
            var tel = Convert.ToString(Request.Form["tel"]);
            var email = Convert.ToString(Request.Form["email"]);
            var ccNum = Convert.ToString(Request.Form["ccNum"]);
            var date = Convert.ToString(Request.Form["date"]);
            var cvv = Convert.ToString(Request.Form["cvv"]);

            return RedirectToAction("Confirm");
        }
        [HttpPost]
        public ActionResult AddToOrder()
        {
            double price = 0;

            pizza.Size = Convert.ToString(Request.Form["sizeRadio"]);
            pizza.Crust = Convert.ToString(Request.Form["crustRadio"]);
            List<String> toppings = new List<String>(Request.Form["toppingsCheck"]);
            

            if (Convert.ToString(Request.Form["specialty"]) != "Select")
            {
                switch(Convert.ToString(Request.Form["specialty"]))
                {
                    case "BarbecueChicken": toppings.Add("Chicken");
                        toppings.Add("Onions");
                        pizza.TypeOfSauce = "Barbecue";
                        break;
                    case "MeatLovers": toppings.Add("Pepperoni");
                        toppings.Add("Meatball");
                        toppings.Add("Sausage");
                        toppings.Add("Ham");
                        pizza.TypeOfSauce = "Marinara";
                        break;
                    case "VeggieLovers": toppings.Add("Onions");
                        toppings.Add("Green pepper");
                        toppings.Add("Olives");
                        break;
                }
            }
            pizza.Toppings = toppings;
            if (String.IsNullOrEmpty(pizza.TypeOfSauce))
            {
                pizza.TypeOfSauce = Convert.ToString(Request.Form["sauceRadio"]);
            }
            if (String.IsNullOrEmpty(pizza.TypeOfCheese))
            {
                pizza.TypeOfCheese = Convert.ToString(Request.Form["cheeseRadio"]);
            }
            else {
                pizza.TypeOfCheese = Convert.ToString(Request.Form["sauceRadio"]);
            }
            
            
            switch (pizza.Size)
            {
                case "Small": price += 5;
                    break;
                case "Medium": price += 8;
                    break;
                case "Large": price += 10;
                    break;
            };
            if (pizza.TypeOfCheese == "Extra") price += 2;
            price += pizza.Toppings.Count * 0.50;
            pizza.Price = price;

            return RedirectToAction("Details", pizza);
        }

        // POST: Order/Create
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create(IFormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add insert logic here
        //        PizzaModel pizza = new PizzaModel
        //        {
        //            Size = collection["sizeRadio"],
        //            Crust = collection["crustRadio"],
        //            TypeOfCheese = collection["cheeseRadio"],
        //            Id = pizzas.Count()
        //        };

        //        pizzas.Add(pizza);

        //        return RedirectToAction("Details", new { id = pizza.Id });
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        // GET: Order/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Order/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Order/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Order/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}