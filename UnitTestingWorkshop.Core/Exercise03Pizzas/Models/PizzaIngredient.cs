namespace UnitTestingWorkshop.Core.Exercise03Pizzas.Models
{
    public class PizzaIngredient
    {
        public long PizzaId { get; set; }
        public Pizza Pizza { get; set; }

        public long IngredientId { get; set; }
        public Ingredient Ingredient { get; set; }
    }
}