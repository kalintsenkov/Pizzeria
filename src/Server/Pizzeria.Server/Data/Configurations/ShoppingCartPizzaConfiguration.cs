namespace Pizzeria.Server.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Models;

    public class ShoppingCartPizzaConfiguration : IEntityTypeConfiguration<ShoppingCartPizza>
    {
        public void Configure(EntityTypeBuilder<ShoppingCartPizza> builder)
        {
            builder
                .HasKey(op => new { op.ShoppingCartId, op.PizzaId });

            builder
                .HasOne(op => op.ShoppingCart)
                .WithMany(o => o.Pizzas)
                .HasForeignKey(op => op.ShoppingCartId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(op => op.Pizza)
                .WithMany(p => p.ShoppingCarts)
                .HasForeignKey(op => op.PizzaId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
