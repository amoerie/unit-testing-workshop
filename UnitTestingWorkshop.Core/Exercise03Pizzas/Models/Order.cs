using System;
using System.Collections.Generic;

namespace UnitTestingWorkshop.Core.Exercise03Pizzas.Models
{
    public class Order
    {
        public long Id { get; set; }

        public DateTimeOffset TimeStamp { get; set; }
        
        public ICollection<PizzaOrder> Pizzas { get; set; }

    }
}