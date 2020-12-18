namespace Pizzeria.Server.Features.Pizzas.Models
{
    using System.ComponentModel.DataAnnotations;

    using static Data.DataConstants.Common;
    using static Data.DataConstants.Pizza;
    using static Infrastructure.ErrorMessages;

    public class PizzasRequestModel
    {
        [Required]
        [StringLength(
            MaxNameLength,
            MinimumLength = MinNameLength,
            ErrorMessage = StringLengthErrorMessage)]
        public string Name { get; set; }

        [Range(typeof(decimal), MinPrice, MaxPrice)]
        public decimal Price { get; set; }

        [Required]
        [Url]
        [MaxLength(MaxUrlLength)]
        public string ImageUrl { get; set; }

        [Required]
        [MaxLength(MaxDescriptionLength)]
        public string Description { get; set; }

        [Range(MinCalories, MaxCalories)]
        public int Calories { get; set; }
    }
}
