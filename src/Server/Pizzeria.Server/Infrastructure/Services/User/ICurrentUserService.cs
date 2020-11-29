namespace Pizzeria.Server.Infrastructure.Services.User
{
    using Common;

    public interface ICurrentUserService : IScopedService
    {
        string UserId { get; }
    }
}
