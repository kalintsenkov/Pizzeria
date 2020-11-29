namespace Pizzeria.Server.Features.Pizzas
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Infrastructure.Extensions;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Models;

    [AuthorizeAdministrator]
    public class PizzasController : ApiController
    {
        private readonly IPizzasService pizzas;

        public PizzasController(IPizzasService pizzas)
            => this.pizzas = pizzas;

        [HttpGet]
        [AllowAnonymous]
        public async Task<IEnumerable<PizzasListingResponseModel>> Search()
            => await this.pizzas.SearchAsync();

        [HttpGet(Id)]
        [AllowAnonymous]
        public async Task<ActionResult<PizzasDetailsResponseModel>> Details(
            int id)
            => await this.pizzas.DetailsAsync(id);

        [HttpPost]
        public async Task<ActionResult<int>> Create(
            PizzasRequestModel model)
            => await this.pizzas.CreateAsync(model);

        [HttpPut(Id)]
        public async Task<ActionResult> Update(
            int id, PizzasRequestModel model)
            => await this.pizzas.UpdateAsync(id, model);

        [HttpDelete(Id)]
        public async Task<ActionResult> Delete(
            int id)
            => await this.pizzas.DeleteAsync(id);
    }
}
