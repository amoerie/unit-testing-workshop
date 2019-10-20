using System;
using System.Data.Entity;
using System.Linq;
using UnitTestingWorkshop.Core.Exercise03Pizzas.Database;
using UnitTestingWorkshop.Core.Exercise03Pizzas.Models;

namespace UnitTestingWorkshop.Core.Exercise03Pizzas.Finding
{
    public interface IPizzaFinder
    {
        Pizza FindByName(string name);
    }

    public class PizzaFinder : IPizzaFinder
    {
        private readonly IPizzaContextProvider _pizzaContextProvider;

        public PizzaFinder(IPizzaContextProvider pizzaContextProvider)
        {
            _pizzaContextProvider = pizzaContextProvider ?? throw new ArgumentNullException(nameof(pizzaContextProvider));
        }
        
        public Pizza FindByName(string name)
        {
            using (var pizzaContext = _pizzaContextProvider.Provide())
            {
                return pizzaContext.Pizzas
                    .Include(p => p.Ingredients)
                    .Include(p => p.Ingredients.Select(i => i.Ingredient))
                    .SingleOrDefault(i => i.Name == name);
            }
        }
    }
}