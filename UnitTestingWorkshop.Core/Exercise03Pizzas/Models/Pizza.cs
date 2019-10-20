using System.Collections.Generic;

namespace UnitTestingWorkshop.Core.Exercise03Pizzas.Models
{
    public class Pizza
    {
        public long Id { get; set; }
        public string Name { get; set; }
        
        public ICollection<PizzaIngredient> Ingredients { get; set; }

        public ICollection<PizzaOrder> Orders { get; set; }

    }
}