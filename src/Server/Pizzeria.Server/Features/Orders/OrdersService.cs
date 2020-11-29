namespace Pizzeria.Server.Features.Orders
{
    using System.Threading.Tasks;
    using AutoMapper;
    using Data;
    using Data.Models;
    using Data.Models.Enums;
    using Infrastructure.Services.Common;
    using Models;

    public class OrdersService : DataService<Order>, IOrdersService
    {
        public OrdersService(PizzeriaDbContext data, IMapper mapper)
            : base(data, mapper)
        {
        }

        public async Task<int> PurchaseAsync(OrdersRequestModel request, string userId)
        {
            var order = new Order
            {
                UserId = userId
            };

            var orderPizza = new OrderPizza
            {
                Order = order,
                PizzaId = request.PizzaId,
                Quantity = request.Quantity,
                Size = (Size)request.Size
            };

            await this.Data.AddAsync(orderPizza);
            await this.Data.SaveChangesAsync();

            return order.Id;
        }
    }
}
