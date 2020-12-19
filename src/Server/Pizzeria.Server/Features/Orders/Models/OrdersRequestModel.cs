namespace Pizzeria.Server.Features.Orders.Models
{
    using System.ComponentModel.DataAnnotations;

    using static Data.DataConstants.Common;

    public class OrdersRequestModel
    {
        [Required]
        public int AddressId { get; set; }

        [MaxLength(MaxDescriptionLength)]
        public string Notes { get; set; }
    }
}
