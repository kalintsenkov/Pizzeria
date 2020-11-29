namespace Pizzeria.Server.Data.Common
{
    using System;

    public interface IEntity
    {
        DateTime CreatedOn { get; set; }

        DateTime? ModifiedOn { get; set; }
    }
}
