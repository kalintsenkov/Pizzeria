namespace Pizzeria.Server.Features.Pizzas
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Infrastructure.Common;
    using Infrastructure.Services.Common;
    using Models;

    public interface IPizzasService : IService
    {
        Task<int> CreateAsync(PizzasRequestModel model);

        Task<Result> UpdateAsync(int id, PizzasRequestModel model);

        Task<Result> DeleteAsync(int id);

        Task<PizzasDetailsResponseModel> DetailsAsync(int id);

        Task<IEnumerable<PizzasListingResponseModel>> SearchAsync();
    }
}
