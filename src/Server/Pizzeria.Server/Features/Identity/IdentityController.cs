namespace Pizzeria.Server.Features.Identity
{
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Models;

    public class IdentityController : ApiController
    {
        private readonly IIdentityService identity;

        public IdentityController(IIdentityService identity)
            => this.identity = identity;

        [HttpPost(nameof(Register))]
        public async Task<ActionResult> Register(
            RegisterRequestModel request)
            => await this.identity.RegisterAsync(request);

        [HttpPost(nameof(Login))]
        public async Task<ActionResult<LoginResponseModel>> Login(
            LoginRequestModel request)
            => await this.identity.LoginAsync(request);
    }
}
