using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClientService.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClientService.Infrastructure.Data.EntityConfiguration
{
    public class BarangayEntityConfiguration : IEntityTypeConfiguration<Barangay>
    {
        public void Configure(EntityTypeBuilder<Barangay> builder)
        {
            builder.HasKey(pKey => pKey.BarangayId);
            builder
                .Property(prop => prop.BarangayId)
                .HasConversion(id => id.Value, value => new BarangayId(value));

            builder.Property(prop => prop.RegionName).HasColumnType("nvarchar(max)");
            builder.Property(prop => prop.CountryName).HasColumnType("nvarchar(max)");
            builder.Property(prop => prop.ProvinceName).HasColumnType("nvarchar(max)");
            builder.Property(prop => prop.CityMunicipalityName).HasColumnType("nvarchar(max)");
            builder.Property(prop => prop.DateCreated).HasColumnType("datetime2");
            builder.Property(prop => prop.DateDeleted).HasColumnType("datetime2");
            builder.Property(prop => prop.DateDeleted).HasColumnType("datetime2");
        }
    }
}
