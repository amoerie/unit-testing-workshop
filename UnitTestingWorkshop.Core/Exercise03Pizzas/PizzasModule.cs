using Autofac;
using UnitTestingWorkshop.Core.Exercise03Pizzas.Database;
using UnitTestingWorkshop.Core.Exercise03Pizzas.Finding;
using UnitTestingWorkshop.Core.Exercise03Pizzas.Ordering;

namespace UnitTestingWorkshop.Core.Exercise03Pizzas
{
    public class PizzasModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterModule<DatabaseModule>();
            builder.RegisterModule<FindingModule>();
            builder.RegisterModule<OrderingModule>();
        }
    }
}