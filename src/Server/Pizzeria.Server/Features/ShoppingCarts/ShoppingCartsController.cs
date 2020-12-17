namespace Pizzeria.Server.Features.ShoppingCarts
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Infrastructure.Services.User;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Models;

    [Authorize]
    public class ShoppingCartsController : ApiController
    {
        private readonly IShoppingCartsService shoppingCarts;
        private readonly ICurrentUserService currentUser;

        public ShoppingCartsController(
            IShoppingCartsService shoppingCarts,
            ICurrentUserService currentUser)
        {
            this.shoppingCarts = shoppingCarts;
            this.currentUser = currentUser;
        }

        [HttpGet]
        public async Task<IEnumerable<ShoppingCartPizzasResponseModel>> Mine()
            => await this.shoppingCarts.ByUserAsync(
                this.currentUser.UserId);

        [HttpGet(nameof(Total))]
        public async Task<ActionResult<int>> Total()
            => await this.shoppingCarts.TotalAsync(
                this.currentUser.UserId);

        [HttpPost]
        public async Task<ActionResult> AddPizza(
            ShoppingCartRequestModel model)
            => await this.shoppingCarts.AddPizzaAsync(
                model, this.currentUser.UserId);

        [HttpPut]
        public async Task<ActionResult> UpdatePizza(
            ShoppingCartRequestModel model)
            => await this.shoppingCarts.UpdatePizzaAsync(
                model, this.currentUser.UserId);

        [HttpDelete(Id)]
        public async Task<ActionResult> RemovePizza(
            int id)
            => await this.shoppingCarts.RemovePizzaAsync(
                id, this.currentUser.UserId);
    }
}
