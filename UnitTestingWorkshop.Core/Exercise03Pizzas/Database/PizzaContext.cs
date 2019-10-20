using System.Data.Common;
using System.Data.Entity;
using UnitTestingWorkshop.Core.Exercise03Pizzas.Models;

namespace UnitTestingWorkshop.Core.Exercise03Pizzas.Database
{
    public class PizzaContext : DbContext
    {
        public IDbSet<Order> Orders { get; set; }
        public IDbSet<PizzaOrder> PizzaOrders { get; set; }
        public IDbSet<Pizza> Pizzas { get; set; }
        public IDbSet<PizzaIngredient> PizzaIngredients { get; set; }
        public IDbSet<Ingredient> Ingredients { get; set; }

        public PizzaContext(string nameOrConnectionString) : base(nameOrConnectionString)
        {
        }

        public PizzaContext(DbConnection existingConnection, bool contextOwnsConnection) : base(existingConnection, contextOwnsConnection)
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Pizza>()
                .HasMany(p => p.Ingredients)
                .WithRequired(pi => pi.Pizza)
                .HasForeignKey(pi => pi.PizzaId);

            modelBuilder.Entity<Ingredient>()
                .HasMany(i => i.Pizzas)
                .WithRequired(pi => pi.Ingredient)
                .HasForeignKey(pi => pi.IngredientId);

            modelBuilder.Entity<Order>()
                .HasMany(o => o.Pizzas)
                .WithRequired(po => po.Order)
                .HasForeignKey(po => po.OrderId);

            modelBuilder.Entity<Pizza>()
                .HasMany(p => p.Orders)
                .WithRequired(po => po.Pizza)
                .HasForeignKey(po => po.PizzaId);
        }
    }
}