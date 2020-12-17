namespace Pizzeria.Server.Features.ShoppingCarts.Models
{
    using System.ComponentModel.DataAnnotations;

    using static Data.DataConstants.Order;

    public class ShoppingCartRequestModel
    {
        [Required]
        public int PizzaId { get; set; }

        [Required]
        [Range(MinQuantity, MaxQuantity)]
        public int Quantity { get; set; } = MinQuantity;

        [Required]
        public int Size { get; set; }
    }
}
