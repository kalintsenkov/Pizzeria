namespace Pizzeria.Server.Features.Addresses
{
    using System.Threading.Tasks;
    using Infrastructure.Services.User;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using Models;

    [Authorize]
    public class AddressesController : ApiController
    {
        private readonly IAddressesService addresses;
        private readonly ICurrentUserService currentUser;

        public AddressesController(
            IAddressesService addresses,
            ICurrentUserService currentUser)
        {
            this.addresses = addresses;
            this.currentUser = currentUser;
        }

        [HttpPost]
        public async Task<ActionResult<int>> Create(
            AddressesRequestModel request)
            => await this.addresses.CreateAsync(
                request, this.currentUser.UserId);
    }
}
