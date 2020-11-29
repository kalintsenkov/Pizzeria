namespace Pizzeria.Server.Data.Models
{
    using System.Collections.Generic;
    using Common;

    public class Order : Entity<int>
    {
        public string UserId { get; set; }

        public PizzeriaUser User { get; set; }

        public ICollection<OrderPizza> Pizzas { get; } = new HashSet<OrderPizza>();
    }
}
