namespace Pizzeria.Server.Features.ShoppingCarts.Models
{
    using AutoMapper;
    using Data.Models;
    using Infrastructure.Mapping;

    public class ShoppingCartPizzasResponseModel : IMapFrom<ShoppingCartPizza>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public string ImageUrl { get; set; }

        public int Quantity { get; set; }

        public string Size { get; set; }

        public void Mapping(Profile mapper)
            => mapper
                .CreateMap<ShoppingCartPizza, ShoppingCartPizzasResponseModel>()
                .ForMember(m => m.Id, m => m
                    .MapFrom(c => c.Pizza.Id))
                .ForMember(m => m.Name, m => m
                    .MapFrom(c => c.Pizza.Name))
                .ForMember(m => m.Price, m => m
                    .MapFrom(c => c.Pizza.Price))
                .ForMember(m => m.ImageUrl, m => m
                    .MapFrom(c => c.Pizza.ImageUrl))
                .ForMember(m => m.Quantity, m => m
                    .MapFrom(c => c.Quantity))
                .ForMember(m => m.Size, m => m
                    .MapFrom(c => c.Size.ToString()));
    }
}
