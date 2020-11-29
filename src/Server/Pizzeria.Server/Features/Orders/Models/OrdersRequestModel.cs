namespace Pizzeria.Server.Features.Orders.Models
{
    public class OrdersRequestModel
    {
        public int PizzaId { get; set; }

        public int Quantity { get; set; }

        public int Size { get; set; }
    }
}
