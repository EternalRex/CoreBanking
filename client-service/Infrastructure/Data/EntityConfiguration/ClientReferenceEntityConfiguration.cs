using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.Xml;
using System.Threading.Tasks;
using ClientService.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClientService.Infrastructure.Data.EntityConfiguration
{
    public class ClientReferenceEntityConfiguration : IEntityTypeConfiguration<ClientReference>
    {
        public void Configure(EntityTypeBuilder<ClientReference> builder)
        {
            /*Primary key configuration*/
            builder.HasKey(pKey => pKey.ClientReferenceId);

            builder
                .Property(prop => prop.ClientReferenceId)
                .HasConversion(id => id.Value, value => new ClientReferenceId(value));

            builder.Property(prop => prop.ClientReferenceName).HasColumnType("nvarchar(max)");
            builder.Property(prop => prop.DateCreated).HasColumnType("datetime2");
            builder.Property(prop => prop.DateDeleted).HasColumnType("datetime2");
            builder.Property(prop => prop.DateDeleted).HasColumnType("datetime2");
        }
    }
}
