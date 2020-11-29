namespace Pizzeria.Server.Features.Identity
{
    using System;
    using System.Collections.Generic;
    using System.IdentityModel.Tokens.Jwt;
    using System.Security.Claims;
    using System.Text;
    using System.Threading.Tasks;
    using Data.Models;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.Extensions.Options;
    using Microsoft.IdentityModel.Tokens;

    using static Data.DataConstants.Identity;

    public class JwtGeneratorService : IJwtGeneratorService
    {
        private readonly UserManager<PizzeriaUser> userManager;
        private readonly ApplicationSettings applicationSettings;

        public JwtGeneratorService(
            UserManager<PizzeriaUser> userManager,
            IOptions<ApplicationSettings> applicationSettings)
        {
            this.userManager = userManager;
            this.applicationSettings = applicationSettings.Value;
        }

        public async Task<string> GenerateJwtAsync(PizzeriaUser user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id),
                new Claim(ClaimTypes.Email, user.Email)
            };

            var isAdministrator = await this.userManager.IsInRoleAsync(user, AdministratorRole);

            if (isAdministrator)
            {
                claims.Add(new Claim(ClaimTypes.Role, AdministratorRole));
            }

            var secret = Encoding.UTF8.GetBytes(this.applicationSettings.Secret);

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.UtcNow.AddDays(7),
                signingCredentials: new SigningCredentials(
                    new SymmetricSecurityKey(secret),
                    SecurityAlgorithms.HmacSha256));

            var tokenHandler = new JwtSecurityTokenHandler();
            var encryptedToken = tokenHandler.WriteToken(token);

            return encryptedToken;
        }
    }
}
