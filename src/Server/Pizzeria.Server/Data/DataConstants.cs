namespace Pizzeria.Server.Data
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

        public class Address
        {
            public const int MaxCityLength = 255;
            public const int MaxRegionLength = 255;
            public const int MinPhoneNumberLength = 10;
            public const int MaxPhoneNumberLength = 20;
            public const string PhoneNumberRegularExpression = @"[0-9]*";
        }

        public class Identity
        {
            public const int MinEmailLength = 3;
            public const int MaxEmailLength = 50;
            public const int MinPasswordLength = 6;
            public const string AdministratorRole = "Administrator";
        }

        public class Pizza
        {
            public const int MinCalories = 1;
            public const int MaxCalories = 1000;
            public const string MinPrice = "1";
            public const string MaxPrice = "100000";
        }

        public class Order
        {
            public const int MinQuantity = 1;
            public const int MaxQuantity = int.MaxValue;
        }
    }
}
