namespace Pizzeria.Server.Data.Common
{
    using System;

    public interface IDeletableEntity : IEntity
    {
        DateTime? DeletedOn { get; set; }

        bool IsDeleted { get; set; }
    }
}
