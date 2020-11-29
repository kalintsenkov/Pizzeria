namespace Pizzeria.Server.Features.Orders
{
    using System.Threading.Tasks;
    using Infrastructure.Services.Common;
    using Models;

    public interface IOrdersService : IService
    {
        Task<int> PurchaseAsync(OrdersRequestModel request, string userId);
    }
}
