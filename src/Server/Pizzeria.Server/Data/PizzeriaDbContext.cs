namespace Pizzeria.Server.Data
{
    using System;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using Common;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    using Models;

    public class PizzeriaDbContext : IdentityDbContext<PizzeriaUser>
    {
        public PizzeriaDbContext(DbContextOptions<PizzeriaDbContext> options)
            : base(options)
        {
        }

        public DbSet<Pizza> Pizzas { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<OrderPizza> OrdersPizzas { get; set; }

        public DbSet<ShoppingCart> ShoppingCarts { get; set; }

        public DbSet<ShoppingCartPizza> ShoppingCartsPizzas { get; set; }

        public override int SaveChanges()
        {
            this.ApplyAuditInformation();
            this.ApplyDeletableEntity();

            return base.SaveChanges();
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new())
        {
            this.ApplyAuditInformation();
            this.ApplyDeletableEntity();

            return base.SaveChangesAsync(cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);
        }

        private void ApplyAuditInformation()
            => this.ChangeTracker
                .Entries()
                .Where(e =>
                    e.Entity is IEntity &&
                    (e.State == EntityState.Added ||
                     e.State == EntityState.Modified))
                .ToList()
                .ForEach(entry =>
                {
                    var entity = (IEntity)entry.Entity;

                    if (entry.State == EntityState.Added)
                    {
                        entity.CreatedOn = DateTime.UtcNow;
                    }
                    else
                    {
                        entity.ModifiedOn = DateTime.UtcNow;
                    }
                });

        private void ApplyDeletableEntity()
            => this.ChangeTracker
                .Entries()
                .Where(e =>
                    e.Entity is IDeletableEntity &&
                    e.State == EntityState.Deleted)
                .ToList()
                .ForEach(entry =>
                {
                    var entity = (IDeletableEntity)entry.Entity;

                    entity.IsDeleted = true;
                    entity.DeletedOn = DateTime.UtcNow;
                    entry.State = EntityState.Modified;
                });

    }
}
