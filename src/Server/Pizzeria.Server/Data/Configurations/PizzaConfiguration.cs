namespace Pizzeria.Server.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Models;

    using static DataConstants.Common;

    internal class PizzaConfiguration : IEntityTypeConfiguration<Pizza>
    {
        public void Configure(EntityTypeBuilder<Pizza> builder)
        {
            builder
                .HasKey(p => p.Id);

            builder
                .Property(p => p.Name)
                .HasMaxLength(MaxNameLength)
                .IsRequired();

            builder
                .Property(p => p.Price)
                .HasPrecision(19, 4)
                .IsRequired();

            builder
                .Property(p => p.ImageUrl)
                .HasMaxLength(MaxUrlLength)
                .IsRequired();

            builder
                .Property(p => p.Description)
                .HasMaxLength(MaxDescriptionLength)
                .IsRequired();
        }
    }
}
