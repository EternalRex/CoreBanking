using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClientService.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClientService.Infrastructure.Data.EntityConfiguration
{
    public class PrimaryIdTypeEntityConfiguration
        : IEntityTypeConfiguration<PrimaryIdentificationType>
    {
        public void Configure(EntityTypeBuilder<PrimaryIdentificationType> builder)
        {
            /*Primary Key Configuration with GUID Conversion*/
            builder.HasKey(pKey => pKey.PrimaryIdentificationTypeId);

            builder
                .Property(prop => prop.PrimaryIdentificationTypeId)
                .HasConversion(
                    primaryId => primaryId.Value,
                    value => new PrimaryIdentificationTypeId(value)
                );

            builder
                .Property(prop => prop.PrimaryIdentificationTypeName)
                .HasColumnType("nvarchar(max)");
            builder.Property(prop => prop.DateCreated).HasColumnType("datetime2");
            builder.Property(prop => prop.DateDeleted).HasColumnType("datetime2");
            builder.Property(prop => prop.DateDeleted).HasColumnType("datetime2");
        }
    }
}
