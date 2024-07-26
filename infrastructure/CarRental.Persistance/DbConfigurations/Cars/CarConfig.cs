using CarRental.Domain.Entities.Cars;
using CarRental.Persistance.DbConfigurations.Commons;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarRental.Persistance.DbConfigurations.Cars
{
    public class CarConfig :  EfBaseConfigurations<Car>
    {
        public override void Configure(EntityTypeBuilder<Car> builder)
        {

            base.Configure(builder);
            builder.Property(x => x.CarName).IsRequired();
            builder.Property(x => x.Price);


            builder
                .HasOne(x => x.Category )
                .WithMany(x => x.Cars)
                .HasForeignKey(x => x.CategoryId);


            base.Configure(builder);


        }
    }
}
