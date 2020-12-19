namespace Pizzeria.Server.Data.Models
{
    using System;
    using System.Collections.Generic;
    using Common;

    public class PizzaData : IInitialData
    {
        public Type EntityType => typeof(Pizza);

        public IEnumerable<object> GetData()
            => new List<Pizza>
            {
                new()
                {
                    Name = "Garden Classic",
                    Price = 12.99m,
                    ImageUrl = "assets/img/prods-sm/1.png",
                    Description = "Tomato sauce, mozzarella, olives, fresh green peppers, onions, mushrooms, fresh tomatoes",
                    Calories = 699
                },
                new()
                {
                    Name = "New York",
                    Price = 12.99m,
                    ImageUrl = "assets/img/prods-sm/2.png",
                    Description = "Tomato sauce, mozzarella, bacon, cheddar, extra cheddar, fresh mushrooms",
                    Calories = 699
                },
                new()
                {
                    Name = "Pepperoni",
                    Price = 14.99m,
                    ImageUrl = "assets/img/prods-sm/4.png",
                    Description = "Mozzarella, tomato sauce, extra mozzarella, extra pepperoni",
                    Calories = 265
                },
                new()
                {
                    Name = "Slices Special",
                    Price = 13.99m,
                    ImageUrl = "assets/img/prods-sm/3.png",
                    Description = "Mozzarella, tomato sauce, ham, bacon, fresh mushrooms, fresh green peppers, onions",
                    Calories = 744
                },
                new()
                {
                    Name = "Ham Classic",
                    Price = 10.99m,
                    ImageUrl = "assets/img/prods-sm/5.png",
                    Description = "Tomato sauce, mozzarella, ham, green peppers, fresh mushrooms",
                    Calories = 492
                },
                new()
                {
                    Name = "Vegan Margherita",
                    Price = 16.99m,
                    ImageUrl = "assets/img/prods-sm/6.png",
                    Description = "Tomato sauce, vegan mozzarella, olive oil, basil * may contain traces of lactose *",
                    Calories = 1020
                }
            };
    }
}
