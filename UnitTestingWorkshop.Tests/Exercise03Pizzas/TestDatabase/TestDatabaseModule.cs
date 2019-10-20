
using Autofac;
using UnitTestingWorkshop.Core.Exercise03Pizzas.Database;

namespace UnitTestingWorkshop.Tests.Exercise03Pizzas.TestDatabase
{
    public class TestDatabaseModule: Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<TestPizzaContextProvider>().As<IPizzaContextProvider>().SingleInstance();
        }
    }
}