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

        // GET: Order/Create
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddToOrder()
        {
            double price = 0;
            pizza.Size = Convert.ToString(Request.Form["sizeRadio"]);
            pizza.Crust = Convert.ToString(Request.Form["crustRadio"]);
            pizza.TypeOfCheese = Convert.ToString(Request.Form["cheeseRadio"]);
            pizza.TypeOfSauce = Convert.ToString(Request.Form["sauceRadio"]);

            List<String> toppings = new List<String>(Request.Form["toppingsCheck"]);
            pizza.Toppings = toppings;
            
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