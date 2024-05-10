using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClientService.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClientService.Infrastructure.Data.EntityConfiguration
{
    public class MembershipTypeEntityConfiguration : IEntityTypeConfiguration<MembershipType>
    {
        public void Configure(EntityTypeBuilder<MembershipType> builder)
        {
            builder.HasKey(pKey => pKey.MembershipTypeId);

            builder
                .Property(prop => prop.MembershipTypeId)
                .HasConversion(id => id.Value, value => new MembershipTypeId(value));

            builder.Property(prop => prop.MembershipTypeName).HasColumnType("nvarchar(max)");
            builder.Property(prop => prop.DateCreated).HasColumnType("datetime2");
            builder.Property(prop => prop.DateDeleted).HasColumnType("datetime2");
            builder.Property(prop => prop.DateDeleted).HasColumnType("datetime2");
        }
    }
}
