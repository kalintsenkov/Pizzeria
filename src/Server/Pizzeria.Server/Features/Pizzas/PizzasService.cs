﻿namespace Pizzeria.Server.Features.Pizzas
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using AutoMapper;
    using Data;
    using Data.Models;
    using Infrastructure.Common;
    using Infrastructure.Services.Common;
    using Microsoft.EntityFrameworkCore;
    using Models;

    public class PizzasService : DataService<Pizza>, IPizzasService
    {
        public PizzasService(PizzeriaDbContext data, IMapper mapper)
            : base(data, mapper)
        {
        }

        public async Task<int> CreateAsync(PizzasRequestModel request)
        {
            var pizza = new Pizza
            {
                Name = request.Name,
                Price = request.Price,
                ImageUrl = request.ImageUrl,
                Description = request.Description,
                Calories = request.Calories
            };

            await this.Data.AddAsync(pizza);
            await this.Data.SaveChangesAsync();

            return pizza.Id;
        }

        public async Task<Result> UpdateAsync(int id, PizzasRequestModel request)
        {
            var pizza = await this.FindByIdAsync(id);

            if (pizza == null)
            {
                return false;
            }

            pizza.Name = request.Name;
            pizza.Price = request.Price;
            pizza.ImageUrl = request.ImageUrl;
            pizza.Description = request.Description;
            pizza.Calories = request.Calories;

            await this.Data.SaveChangesAsync();

            return true;
        }

        public async Task<Result> DeleteAsync(int id)
        {
            var pizza = await this.FindByIdAsync(id);

            if (pizza == null)
            {
                return false;
            }

            this.Data.Remove(pizza);

            await this.Data.SaveChangesAsync();

            return true;
        }

        public async Task<PizzasDetailsResponseModel> DetailsAsync(
            int id)
            => await this.Mapper
                .ProjectTo<PizzasDetailsResponseModel>(this
                    .AllAsNoTracking()
                    .Where(p => p.Id == id))
                .FirstOrDefaultAsync();

        public async Task<IEnumerable<PizzasListingResponseModel>> SearchAsync()
            => await this.Mapper
                .ProjectTo<PizzasListingResponseModel>(this
                    .AllAsNoTracking())
                .ToListAsync();

        private async Task<Pizza> FindByIdAsync(
            int id)
            => await this
                .All()
                .Where(p => p.Id == id)
                .FirstOrDefaultAsync();
    }
}
