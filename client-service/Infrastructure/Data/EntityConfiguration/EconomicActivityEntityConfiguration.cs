using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClientService.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClientService.Infrastructure.Data.EntityConfiguration
{
    public class EconomicActivityEntityConfiguration : IEntityTypeConfiguration<EconomicActivity>
    {
        public void Configure(EntityTypeBuilder<EconomicActivity> builder)
        {
            /*Primary Key configuration*/
            builder.HasKey(pKey => pKey.EconomicActivityId);

            builder
                .Property(prop => prop.EconomicActivityId)
                .HasConversion(id => id.Value, value => new EconomicActivityId(value));

            builder.Property(prop => prop.EconomicActivityName).HasColumnType("nvarchar(max)");
            builder.Property(prop => prop.DateCreated).HasColumnType("datetime2");
            builder.Property(prop => prop.DateDeleted).HasColumnType("datetime2");
            builder.Property(prop => prop.DateDeleted).HasColumnType("datetime2");
        }
    }
}
