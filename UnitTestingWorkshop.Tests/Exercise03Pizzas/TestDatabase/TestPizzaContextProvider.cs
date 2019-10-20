using System;
using UnitTestingWorkshop.Core.Exercise03Pizzas.Database;

namespace UnitTestingWorkshop.Tests.Exercise03Pizzas.TestDatabase
{
    public class TestPizzaContextProvider : IPizzaContextProvider
    {
        private readonly string _databaseName;

        public TestPizzaContextProvider(string databaseName)
        {
            _databaseName = databaseName ?? throw new ArgumentNullException(nameof(databaseName));
        }

        public PizzaContext Provide()
        {
            var connection = Effort.DbConnectionFactory.CreatePersistent(_databaseName);
            var context = new PizzaContext(connection, true);
            
            context.Database.CreateIfNotExists();
            
            return context;
        }
    }
}