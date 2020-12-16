namespace Pizzeria.Server.Data.Models
{
    using System.Collections.Generic;
    using Common;

    public class ShoppingCart : Entity
    {
        public int Id { get; set; }

        public string UserId { get; set; }

        public PizzeriaUser User { get; set; }

        public ICollection<ShoppingCartPizza> Pizzas { get; } = new HashSet<ShoppingCartPizza>();
    }
}
