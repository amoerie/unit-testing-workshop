using Autofac;

namespace UnitTestingWorkshop.Core.Exercise03Pizzas.Finding
{
    public class FindingModule: Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<IngredientFinder>().As<IIngredientFinder>().SingleInstance();
            builder.RegisterType<PizzasByIngredientFinder>().As<IPizzasByIngredientFinder>().SingleInstance();
        }
    }
}