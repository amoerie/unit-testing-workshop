using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using UnitTestingWorkshop.Core.Exercise03Pizzas.Database;
using UnitTestingWorkshop.Core.Exercise03Pizzas.Models;

namespace UnitTestingWorkshop.Core.Exercise03Pizzas.Finding
{
    public interface IPizzasByIngredientFinder
    {
        IEnumerable<Pizza> Find(Ingredient ingredient);
    }

    public class PizzasByIngredientFinder : IPizzasByIngredientFinder
    {
        private readonly IPizzaContextProvider _pizzaContextProvider;

        public PizzasByIngredientFinder(IPizzaContextProvider pizzaContextProvider)
        {
            _pizzaContextProvider = pizzaContextProvider ?? throw new ArgumentNullException(nameof(pizzaContextProvider));
        }
        
        public IEnumerable<Pizza> Find(Ingredient ingredient)
        {
            using (var pizzaContext = _pizzaContextProvider.Provide())
            {
                return pizzaContext.PizzaIngredients
                    .Where(pi => pi.IngredientId == ingredient.Id)
                    .Select(pi => pi.Pizza)
                    .Include(p => p.Ingredients)
                    .Include(p => p.Ingredients.Select(i => i.Ingredient))
                    .ToList();
            }
        }
    }
}