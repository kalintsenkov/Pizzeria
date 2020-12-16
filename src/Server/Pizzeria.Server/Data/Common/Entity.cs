namespace Pizzeria.Server.Data.Common
{
    using System;

    public abstract class Entity : IEntity
    {
        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }
    }
}
