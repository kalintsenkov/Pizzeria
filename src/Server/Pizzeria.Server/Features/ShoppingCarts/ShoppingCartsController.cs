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

        [HttpGet(nameof(TotalProducts))]
        public async Task<ActionResult<int>> TotalProducts()
            => await this.shoppingCarts.TotalAsync(
                this.currentUser.UserId);

        [HttpPost]
        public async Task<ActionResult> AddProduct(
            ShoppingCartRequestModel model)
            => await this.shoppingCarts.AddProductAsync(
                model, this.currentUser.UserId);

        [HttpPut]
        public async Task<ActionResult> UpdateProduct(
            ShoppingCartRequestModel model)
            => await this.shoppingCarts.UpdateProductAsync(
                model, this.currentUser.UserId);

        [HttpDelete(Id)]
        public async Task<ActionResult> RemoveProduct(
            int id)
            => await this.shoppingCarts.RemoveProductAsync(
                id, this.currentUser.UserId);
    }
}
