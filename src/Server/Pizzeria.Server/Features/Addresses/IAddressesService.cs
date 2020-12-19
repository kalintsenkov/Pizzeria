namespace Pizzeria.Server.Features.Addresses
{
    using System.Threading.Tasks;
    using Infrastructure.Services.Common;
    using Models;

    public interface IAddressesService : IService
    {
        Task<int> CreateAsync(AddressesRequestModel request, string userId);
    }
}
