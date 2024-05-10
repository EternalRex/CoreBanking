using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClientService.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClientService.Infrastructure.Data.EntityConfiguration
{
    public class ClientSourceEntityConfiguration : IEntityTypeConfiguration<ClientSource>
    {
        public void Configure(EntityTypeBuilder<ClientSource> builder)
        {
            builder.HasKey(prop => prop.ClientSourceId);

            builder
                .Property(prop => prop.ClientSourceId)
                .HasConversion(id => id.Value, value => new ClientSourceId(value));

            builder.Property(prop => prop.ClientSourceName).HasColumnType("nvarchar(max)");
            builder.Property(prop => prop.DateCreated).HasColumnType("datetime2");
            builder.Property(prop => prop.DateDeleted).HasColumnType("datetime2");
            builder.Property(prop => prop.DateDeleted).HasColumnType("datetime2");
        }
    }
}
