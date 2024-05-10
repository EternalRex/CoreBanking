using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClientService.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClientService.Infrastructure.Data.EntityConfiguration
{
    public class SpouseEntityConfiguration : IEntityTypeConfiguration<Spouse>
    {
        public void Configure(EntityTypeBuilder<Spouse> builder)
        {
            /*Configuring primary key*/
            builder.HasKey(pKey => pKey.SpouseId);
            builder
                .Property(prop => prop.SpouseId)
                .HasConversion(clientid => clientid.Value, value => new SpouseId(value));

            /*Configuring relationship with Person*/
            builder
                .HasOne(person => person.Person)
                .WithOne()
                .HasForeignKey<Spouse>(fkey => fkey.PersonId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .Property(prop => prop.PersonId)
                .HasConversion(personId => personId.Value, value => new PersonId(value));

            /*Configuring relationship with Client*/
            builder
                .HasOne(client => client.Client)
                .WithMany()
                .HasForeignKey(fkey => fkey.ClientId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .Property(prop => prop.ClientId)
                .HasConversion(personId => personId.Value, value => new ClientId(value));

            /*Configuring relationship with Business Sector*/
            builder
                .HasOne(sector => sector.BusinessSector)
                .WithMany()
                .HasForeignKey(fkey => fkey.BusinessSectorId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .Property(prop => prop.BusinessSectorId)
                .HasConversion(personId => personId.Value, value => new BusinessSectorId(value));

            /*Configuring relationship with Occupation*/
            builder
                .HasOne(occupation => occupation.Occupation)
                .WithMany()
                .HasForeignKey(fkey => fkey.OccupationId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .Property(prop => prop.OccupationId)
                .HasConversion(personId => personId.Value, value => new OccupationId(value));

            /*Configuring column types of other properties*/
            builder.Property(prop => prop.EmployerName).HasColumnType("nvarchar(max)");
            builder.Property(prop => prop.MonthlyIncome).HasColumnType("decimal(18, 2)");
        }
    }
}
