namespace Pizzeria.Server.Infrastructure.Services.Machine
{
    using System;
    using Common;

    public interface IDateTimeService : IService
    {
        public DateTime Now { get; }
    }
}
