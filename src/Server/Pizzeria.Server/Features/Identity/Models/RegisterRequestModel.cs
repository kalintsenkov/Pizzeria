namespace Pizzeria.Server.Features.Identity.Models
{
    using System.ComponentModel.DataAnnotations;

    using static Infrastructure.ErrorMessages;

    public class RegisterRequestModel : LoginRequestModel
    {
        [Required]
        [DataType(DataType.Password)]
        [Compare(
            nameof(Password),
            ErrorMessage = PasswordsDoNotMatchErrorMessage)]
        public string ConfirmPassword { get; set; }
    }
}
