﻿namespace Pizzeria.Server.Data.Models
{
    using System.Collections.Generic;
    using Common;
    using Enums;

    public class Pizza : DeletableEntity<int>
    {
        public string Name { get; set; }

        public decimal Price { get; set; }

        public string ImageUrl { get; set; }

        public string Description { get; set; }

        public int Calories { get; set; }

        public Size Size { get; set; }

        public ICollection<OrderPizza> Orders { get; } = new HashSet<OrderPizza>();
    }
}