namespace Pizzeria.Server.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Models;

    internal class OrderPizzaConfiguration : IEntityTypeConfiguration<OrderPizza>
    {
        public void Configure(EntityTypeBuilder<OrderPizza> builder)
        {
            builder
                .HasKey(op => new { op.OrderId, op.PizzaId });

            builder
                .HasOne(op => op.Order)
                .WithMany(o => o.Pizzas)
                .HasForeignKey(op => op.OrderId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(op => op.Pizza)
                .WithMany(p => p.Orders)
                .HasForeignKey(op => op.PizzaId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
