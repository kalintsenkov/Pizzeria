namespace Pizzeria.Server.Data.Configurations
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;
    using Models;

    using static DataConstants.Address;
    using static DataConstants.Common;

    internal class AddressConfiguration : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> address)
        {
            address
                .Property(a => a.City)
                .HasMaxLength(MaxCityLength)
                .IsRequired();

            address
                .Property(a => a.Region)
                .HasMaxLength(MaxRegionLength)
                .IsRequired();

            address
                .Property(a => a.Description)
                .HasMaxLength(MaxDescriptionLength)
                .IsRequired();

            address
                .Property(a => a.PhoneNumber)
                .HasMaxLength(MaxPhoneNumberLength)
                .IsRequired();

            address
                .HasOne(a => a.User)
                .WithMany(u => u.Addresses)
                .HasForeignKey(a => a.UserId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
