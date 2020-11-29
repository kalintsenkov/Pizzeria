namespace Pizzeria.Server.Features.Orders
{
    using System.Threading.Tasks;
    using Infrastructure.Services.User;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Models;

    [Authorize]
    public class OrdersController : ApiController
    {
        private readonly IOrdersService orders;
        private readonly ICurrentUserService currentUser;

        public OrdersController(
            IOrdersService orders,
            ICurrentUserService currentUser)
        {
            this.orders = orders;
            this.currentUser = currentUser;
        }

        [HttpPost]
        public async Task<ActionResult<int>> Purchase(
            OrdersRequestModel request)
            => await this.orders.PurchaseAsync(
                request, this.currentUser.UserId);
    }
}
