namespace Pizzeria.Server.Features.Identity.Models
{
    using System.ComponentModel.DataAnnotations;

    using static Data.DataConstants.Identity;
    using static Infrastructure.ErrorMessages;

    public class LoginRequestModel
    {
        [Required]
        [EmailAddress]
        [StringLength(
            MaxEmailLength,
            MinimumLength = MinEmailLength,
            ErrorMessage = StringLengthErrorMessage)]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [MinLength(MinPasswordLength)]
        public string Password { get; set; }
    }
}
