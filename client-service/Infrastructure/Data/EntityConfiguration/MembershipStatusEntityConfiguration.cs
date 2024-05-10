using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClientService.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClientService.Infrastructure.Data.EntityConfiguration
{
    public class MembershipStatusEntityConfiguration : IEntityTypeConfiguration<MembershipStatus>
    {
        public void Configure(EntityTypeBuilder<MembershipStatus> builder)
        {
            /*Primary Key Configuration*/
            builder.HasKey(pKey => pKey.MembershipStatusId);

            builder
                .Property(prop => prop.MembershipStatusId)
                .HasConversion(id => id.Value, value => new MembershipStatusId(value));

            builder.Property(prop => prop.MembershipStatusName).HasColumnType("nvarchar(max)");
            builder.Property(prop => prop.DateCreated).HasColumnType("datetime2");
            builder.Property(prop => prop.DateDeleted).HasColumnType("datetime2");
            builder.Property(prop => prop.DateDeleted).HasColumnType("datetime2");
        }
    }
}
