namespace Pizzeria.Server.Infrastructure.Extensions
{
    using Microsoft.AspNetCore.Authorization;

    using static Data.DataConstants.Identity;

    public class AuthorizeAdministratorAttribute : AuthorizeAttribute
    {
        public AuthorizeAdministratorAttribute() => this.Roles = AdministratorRole;
    }
}
