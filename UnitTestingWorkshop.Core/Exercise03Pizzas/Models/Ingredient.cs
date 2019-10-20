using System.Collections.Generic;

namespace UnitTestingWorkshop.Core.Exercise03Pizzas.Models
{
    public class Ingredient
    {
        public long Id { get; set; }
        public string Name { get; set; }

        public ICollection<PizzaIngredient> Pizzas { get; set; }

    }
}