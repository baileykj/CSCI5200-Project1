using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MamaJanePizza.Models
{
    public class PizzaModel
    {
        public int Id { get; set; }
        public List<String> Toppings { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:c}")]
        public double Price { get; set; }
        public String Crust { get; set; }
        public String Size { get; set; }
        public String TypeOfCheese { get; set; }
        public String TypeOfSauce { get; set; }

        public PizzaModel(PizzaModel pizza)
        {
            this.Size = pizza.Size;
            this.Crust = pizza.Crust;
            this.TypeOfCheese = pizza.TypeOfCheese;
            this.Toppings = pizza.Toppings;
            this.Price = pizza.Price;
            this.TypeOfSauce = pizza.TypeOfSauce;
        }

        public PizzaModel()
        {

        }
    }
}
