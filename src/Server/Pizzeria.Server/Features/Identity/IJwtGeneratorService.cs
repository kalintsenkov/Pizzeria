namespace Pizzeria.Server.Features.Identity
{
    using System.Threading.Tasks;
    using Data.Models;
    using Infrastructure.Services.Common;

    public interface IJwtGeneratorService : IService
    {
        Task<string> GenerateJwtAsync(PizzeriaUser user);
    }
}
