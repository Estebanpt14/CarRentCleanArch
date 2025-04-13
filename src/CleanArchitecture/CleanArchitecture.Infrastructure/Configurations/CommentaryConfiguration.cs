using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CleanArchitecture.Domain.Commentaries;
using CleanArchitecture.Domain.Rents;
using CleanArchitecture.Domain.Users;
using CleanArchitecture.Domain.Vehicles;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArchitecture.Infrastructure.Configurations
{
    public class CommentaryConfiguration : IEntityTypeConfiguration<Commentary>
    {
        public void Configure(EntityTypeBuilder<Commentary> builder)
        {
            builder.ToTable("commentaries");
            builder.HasKey(commentary => commentary.Id);

            builder.HasOne<Vehicle>()
                .WithMany()
                .HasForeignKey(rent => rent.VehicleId);
            
            builder.HasOne<User>()
                .WithMany()
                .HasForeignKey(rent => rent.UserId);

            builder.HasOne<Rent>()
                .WithMany()
                .HasForeignKey(rent => rent.RentId);
            
            builder.Property(commentary => commentary.Rating)
                .HasConversion(rating => rating.Value, value => Rating.Create(value).Value);

            builder.Property(commentary => commentary.Value)
                .HasMaxLength(200);
        }
    }
}