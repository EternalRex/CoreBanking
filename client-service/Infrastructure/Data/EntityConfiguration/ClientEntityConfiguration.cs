using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClientService.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClientService.Infrastructure.Data.EntityConfiguration
{
    public class ClientEntityConfiguration : IEntityTypeConfiguration<Client>
    {
        public void Configure(EntityTypeBuilder<Client> builder)
        {
            /*Configuring primary key*/
            builder.HasKey(pKey => pKey.ClientId);
            builder
                .Property(prop => prop.ClientId)
                .HasConversion(clientid => clientid.Value, value => new ClientId(value));

            /*Configuring relationship with Person*/
            builder
                .HasOne(person => person.Person)
                .WithOne()
                .HasForeignKey<Client>(fkey => fkey.PersonId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .Property(prop => prop.PersonId)
                .HasConversion(personId => personId.Value, value => new PersonId(value));

            /*Configuring relationship with Primary Id Type Master File*/
            builder
                .HasOne(primaryId => primaryId.PrimaryIdentification)
                .WithMany()
                .HasForeignKey(fKey => fKey.PrimaryIdentificationTypeId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .Property(prop => prop.PrimaryIdentificationTypeId)
                .HasConversion(id => id.Value, value => new PrimaryIdentificationTypeId(value));

            /*Configuring relationship with EconomicActivity Master File*/
            builder
                .HasOne(activity => activity.EconomicActivity)
                .WithMany()
                .HasForeignKey(fKey => fKey.EconomicActivityId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .Property(prop => prop.EconomicActivityId)
                .HasConversion(id => id.Value, value => new EconomicActivityId(value));

            /*Configuring relationship with Occupation Master File*/
            builder
                .HasOne(occupation => occupation.Occupation)
                .WithMany()
                .HasForeignKey(fKey => fKey.OccupationId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .Property(prop => prop.OccupationId)
                .HasConversion(id => id.Value, value => new OccupationId(value));

            /*Configuring relationship with Membership Status Master File*/
            builder
                .HasOne(status => status.MembershipStatus)
                .WithMany()
                .HasForeignKey(fKey => fKey.MembershipStatusId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .Property(prop => prop.MembershipStatusId)
                .HasConversion(id => id.Value, value => new MembershipStatusId(value));

            /*Configuring relationship with Client Source Master File*/
            builder
                .HasOne(source => source.ClientSource)
                .WithMany()
                .HasForeignKey(fKey => fKey.ClientSourceId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .Property(prop => prop.ClientSourceId)
                .HasConversion(id => id.Value, value => new ClientSourceId(value));

            /*Configuring relationship with Client Reference Master File*/
            builder
                .HasOne(reference => reference.ClientReference)
                .WithMany()
                .HasForeignKey(fKey => fKey.ReferenceId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .Property(prop => prop.ReferenceId)
                .HasConversion(id => id.Value, value => new ClientReferenceId(value));

            /*Configuring relationship with Client Membership Type Master File*/
            builder
                .HasOne(reference => reference.MembershipType)
                .WithMany()
                .HasForeignKey(fKey => fKey.MembershipTypeId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .Property(prop => prop.MembershipTypeId)
                .HasConversion(id => id.Value, value => new MembershipTypeId(value));

            /*Configuring reference fields from branch service*/
            builder
                .Property(prop => prop.BranchId)
                .HasConversion(branchId => branchId.Value, value => new BranchId(value));

            builder
                .Property(prop => prop.CenterId)
                .HasConversion(centerId => centerId.Value, value => new CenterId(value));

            builder
                .Property(prop => prop.BranchOfficerId)
                .HasConversion(officerId => officerId.Value, value => new BranchOfficer(value));

            /*Configuring value object*/
            builder.OwnsOne(
                prop => prop.AdditionalInformation,
                parameter =>
                {
                    parameter.Property(prop => prop.Bank).HasColumnType("nvarchar(max)");
                    parameter
                        .Property(prop => prop.BankAccountNumber)
                        .HasColumnType("nvarchar(max)");
                    parameter.Property(prop => prop.Notes).HasColumnType("nvarchar(max)");
                }
            );

            /*Configuring other properties' column type*/
            builder
                .Property(prop => prop.PrimaryIdentificationTypeNumber)
                .HasColumnType("nvarchar(max)");
            builder
                .Property(prop => prop.PrimaryIdentificationTypeExpiration)
                .HasColumnType("datetime2");
            builder.Property(prop => prop.DateCreated).HasColumnType("datetime2");
            builder.Property(prop => prop.DateDeleted).HasColumnType("datetime2");
            builder.Property(prop => prop.DateDeleted).HasColumnType("datetime2");
        }
    }
}
