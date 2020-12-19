namespace Pizzeria.Server.Features.Pizzas.Models
{
    public class PizzasSearchRequestModel
    {
        public string Query { get; set; }

        public int Page { get; set; } = 1;
    }
}
