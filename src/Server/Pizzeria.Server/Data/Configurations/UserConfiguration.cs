namespace Pizzeria.Server.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Models;

    internal class UserConfiguration : IEntityTypeConfiguration<PizzeriaUser>
    {
        public void Configure(EntityTypeBuilder<PizzeriaUser> builder)
            => builder
                .HasMany(u => u.Orders)
                .WithOne(o => o.User)
                .HasForeignKey(o => o.UserId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);
    }
}
