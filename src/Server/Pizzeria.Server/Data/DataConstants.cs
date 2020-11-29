﻿namespace Pizzeria.Server.Data
{
    public class DataConstants
    {
        public class Common
        {
            public const int MinNameLength = 3;
            public const int MaxNameLength = 50;
            public const int MaxUrlLength = 2048;
            public const int MaxDescriptionLength = 1000;
        }

        public class Identity
        {
            public const int MinEmailLength = 3;
            public const int MaxEmailLength = 50;
            public const int MinPasswordLength = 6;
        }

        public class Pizza
        {
            public const int MinQuantity = 1;
            public const int MaxQuantity = int.MaxValue;
            public const string MinPrice = "1";
            public const string MaxPrice = "100000";
        }
    }
}