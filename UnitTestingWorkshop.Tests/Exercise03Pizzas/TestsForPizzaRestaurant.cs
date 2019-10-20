using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using Autofac;
using FluentAssertions;
using UnitTestingWorkshop.Core.Exercise03Pizzas;
using UnitTestingWorkshop.Core.Exercise03Pizzas.Database;
using UnitTestingWorkshop.Core.Exercise03Pizzas.Models;
using UnitTestingWorkshop.Tests.Exercise03Pizzas.TestDatabase;
using Xunit;

namespace UnitTestingWorkshop.Tests.Exercise03Pizzas
{
    public class TestsForPizzaRestaurant
    {
        private readonly IPizzaRestaurant _pizzaRestaurant;
        private readonly IPizzaContextProvider _pizzaContextProvider;

        public TestsForPizzaRestaurant()
        {
            var containerBuilder = new ContainerBuilder();

            containerBuilder.RegisterModule<PizzaRestaurantModule>();
            // This will overwrite the database registration
            containerBuilder.RegisterModule(new TestDatabaseModule(Guid.NewGuid().ToString()));

            var container = containerBuilder.Build();

            _pizzaRestaurant = container.Resolve<IPizzaRestaurant>();
            _pizzaContextProvider = container.Resolve<IPizzaContextProvider>();
        }

        [Fact]
        public void ShouldBeAbleToFindAndOrderTwoPizzas()
        {
            // Arrange
            Seed(_pizzaContextProvider);

            // Act
            var pepperoni = _pizzaRestaurant.FindPizzaByName("Pepperoni");
            var margherita = _pizzaRestaurant.FindPizzaByName("Margherita");
            var order = _pizzaRestaurant.Order(new[] {pepperoni, margherita});

            // Assert
            order.Should().NotBeNull();
            order.TimeStamp.Should().BeCloseTo(DateTimeOffset.Now, precision: TimeSpan.FromMinutes(1));
            order.Pizzas.Select(p => p.Pizza).Should().BeEquivalentTo(pepperoni, margherita);
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