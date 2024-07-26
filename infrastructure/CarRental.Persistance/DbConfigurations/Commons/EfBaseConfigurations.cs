using CarRental.Domain.Entities.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarRental.Persistance.DbConfigurations.Commons
{
    public class EfBaseConfigurations<T> : IEntityTypeConfiguration<T>
        where T : BaseEntity
    {
        public virtual void Configure(EntityTypeBuilder<T> builder)
        {
            builder.HasKey(k => k.Id);

            builder.Property(p => p.Id).HasColumnName("Id").UseIdentityColumn();
            builder.Property(p => p.CreatedDate).HasColumnName("CreatedDateTime").IsRequired();
            builder.Property(p => p.UpdatedDate).HasColumnName("UpdatedDateTime");
            builder.Property(p => p.CreatedId).HasColumnName("CreatedId");
            builder.Property(p => p.UpdatedId).HasColumnName("UpdatedId");
        }
    }
}
