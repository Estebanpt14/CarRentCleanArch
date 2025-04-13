using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CleanArchitecture.Domain.Rents;
using CleanArchitecture.Domain.Shared;
using CleanArchitecture.Domain.Users;
using CleanArchitecture.Domain.Vehicles;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArchitecture.Infrastructure.Configurations
{
    internal sealed class RentConfiguration : IEntityTypeConfiguration<Rent>
    {
        public void Configure(EntityTypeBuilder<Rent> builder)
        {
            builder.ToTable("rents");
            builder.HasKey(rent => rent.Id);

            builder.OwnsOne(rent => rent.PricePerPeriod, priceBuilder => {
                    priceBuilder.Property(coin => coin.Type)
                        .HasConversion(typeCoin => typeCoin.Code, code => CoinType.FromCode(code!));
            });

            builder.OwnsOne(rent => rent.Maintenance, priceBuilder => {
                    priceBuilder.Property(coin => coin.Type)
                        .HasConversion(typeCoin => typeCoin.Code, code => CoinType.FromCode(code!));
            });

            builder.OwnsOne(rent => rent.Accesories, priceBuilder => {
                    priceBuilder.Property(coin => coin.Type)
                        .HasConversion(typeCoin => typeCoin.Code, code => CoinType.FromCode(code!));
            });

            builder.OwnsOne(rent => rent.Total, priceBuilder => {
                    priceBuilder.Property(coin => coin.Type)
                        .HasConversion(typeCoin => typeCoin.Code, code => CoinType.FromCode(code!));
            });
            
            builder.OwnsOne(rent => rent.Duration);

            builder.HasOne<Vehicle>()
                .WithMany()
                .HasForeignKey(rent => rent.VehicleId);
            
            builder.HasOne<User>()
                .WithMany()
                .HasForeignKey(rent => rent.UserId);
        }
    }
}