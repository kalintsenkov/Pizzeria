namespace Pizzeria.Server.Infrastructure.Services.Machine
{
    using System;

    public class DateTimeService : IDateTimeService
    {
        public DateTime Now => DateTime.UtcNow;
    }
}
