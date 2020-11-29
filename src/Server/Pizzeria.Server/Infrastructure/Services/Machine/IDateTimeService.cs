namespace Pizzeria.Server.Infrastructure.Services.Machine
{
    using System;
    using Common;

    public interface IDateTimeService : IService
    {
        DateTime Now { get; }
    }
}
