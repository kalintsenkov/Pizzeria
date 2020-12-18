namespace Pizzeria.Server.Data.Models
{
    using System.Collections.Generic;
    using Common;

    public class Pizza : Entity
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public string ImageUrl { get; set; }

        public string Description { get; set; }

        public int Calories { get; set; }

        public ICollection<OrderPizza> Orders { get; } = new HashSet<OrderPizza>();

        public ICollection<ShoppingCartPizza> ShoppingCarts { get; } = new HashSet<ShoppingCartPizza>();
    }
}
