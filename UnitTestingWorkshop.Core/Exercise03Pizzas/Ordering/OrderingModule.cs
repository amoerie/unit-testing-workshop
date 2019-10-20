using Autofac;

namespace UnitTestingWorkshop.Core.Exercise03Pizzas.Ordering
{
    public class OrderingModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<PizzaOrderer>().As<IPizzaOrderer>().SingleInstance();
        }
    }
}