using Autofac;

namespace UnitTestingWorkshop.Core.Exercise03Pizzas.Database
{
    public class DatabaseModule: Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<PizzaContextProvider>().As<IPizzaContextProvider>().SingleInstance();
        }
    }
}