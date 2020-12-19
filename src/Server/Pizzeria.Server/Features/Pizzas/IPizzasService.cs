namespace Pizzeria.Server.Features.Pizzas
{
    using System.Threading.Tasks;
    using Infrastructure.Common;
    using Infrastructure.Services.Common;
    using Models;

    public interface IPizzasService : IService
    {
        Task<int> CreateAsync(PizzasRequestModel request);

        Task<Result> UpdateAsync(int id, PizzasRequestModel request);

        Task<Result> DeleteAsync(int id);

        Task<PizzasDetailsResponseModel> DetailsAsync(int id);

        Task<PizzasSearchResponseModel> SearchAsync(PizzasSearchRequestModel request);
    }
}
