using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClientService.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClientService.Infrastructure.Data.EntityConfiguration
{
    public class DependantEntityConfiguration : IEntityTypeConfiguration<Dependant>
    {
        public void Configure(EntityTypeBuilder<Dependant> builder)
        {
            builder.HasKey(pKey => pKey.DependantId);
            builder
                .Property(prop => prop.DependantId)
                .HasConversion(dependantId => dependantId.Value, value => new DependantId(value));

            /*Configuring relationships with Person*/
            builder
                .HasOne(person => person.Person)
                .WithOne()
                .HasForeignKey<Dependant>(fkey => fkey.PersonId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .Property(prop => prop.PersonId)
                .HasConversion(personId => personId.Value, value => new PersonId(value));

            /*Configuring relationships with client*/
            builder
                .HasOne(client => client.Client)
                .WithMany()
                .HasForeignKey(fkey => fkey.ClientId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .Property(prop => prop.ClientId)
                .HasConversion(clientId => clientId.Value, value => new ClientId(value));

            /*Configuring relationships with Business Sector*/
            builder
                .HasOne(sector => sector.BusinessSector)
                .WithMany()
                .HasForeignKey(fKey => fKey.BusinessSectorId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .Property(prop => prop.BusinessSectorId)
                .HasConversion(id => id.Value, value => new BusinessSectorId(value));

            builder.Property(prop => prop.DateCreated).HasColumnType("datetime2");
            builder.Property(prop => prop.DateDeleted).HasColumnType("datetime2");
            builder.Property(prop => prop.DateDeleted).HasColumnType("datetime2");
        }
    }
}
