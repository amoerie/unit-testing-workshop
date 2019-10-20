using System;
using System.Collections.Generic;
using System.Linq;
using UnitTestingWorkshop.Core.Exercise03Pizzas.Database;
using UnitTestingWorkshop.Core.Exercise03Pizzas.Models;

namespace UnitTestingWorkshop.Core.Exercise03Pizzas.Finding
{
    public interface IIngredientFinder
    {
        IEnumerable<Ingredient> FindByName(string name);
    }

    public class IngredientFinder : IIngredientFinder
    {
        private readonly IPizzaContextProvider _pizzaContextProvider;

        public IngredientFinder(IPizzaContextProvider pizzaContextProvider)
        {
            _pizzaContextProvider = pizzaContextProvider ?? throw new ArgumentNullException(nameof(pizzaContextProvider));
        }
        
        public IEnumerable<Ingredient> FindByName(string name)
        {
            using (var pizzaContext = _pizzaContextProvider.Provide())
            {
                return pizzaContext.Ingredients.Where(i => i.Name == name).ToList();
            }
        }
    }
}