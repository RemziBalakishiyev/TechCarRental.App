using CarRental.Domain.Entities.Accounts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarRental.Persistance.DbConfigurations.Accounts;

public class UserConfig : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasKey(x => x.Id);
        builder.HasIndex(x=>x.Email)
            .IsUnique();
        builder.Property(x=>x.Email).IsRequired();


        builder.HasMany(x => x.UserRoles).WithOne(x => x.User).HasForeignKey(x => x.UserId);
        builder.HasOne(x => x.UserDetail).WithOne(x => x.User).HasForeignKey<UserDetail>(x => x.UserId);

    }
}
