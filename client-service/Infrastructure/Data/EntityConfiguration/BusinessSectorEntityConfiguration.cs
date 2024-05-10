using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClientService.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClientService.Infrastructure.Data.EntityConfiguration
{
    public class BusinessSectorEntityConfiguration : IEntityTypeConfiguration<BusinessSector>
    {
        public void Configure(EntityTypeBuilder<BusinessSector> builder)
        {
            builder.HasKey(prop => prop.BusinessSectorId);

            builder
                .Property(prop => prop.BusinessSectorId)
                .HasConversion(id => id.Value, value => new BusinessSectorId(value));

            builder.Property(prop => prop.BusinessSectorName).HasColumnType("nvarchar(max)");
            builder.Property(prop => prop.DateCreated).HasColumnType("datetime2");
            builder.Property(prop => prop.DateDeleted).HasColumnType("datetime2");
            builder.Property(prop => prop.DateDeleted).HasColumnType("datetime2");
        }
    }
}
