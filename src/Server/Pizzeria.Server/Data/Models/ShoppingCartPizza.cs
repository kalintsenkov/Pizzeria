namespace Pizzeria.Server.Data.Models
{
    using Common;
    using Enums;

    public class ShoppingCartPizza : Entity
    {
        public int ShoppingCartId { get; set; }

        public ShoppingCart ShoppingCart { get; set; }

        public int PizzaId { get; set; }

        public Pizza Pizza { get; set; }

        public int Quantity { get; set; }

        public Size Size { get; set; }
    }
}
