namespace UnitTestingWorkshop.Core.Exercise03Pizzas.Models
{
    public class PizzaOrder
    {
        public long Id { get; set; }

        public long PizzaId { get; set; }
        public Pizza Pizza { get; set; }

        public long OrderId { get; set; }
        public Order Order { get; set; }
    }
}