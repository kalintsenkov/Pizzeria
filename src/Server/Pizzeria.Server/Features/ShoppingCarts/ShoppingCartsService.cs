namespace Pizzeria.Server.Features.ShoppingCarts
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using AutoMapper;
    using Data;
    using Data.Models;
    using Data.Models.Enums;
    using Infrastructure.Common;
    using Infrastructure.Services.Common;
    using Microsoft.EntityFrameworkCore;
    using Models;

    public class ShoppingCartsService : DataService<ShoppingCart>, IShoppingCartsService
    {
        private const string InvalidErrorMessage = "This user cannot edit this shopping cart.";

        public ShoppingCartsService(PizzeriaDbContext db, IMapper mapper)
            : base(db, mapper)
        {
        }

        public async Task<Result> AddPizzaAsync(
            ShoppingCartRequestModel model, string userId)
        {
            var pizzaId = model.PizzaId;
            var requestQuantity = model.Quantity;

            var shoppingCart = await this
                .All()
                .FirstOrDefaultAsync(c => c.UserId == userId);

            shoppingCart ??= new ShoppingCart
            {
                UserId = userId
            };

            var shoppingCartProduct = new ShoppingCartPizza
            {
                ShoppingCart = shoppingCart,
                PizzaId = pizzaId,
                Quantity = requestQuantity,
                Size = (Size)model.Size
            };

            await this.Data.AddAsync(shoppingCartProduct);
            await this.Data.SaveChangesAsync();

            return Result.Success;
        }

        public async Task<Result> UpdatePizzaAsync(
            ShoppingCartRequestModel model, string userId)
        {
            var productId = model.PizzaId;
            var requestQuantity = model.Quantity;

            var shoppingCartProduct = await this.FindByProductAndUserAsync(
                productId,
                userId);

            if (shoppingCartProduct == null)
            {
                return InvalidErrorMessage;
            }

            shoppingCartProduct.Quantity = requestQuantity;

            await this.Data.SaveChangesAsync();

            return Result.Success;
        }

        public async Task<Result> RemovePizzaAsync(
            int pizzaId, string userId)
        {
            var shoppingCartProduct = await this.FindByProductAndUserAsync(
                pizzaId,
                userId);

            if (shoppingCartProduct == null)
            {
                return InvalidErrorMessage;
            }

            this.Data.Remove(shoppingCartProduct);

            await this.Data.SaveChangesAsync();

            return Result.Success;
        }

        public async Task<int> TotalAsync(
            string userId)
            => await this
                .AllByUserId(userId)
                .AsNoTracking()
                .CountAsync();

        public async Task<IEnumerable<ShoppingCartPizzasResponseModel>> ByUserAsync(
            string userId)
            => await this.Mapper
                .ProjectTo<ShoppingCartPizzasResponseModel>(this
                    .AllByUserId(userId)
                    .AsNoTracking())
                .ToListAsync();

        private async Task<ShoppingCartPizza> FindByProductAndUserAsync(
            int pizzaId,
            string userId)
            => await this
                .AllByUserId(userId)
                .FirstOrDefaultAsync(c => c.PizzaId == pizzaId);

        private IQueryable<ShoppingCartPizza> AllByUserId(
            string userId)
            => this
                .All()
                .Where(c => c.UserId == userId)
                .SelectMany(c => c.Pizzas);
    }
}
