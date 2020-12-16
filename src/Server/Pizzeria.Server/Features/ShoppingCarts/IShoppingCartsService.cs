namespace Pizzeria.Server.Features.ShoppingCarts
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Infrastructure.Common;
    using Infrastructure.Services.Common;
    using Models;

    public interface IShoppingCartsService : IService
    {
        Task<Result> AddProductAsync(ShoppingCartRequestModel model, string userId);

        Task<Result> UpdateProductAsync(ShoppingCartRequestModel model, string userId);

        Task<Result> RemoveProductAsync(int pizzaId, string userId);

        Task<int> TotalAsync(string userId);

        Task<IEnumerable<ShoppingCartPizzasResponseModel>> ByUserAsync(string userId);
    }
}
