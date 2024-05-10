using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClientService.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClientService.Infrastructure.Data.EntityConfiguration
{
    public class DocumentEntityConfiguration : IEntityTypeConfiguration<Document>
    {
        public void Configure(EntityTypeBuilder<Document> builder)
        {
            /*Configuring primary key*/
            builder.HasKey(pKey => pKey.DocumentId);
            builder
                .Property(prop => prop.DocumentId)
                .HasConversion(id => id.Value, value => new DocumentId(value));

            /*Configuring foreign key*/
            builder
                .HasOne(client => client.Client)
                .WithMany()
                .HasForeignKey(fKey => fKey.ClientId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .Property(prop => prop.ClientId)
                .HasConversion(id => id!.Value, value => new ClientId(value));

            /*Configuring foreign key*/
            builder
                .HasOne(spouse => spouse.Spouse)
                .WithMany()
                .HasForeignKey(fKey => fKey.SpouseId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .Property(prop => prop.SpouseId)
                .HasConversion(id => id!.Value, value => new SpouseId(value));

            /*Configuring foreign key*/
            builder
                .HasOne(dependant => dependant.Dependant)
                .WithMany()
                .HasForeignKey(fKey => fKey.DependantId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .Property(prop => prop.DependantId)
                .HasConversion(id => id!.Value, value => new DependantId(value));

            /*Configuring other property columns*/
            builder.Property(prop => prop.DocumentName).HasColumnType("nvarchar(max)");
            builder.Property(prop => prop.DocumentType).HasColumnType("nvarchar(max)");
            builder.Property(prop => prop.DocumentPath).HasColumnType("nvarchar(max)");
            builder.Property(prop => prop.DocumentExtension).HasColumnType("nvarchar(max)");
            builder.Property(prop => prop.DateCreated).HasColumnType("datetime2");
            builder.Property(prop => prop.DateDeleted).HasColumnType("datetime2");
            builder.Property(prop => prop.DateDeleted).HasColumnType("datetime2");
        }
    }
}
