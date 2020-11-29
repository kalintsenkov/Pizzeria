namespace Pizzeria.Server.Features.Identity
{
    using System.Linq;
    using System.Threading.Tasks;
    using Data.Models;
    using Infrastructure.Common;
    using Microsoft.AspNetCore.Identity;
    using Models;

    public class IdentityService : IIdentityService
    {
        private const string InvalidErrorMessage = "Invalid credentials.";

        private readonly UserManager<PizzeriaUser> userManager;
        private readonly IJwtGeneratorService jwtGenerator;

        public IdentityService(
            UserManager<PizzeriaUser> userManager,
            IJwtGeneratorService jwtGenerator)
        {
            this.userManager = userManager;
            this.jwtGenerator = jwtGenerator;
        }

        public async Task<Result> RegisterAsync(
            RegisterRequestModel request)
        {
            var user = new PizzeriaUser(request.Email);

            var identityResult = await this.userManager.CreateAsync(user, request.Password);

            var errors = identityResult.Errors.Select(e => e.Description);

            return identityResult.Succeeded
                ? Result.Success
                : Result.Failure(errors);
        }

        public async Task<Result<LoginResponseModel>> LoginAsync(
            LoginRequestModel request)
        {
            var user = await this.userManager.FindByEmailAsync(request.Email);
            if (user == null)
            {
                return InvalidErrorMessage;
            }

            var passwordValid = await this.userManager.CheckPasswordAsync(user, request.Password);
            if (!passwordValid)
            {
                return InvalidErrorMessage;
            }

            var token = await this.jwtGenerator.GenerateJwtAsync(user);

            return new LoginResponseModel { Token = token };
        }
    }
}
