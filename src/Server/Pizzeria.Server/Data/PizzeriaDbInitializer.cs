namespace Pizzeria.Server.Data
{
    using Common;
    using Microsoft.EntityFrameworkCore;

    public class PizzeriaDbInitializer : IInitializer
    {
        private readonly PizzeriaDbContext db;

        public PizzeriaDbInitializer(PizzeriaDbContext db) => this.db = db;

        public void Initialize() => this.db.Database.Migrate();
    }
}
