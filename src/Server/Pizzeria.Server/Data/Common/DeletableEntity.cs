namespace Pizzeria.Server.Data.Common
{
    using System;

    public abstract class DeletableEntity<TKey> : Entity<TKey>, IDeletableEntity
    {
        public DateTime? DeletedOn { get; set; }

        public bool IsDeleted { get; set; }
    }
}
