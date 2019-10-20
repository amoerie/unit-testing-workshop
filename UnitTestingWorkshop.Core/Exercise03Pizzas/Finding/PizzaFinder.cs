using System;
using System.Collections.Generic;
using System.Linq;
using UnitTestingWorkshop.Core.Exercise03Pizzas.Database;
using UnitTestingWorkshop.Core.Exercise03Pizzas.Models;

namespace UnitTestingWorkshop.Core.Exercise03Pizzas.Finding
{
    public interface IPizzaFinder
    {
        IEnumerable<Pizza> FindByName(string name);
    }

    public class PizzaFinder : IPizzaFinder
    {
        private readonly IPizzaContextProvider _pizzaContextProvider;

        public PizzaFinder(IPizzaContextProvider pizzaContextProvider)
        {
            _pizzaContextProvider = pizzaContextProvider ?? throw new ArgumentNullException(nameof(pizzaContextProvider));
        }
        
        public IEnumerable<Pizza> FindByName(string name)
        {
            using (var pizzaContext = _pizzaContextProvider.Provide())
            {
                return pizzaContext.Pizzas.Where(i => i.Name == name).ToList();
            }
        }
    }
}