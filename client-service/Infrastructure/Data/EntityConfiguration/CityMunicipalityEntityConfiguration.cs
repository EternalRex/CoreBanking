using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClientService.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClientService.Infrastructure.Data.EntityConfiguration
{
    public class CityMunicipalityEntityConfiguration : IEntityTypeConfiguration<CityMunicipality>
    {
        public void Configure(EntityTypeBuilder<CityMunicipality> builder)
        {
            builder.HasKey(pKey => pKey.CityMunicipalityId);
            builder
                .Property(prop => prop.CityMunicipalityId)
                .HasConversion(id => id.Value, value => new CityMunicipalityId(value));

            builder.Property(prop => prop.RegionName).HasColumnType("nvarchar(max)");
            builder.Property(prop => prop.CountryName).HasColumnType("nvarchar(max)");
            builder.Property(prop => prop.ProvinceName).HasColumnType("nvarchar(max)");
        }
    }
}
