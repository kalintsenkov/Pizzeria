namespace Pizzeria.Server.Features.Pizzas.Models
{
    using Data.Models;
    using Infrastructure.Mapping;

    public class PizzasListingResponseModel : IMapFrom<Pizza>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public string ImageUrl { get; set; }

        public string Description { get; set; }
    }
}
