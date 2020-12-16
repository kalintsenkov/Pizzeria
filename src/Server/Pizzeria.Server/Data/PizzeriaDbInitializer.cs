namespace Pizzeria.Server.Data
{
    using System.Threading.Tasks;
    using Common;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;
    using Models;

    using static DataConstants.Identity;

    public class PizzeriaDbInitializer : IInitializer
    {
        private readonly PizzeriaDbContext db;
        private readonly UserManager<PizzeriaUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;

        public PizzeriaDbInitializer(
            PizzeriaDbContext db,
            UserManager<PizzeriaUser> userManager,
            RoleManager<IdentityRole> roleManager)
        {
            this.db = db;
            this.userManager = userManager;
            this.roleManager = roleManager;
        }

        public void Initialize()
        {
            this.db.Database.Migrate();

            this.AddAdministrator();
        }

        private void AddAdministrator()
            => Task
                .Run(async () =>
                {
                    var existingRole = await this.roleManager.FindByNameAsync(AdministratorRole);

                    if (existingRole != null)
                    {
                        return;
                    }

                    var adminRole = new IdentityRole(AdministratorRole);

                    await this.roleManager.CreateAsync(adminRole);

                    var adminUser = new PizzeriaUser("admin@pizzeria.com");

                    await this.userManager.CreateAsync(adminUser, "admin123456");
                    await this.userManager.AddToRoleAsync(adminUser, AdministratorRole);
                })
                .GetAwaiter()
                .GetResult();
    }
}
