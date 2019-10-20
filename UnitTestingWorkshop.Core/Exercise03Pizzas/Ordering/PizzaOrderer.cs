using System;
using System.Collections.Generic;
using System.Linq;
using UnitTestingWorkshop.Core.Exercise03Pizzas.Database;
using UnitTestingWorkshop.Core.Exercise03Pizzas.Models;

namespace UnitTestingWorkshop.Core.Exercise03Pizzas.Ordering
{
    public interface IPizzaOrderer
    {
        Order Order(IEnumerable<Pizza> pizzas);
    }

    public class PizzaOrderer : IPizzaOrderer
    {
        private readonly IPizzaContextProvider _pizzaContextProvider;

        public PizzaOrderer(IPizzaContextProvider pizzaContextProvider)
        {
            _pizzaContextProvider = pizzaContextProvider ?? throw new ArgumentNullException(nameof(pizzaContextProvider));
        }
        
        public Order Order(IEnumerable<Pizza> pizzas)
        {
            using (var pizzaContext = _pizzaContextProvider.Provide())
            {
                var order = new Order
                {
                    Pizzas = new List<PizzaOrder>(),
                    TimeStamp = DateTimeOffset.Now
                };
                
                foreach (var p in pizzas)
                {
                    order.Pizzas.Add(new PizzaOrder
                    {
                        Pizza = p
                    });
                }
                
                pizzaContext.Orders.Add(order);
                pizzaContext.SaveChanges();

                return order;
            }
        }
    }
}