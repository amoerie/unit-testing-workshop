
using System;
using Autofac;
using UnitTestingWorkshop.Core.Exercise03Pizzas.Database;

namespace UnitTestingWorkshop.Tests.Exercise03Pizzas.TestDatabase
{
    public class TestDatabaseModule: Module
    {
        private readonly string _databaseName;

        public TestDatabaseModule(string databaseName)
        {
            _databaseName = databaseName ?? throw new ArgumentNullException(nameof(databaseName));
        }
        
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterInstance(new TestPizzaContextProvider(_databaseName)).As<IPizzaContextProvider>();
        }
    }
}