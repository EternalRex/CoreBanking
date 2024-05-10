using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClientService.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClientService.Infrastructure.Data.EntityConfiguration
{
    public class ProvinceEntityConfiguration : IEntityTypeConfiguration<Province>
    {
        public void Configure(EntityTypeBuilder<Province> builder)
        {
            builder.HasKey(pKey => pKey.ProvinceId);
            builder
                .Property(prop => prop.ProvinceId)
                .HasConversion(id => id.Value, value => new ProvinceId(value));

            builder.Property(prop => prop.ProvinceName).HasColumnType("nvarchar(max)");
            builder.Property(prop => prop.CountryName).HasColumnType("nvarchar(max)");
            builder.Property(prop => prop.RegionName).HasColumnType("nvarchar(max)");
            builder.Property(prop => prop.DateCreated).HasColumnType("datetime2");
            builder.Property(prop => prop.DateDeleted).HasColumnType("datetime2");
            builder.Property(prop => prop.DateDeleted).HasColumnType("datetime2");
        }
    }
}
