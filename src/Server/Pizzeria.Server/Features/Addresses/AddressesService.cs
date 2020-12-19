namespace Pizzeria.Server.Features.Addresses
{
    using System.Threading.Tasks;
    using AutoMapper;
    using Data;
    using Data.Models;
    using Infrastructure.Services.Common;
    using Models;

    public class AddressesService : DataService<Address>, IAddressesService
    {
        public AddressesService(PizzeriaDbContext data, IMapper mapper)
            : base(data, mapper)
        {
        }

        public async Task<int> CreateAsync(
            AddressesRequestModel request, string userId)
        {
            var address = new Address
            {
                City = request.City,
                Region = request.Region,
                Description = request.Description,
                PhoneNumber = request.PhoneNumber,
                UserId = userId
            };

            await this.Data.AddAsync(address);
            await this.Data.SaveChangesAsync();

            return address.Id;
        }
    }
}
