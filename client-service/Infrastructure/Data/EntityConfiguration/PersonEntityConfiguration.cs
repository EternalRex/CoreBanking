using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClientService.Domain.Entity;
using Google.Protobuf.WellKnownTypes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ClientService.Infrastructure.Data.EntityConfiguration
{
    public class PersonEntityConfiguration : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {
            /*Configuring primary key*/
            builder.HasKey(pKey => pKey.PersonId);
            builder
                .Property(property => property.PersonId)
                .HasConversion(personId => personId.Value, value => new PersonId(value));

            /*Configuring relationship with Religion*/
            builder
                .HasOne(religion => religion.ClientReligion)
                .WithMany()
                .HasForeignKey(fkey => fkey.ReligionId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .Property(prop => prop.ReligionId)
                .HasConversion(religionId => religionId.Value, value => new ReligionId(value));

            /*Configuring relationship with Educational Attainment*/
            builder
                .HasOne(qualification => qualification.EducationalAttainment)
                .WithMany()
                .HasForeignKey(fKey => fKey.EducationalAttainmentId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .Property(prop => prop.EducationalAttainmentId)
                .HasConversion(id => id.Value, value => new EducationalAttainmentId(value));

            /*Configuring relationships with Nationality*/
            builder
                .HasOne(nationality => nationality.Nationality)
                .WithMany()
                .HasForeignKey(fKey => fKey.NationalityId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .Property(prop => prop.NationalityId)
                .HasConversion(id => id.Value, value => new NationalityId(value));

            /*Configuring value objects*/
            builder.OwnsOne(
                address => address.PersonAddress,
                parameters =>
                {
                    parameters.Property(prop => prop.HouseNumber1).HasColumnType("nvarchar(max)");
                    parameters.Property(prop => prop.Street1).HasColumnType("nvarchar(max)");
                    parameters.Property(prop => prop.City1).HasColumnType("nvarchar(max)");
                    parameters.Property(prop => prop.Province1).HasColumnType("nvarchar(max)");
                    parameters.Property(prop => prop.Region1).HasColumnType("nvarchar(max)");
                    parameters.Property(prop => prop.Country1).HasColumnType("nvarchar(max)");
                    parameters.Property(prop => prop.ZipCode1).HasColumnType("nvarchar(max)");
                    parameters.Property(prop => prop.Longitude1).HasColumnType("nvarchar(max)");
                    parameters.Property(prop => prop.Latitude1).HasColumnType("nvarchar(max)");
                    parameters.Property(prop => prop.HomeOwnership1).HasColumnType("nvarchar(max)");

                    parameters.Property(prop => prop.HouseNumber2).HasColumnType("nvarchar(max)");
                    parameters.Property(prop => prop.Street2).HasColumnType("nvarchar(max)");
                    parameters.Property(prop => prop.City2).HasColumnType("nvarchar(max)");
                    parameters.Property(prop => prop.Province2).HasColumnType("nvarchar(max)");
                    parameters.Property(prop => prop.Region2).HasColumnType("nvarchar(max)");
                    parameters.Property(prop => prop.Country2).HasColumnType("nvarchar(max)");
                    parameters.Property(prop => prop.ZipCode2).HasColumnType("nvarchar(max)");
                    parameters.Property(prop => prop.Longitude2).HasColumnType("nvarchar(max)");
                    parameters.Property(prop => prop.Latitude2).HasColumnType("nvarchar(max)");
                    parameters.Property(prop => prop.HomeOwnership2).HasColumnType("nvarchar(max)");
                }
            );

            builder.OwnsOne(
                contact => contact.ContactDetails,
                parameters =>
                {
                    parameters.Property(prop => prop.MobileNumber).HasColumnType("nvarchar(max)");
                    parameters.Property(prop => prop.EmailAddress).HasColumnType("nvarchar(max)");
                    parameters
                        .Property(prop => prop.ContactPersonName)
                        .HasColumnType("nvarchar(max)");
                    parameters
                        .Property(prop => prop.ContactPersonMobileNumber)
                        .HasColumnType("nvarchar(max)");
                }
            );

            /*Configure enum properties so that enum display name will be saved in the database */
            builder
                .Property(prop => prop.Salutation)
                .HasConversion<string>()
                .HasColumnType("nvarchar(max)");
            builder
                .Property(prop => prop.Gender)
                .HasConversion<string>()
                .HasColumnType("nvarchar(max)");

            builder
                .Property(prop => prop.MaritalStatus)
                .HasConversion<string>()
                .HasColumnType("nvarchar(max)");

            var converter = new ValueConverter<Timestamp, DateTime>(
                v => v.ToDateTime(),
                v => Timestamp.FromDateTime(v)
            );

            /*Configuring other properties column type*/
            builder.Property(prop => prop.FirstName).HasColumnType("nvarchar(max)");
            builder.Property(prop => prop.LastName).HasColumnType("nvarchar(max)");
            builder.Property(prop => prop.MiddleName).HasColumnType("nvarchar(max)");
            builder.Property(prop => prop.Suffix).HasColumnType("nvarchar(max)");
            builder.Property(prop => prop.Gender).HasColumnType("nvarchar(max)");
            builder.Property(prop => prop.Suffix).HasColumnType("nvarchar(max)");
            builder
                .Property(prop => prop.DateOfBirth)
                .HasConversion(converter)
                .HasColumnType("datetime2");
            builder.Property(prop => prop.DateCreated).HasColumnType("datetime2");
            builder.Property(prop => prop.DateDeleted).HasColumnType("datetime2");
            builder.Property(prop => prop.DateDeleted).HasColumnType("datetime2");
            builder.Property(prop => prop.PlaceOfBirth).HasColumnType("nvarchar(max)");
            builder.Property(prop => prop.MotherMaidenName).HasColumnType("nvarchar(max)");
            builder
                .Property(prop => prop.TaxPayerIdentificationNumber)
                .HasColumnType("nvarchar(max)");
        }
    }
}
