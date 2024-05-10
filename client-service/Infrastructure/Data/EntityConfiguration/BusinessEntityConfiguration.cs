using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClientService.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClientService.Infrastructure.Data.EntityConfiguration
{
    public class BusinessEntityConfiguration : IEntityTypeConfiguration<Business>
    {
        public void Configure(EntityTypeBuilder<Business> builder)
        {
            /*Configuring primary key*/
            builder.HasKey(pkey => pkey.BusinessId);
            builder
                .Property(prop => prop.BusinessId)
                .HasConversion(businessId => businessId.Value, value => new BusinessId(value));

            /*Configuring relationships with client*/
            builder
                .HasOne(client => client.MyClient)
                .WithMany()
                .HasForeignKey(fkey => fkey.ClientId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .Property(prop => prop.ClientId)
                .HasConversion(clientId => clientId.Value, value => new ClientId(value));

            /*Configuring relationships with Economic Activity*/
            builder
                .HasOne(activity => activity.EconomicActivity)
                .WithMany()
                .HasForeignKey(fKey => fKey.EconomicActivityId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .Property(prop => prop.EconomicActivityId)
                .HasConversion(id => id.Value, value => new EconomicActivityId(value));

            /*Configuring relationship with Business Nature*/
            builder
                .HasOne(activty => activty.BusinessSector)
                .WithMany()
                .HasForeignKey(fKey => fKey.BusinessSectorId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .Property(prop => prop.BusinessSectorId)
                .HasConversion(id => id.Value, value => new BusinessSectorId(value));

            /*Configuring value objects*/
            builder.OwnsOne(
                prop => prop.BusinessAddress,
                parameter =>
                {
                    parameter.Property(prop => prop.HouseNumber1).HasColumnType("nvarchar(max)");
                    parameter.Property(prop => prop.Street1).HasColumnType("nvarchar(max)");
                    parameter.Property(prop => prop.City1).HasColumnType("nvarchar(max)");
                    parameter.Property(prop => prop.Province1).HasColumnType("nvarchar(max)");
                    parameter.Property(prop => prop.Region1).HasColumnType("nvarchar(max)");
                    parameter.Property(prop => prop.Country1).HasColumnType("nvarchar(max)");
                    parameter.Property(prop => prop.ZipCode1).HasColumnType("nvarchar(max)");
                    parameter.Property(prop => prop.Latitude1).HasColumnType("nvarchar(max)");
                    parameter.Property(prop => prop.Longitude1).HasColumnType("nvarchar(max)");
                }
            );

            builder.OwnsOne(
                prop => prop.BusinessIncome,
                parameter =>
                {
                    parameter.Property(prop => prop.WeeklyIncome).HasColumnType("decimal(18, 2)");
                    parameter.Property(prop => prop.MonthlyIncome).HasColumnType("decimal(18, 2)");
                    parameter
                        .Property(prop => prop.AnnualGrossIncome)
                        .HasColumnType("decimal(18, 2)");
                }
            );

            builder.OwnsOne(
                prop => prop.MicroFinanceEngagement,
                parameter =>
                {
                    parameter.Property(prop => prop.MFIEngagement).HasColumnType("nvarchar(max)");
                    parameter
                        .Property(prop => prop.MFIEngagementName)
                        .HasColumnType("nvarchar(max)");
                }
            );

            /*Other property column type configuration*/
            builder.Property(prop => prop.Name).HasColumnType("nvarchar(max)");
            builder.Property(prop => prop.MobileNumber).HasColumnType("nvarchar(max)");
            builder.Property(prop => prop.LandLineNumber).HasColumnType("nvarchar(max)");
            builder.Property(prop => prop.ExistingCapital).HasColumnType("decimal(18, 2)");
            builder.Property(prop => prop.TotalAssets).HasColumnType("decimal(18, 2)");
            builder.Property(prop => prop.TaxIdentificationNumber).HasColumnType("nvarchar(max)");
            builder.Property(prop => prop.BusinessPermitNumber).HasColumnType("nvarchar(max)");
            builder.Property(prop => prop.DateCreated).HasColumnType("datetime2");
            builder.Property(prop => prop.DateDeleted).HasColumnType("datetime2");
            builder.Property(prop => prop.DateDeleted).HasColumnType("datetime2");
        }
    }
}
