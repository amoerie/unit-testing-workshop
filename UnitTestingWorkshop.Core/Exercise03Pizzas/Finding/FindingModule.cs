using Autofac;

namespace UnitTestingWorkshop.Core.Exercise03Pizzas.Finding
{
    public class FindingModule: Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<PizzaFinder>().As<IPizzaFinder>().SingleInstance();
        }
    }
}