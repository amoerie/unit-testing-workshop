using System.Collections.Generic;
using System.Data.Entity.Migrations;
using UnitTestingWorkshop.Core.Exercise03Pizzas.Database;
using UnitTestingWorkshop.Core.Exercise03Pizzas.Models;
using Xunit;

namespace UnitTestingWorkshop.Tests.Exercise03Pizzas
{
    public class TestsForPizzaRestaurant
    {
        public TestsForPizzaRestaurant()
        {
        }

        [Fact]
        public void ShouldBeAbleToFindAndOrderTwoPizzas()
        {
            // Arrange

            // Act

            // Assert
        }

        static void Seed(IPizzaContextProvider pizzaContextProvider)
        {
            using (var pizzaContext = pizzaContextProvider.Provide())
            {
                var tomatoSauce = new Ingredient { Id = 1, Name = "Tomato sauce" };
                var mozzarella = new Ingredient { Id = 2, Name = "Mozzarella" };
                var pineapple = new Ingredient { Id = 3, Name = "Pineapple" };
                var chicken = new Ingredient { Id = 4, Name = "Chicken" };
                var salami = new Ingredient { Id = 5, Name = "Salami" };
                
                pizzaContext.Ingredients.AddOrUpdate(
                    tomatoSauce,    
                    mozzarella,    
                    pineapple,    
                    chicken,    
                    salami    
                );

                var hawai = new Pizza
                {
                    Id = 1,
                    Name = "Hawaii",
                    Ingredients = new List<PizzaIngredient>
                    {
                        new PizzaIngredient {Ingredient = tomatoSauce},
                        new PizzaIngredient {Ingredient = mozzarella},
                        new PizzaIngredient {Ingredient = chicken},
                        new PizzaIngredient {Ingredient = pineapple},
                    }
                };

                var pepperoni = new Pizza
                {
                    Id = 2,
                    Name = "Pepperoni",
                    Ingredients = new List<PizzaIngredient>
                    {
                        new PizzaIngredient {Ingredient = tomatoSauce},
                        new PizzaIngredient {Ingredient = mozzarella},
                        new PizzaIngredient {Ingredient = salami},
                    }
                };

                var margherita = new Pizza
                {
                    Id = 3,
                    Name = "Margherita",
                    Ingredients = new List<PizzaIngredient>
                    {
                        new PizzaIngredient {Ingredient = tomatoSauce},
                        new PizzaIngredient {Ingredient = mozzarella},
                    }
                };

                pizzaContext.Pizzas.AddOrUpdate(hawai, pepperoni, margherita);

                pizzaContext.SaveChanges();
            }
        }
    }
}