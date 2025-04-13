using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CleanArchitecture.Domain.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArchitecture.Infrastructure.Configurations
{
    internal sealed class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("users");
            builder.HasKey(user => user.Id);

            builder.OwnsOne(user => user.FullName);

            builder.Property(user => user.Email)
                .HasMaxLength(400)
                .HasConversion(email => email!.Value, value => new Domain.Users.Email(value));

            builder.HasIndex(user => user.Email).IsUnique();
        }
    }
}