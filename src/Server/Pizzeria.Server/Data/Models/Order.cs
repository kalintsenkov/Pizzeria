namespace Pizzeria.Server.Data.Models
{
    using System.Collections.Generic;
    using Common;

    public class Order : Entity
    {
        public int Id { get; set; }

        public string Notes { get; set; }

        public string UserId { get; set; }

        public PizzeriaUser User { get; set; }

        public int DeliveryAddressId { get; set; }

        public Address DeliveryAddress { get; set; }

        public ICollection<OrderPizza> Pizzas { get; } = new HashSet<OrderPizza>();
    }
}
