namespace Pizzeria.Server.Features.ShoppingCarts.Models
{
    using System.ComponentModel.DataAnnotations;

    using static Data.DataConstants.Order;

    public class ShoppingCartRequestModel
    {
        [Required]
        public int PizzaId { get; set; }

        [Range(MinQuantity, MaxQuantity)]
        public int Quantity { get; set; } = MinQuantity;
    }
}
