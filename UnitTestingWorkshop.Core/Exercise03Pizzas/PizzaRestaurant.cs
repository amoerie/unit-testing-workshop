using System;
using System.Collections.Generic;
using UnitTestingWorkshop.Core.Exercise03Pizzas.Finding;
using UnitTestingWorkshop.Core.Exercise03Pizzas.Models;
using UnitTestingWorkshop.Core.Exercise03Pizzas.Ordering;

namespace UnitTestingWorkshop.Core.Exercise03Pizzas
{
    public interface IPizzaRestaurant
    {
        IEnumerable<Pizza> FindPizzaByName(string name);
        Order Order(IEnumerable<Pizza> pizzas);
    }

    public class PizzaRestaurant : IPizzaRestaurant
    {
        private readonly IPizzaFinder _finder;
        private readonly IPizzaOrderer _orderer;

        public PizzaRestaurant(IPizzaFinder finder, IPizzaOrderer orderer)
        {
            _finder = finder ?? throw new ArgumentNullException(nameof(finder));
            _orderer = orderer ?? throw new ArgumentNullException(nameof(orderer));
        }
        
        public IEnumerable<Pizza> FindPizzaByName(string name)
        {
            return _finder.FindByName(name);
        }

        public Order Order(IEnumerable<Pizza> pizzas)
        {
            return _orderer.Order(pizzas);
        }
    }
}