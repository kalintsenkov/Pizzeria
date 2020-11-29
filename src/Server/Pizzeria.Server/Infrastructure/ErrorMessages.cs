namespace Pizzeria.Server.Infrastructure
{
    internal class ErrorMessages
    {
        public const string InvalidEmailErrorMessage
            = "Невалидна електронна поща";

        public const string TakenEmailErrorMessage
            = "Имейлът '{0}' е вече зает.";

        public const string PasswordsDoNotMatchErrorMessage
            = "Паролите не съвпадат";

        public const string RequiredFieldErrorMessage
            = "Полето {0} е задължително";

        public const string RangeErrorMessage
            = "Полето {0} трябва да е между {1} и {2}";

        public const string MinLengthErrorMessage
            = "Полето {0} трябва да е поне {1} символа";

        public const string MaxLengthErrorMessage
            = "Полето {0} трябва да е най-много {1} символа";

        public const string StringLengthErrorMessage
            = "Полето {0} трябва да е с поне {2} и най-много {1} символа";

        public const string PhoneNumberErrorMessage
            = "Полето {0} трябва да съдържа само цифри.";

        public const string AlreadyAddedMessage
            = "Този продукт вече е добавен";
    }
}
