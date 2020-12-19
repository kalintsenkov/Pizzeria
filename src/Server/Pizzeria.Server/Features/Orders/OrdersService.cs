namespace Pizzeria.Server.Features.Orders
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using AutoMapper;
    using Data;
    using Data.Models;
    using Infrastructure.Services.Common;
    using Microsoft.EntityFrameworkCore;
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
                UserId = userId,
                Notes = request.Notes,
                DeliveryAddressId = request.AddressId
            };

            var shoppingCartPizzas = await this
                .Data
                .ShoppingCartsPizzas
                .Where(sc => sc.ShoppingCart.UserId == userId)
                .ToListAsync();

            var orderPizzas = new List<OrderPizza>();

            foreach (var shoppingCartPizza in shoppingCartPizzas)
            {
                var orderPizza = new OrderPizza
                {
                    Order = order,
                    PizzaId = shoppingCartPizza.PizzaId,
                    Quantity = shoppingCartPizza.Quantity,
                    Size = shoppingCartPizza.Size
                };

                orderPizzas.Add(orderPizza);
            }

            this.Data.RemoveRange(shoppingCartPizzas);

            await this.Data.AddRangeAsync(orderPizzas);
            await this.Data.SaveChangesAsync();

            return order.Id;
        }
    }
}
