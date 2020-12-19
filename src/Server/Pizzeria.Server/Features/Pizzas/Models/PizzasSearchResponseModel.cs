namespace Pizzeria.Server.Features.Pizzas.Models
{
    using System.Collections.Generic;

    public class PizzasSearchResponseModel
    {
        public PizzasSearchResponseModel(
            IEnumerable<PizzasListingResponseModel> pizzas,
            int page,
            int totalPages)
        {
            this.Pizzas = pizzas;
            this.Page = page;
            this.TotalPages = totalPages;
        }

        public IEnumerable<PizzasListingResponseModel> Pizzas { get; }

        public int Page { get; }

        public int TotalPages { get; }
    }
}
