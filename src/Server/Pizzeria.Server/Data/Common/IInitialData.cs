namespace Pizzeria.Server.Data.Common
{
    using System;
    using System.Collections.Generic;

    public interface IInitialData
    {
        Type EntityType { get; }

        IEnumerable<object> GetData();
    }
}