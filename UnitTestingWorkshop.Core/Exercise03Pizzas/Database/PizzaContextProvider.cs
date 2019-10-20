using UnitTestingWorkshop.Core.Exercise03Pizzas.Models;

namespace UnitTestingWorkshop.Core.Exercise03Pizzas.Database
{
    public interface IPizzaContextProvider
    {
        PizzaContext Provide();
    }

    public class PizzaContextProvider : IPizzaContextProvider
    {
        public PizzaContext Provide()
        {
            return new PizzaContext("PizzaDB");
        }
    }
}