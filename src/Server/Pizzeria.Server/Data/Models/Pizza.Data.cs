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
                    Name = "Margherita",
                    Price = 12.99m,
                    ImageUrl = "https://www.pngitem.com/pimgs/m/504-5040728_pizza-margherita-png-transparent-png.png",
                    Description = "Margherita is the mother of all pizzas. This Neopaltian-style pizza has thin crust, fresh tomato sauce, fresh mozzarella cheese, and just a few leaves of basil. Margherita’s toppings are simple but they also have the power to be truly sublime in a way few other toppings can be.",
                    Calories = 699
                },
                new()
                {
                    Name = "Pepperoni",
                    Price = 14.99m,
                    ImageUrl = "https://www.pngkey.com/png/detail/807-8074720_big-city-pizza-pepperoni.png",
                    Description = "We’d wager that pepperoni is still America’s number-one, most-popular pizza topping. This singular topping even graces the pizza emoji! It makes sense if you really consider everything that is good about pepperoni: The salty and slightly spicy taste holds its own against waves of melty, gooey cheese and gets ever-so-slightly crisped in the hot oven in such a crave-worthy way that no one can resist pulling them straight from the smoldering hot pizza and dropping them directly into their mouths.",
                    Calories = 265
                },
                new()
                {
                    Name = "BBQ Chicken",
                    Price = 13.99m,
                    ImageUrl = "https://i.dlpng.com/static/png/6961655_preview.png",
                    Description = "BBQ chicken is reported to be the invention of California Pizza Kitchen’s original pizza chef Ed LaDou in 1985. His original pizza creation was made with BBQ sauce, chicken, cilantro, red onions, and fontina cheese and remains on the CPK menu to this day. BBQ Pizza is beloved because it walks the border of sweet and savory and makes the best use of leftover chicken.",
                    Calories = 744
                },
                new()
                {
                    Name = "Hawaiian",
                    Price = 10.99m,
                    ImageUrl = "https://www.nicepng.com/png/detail/812-8126235_hawaiian-pizza-png.png",
                    Description = "A combination of tomato sauce, cheese, ham, and pineapple that is as beloved as it is despised still makes our list of iconic pizzas. Hawaiian pizza was reportedly invented in Canada, not the American islands it is named for. Like BBQ chicken pizza, those who love it cite the sweet and savory combination as the biggest draw to this popular pizza.",
                    Calories = 492
                },
                new()
                {
                    Name = "Meat-Lover’s",
                    Price = 16.99m,
                    ImageUrl = "https://www.kindpng.com/picc/m/186-1864560_meat-lovers-meat-deluxe-crust-pizza-hd-png.png",
                    Description = "Meat-lover’s pizza is the hero of our iconic pizzas, as it holds the most toppings on a single pie: pepperoni, sausage, meatballs, and mushrooms all come together in this hearty, super-savory pizza. Meat-lover’s pizza is our go-to when feeding a hungry crowd.",
                    Calories = 1020
                }
            };
    }
}
