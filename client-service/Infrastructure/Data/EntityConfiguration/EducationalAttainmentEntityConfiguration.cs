using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClientService.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClientService.Infrastructure.Data.EntityConfiguration
{
    public class EducationalAttainmentEntityConfiguration
        : IEntityTypeConfiguration<EducationalAttainment>
    {
        public void Configure(EntityTypeBuilder<EducationalAttainment> builder)
        {
            /*Primary Key configuration*/
            builder.HasKey(pKey => pKey.EducationalAttainmentId);

            builder
                .Property(prop => prop.EducationalAttainmentId)
                .HasConversion(id => id.Value, value => new EducationalAttainmentId(value));

            builder.Property(prop => prop.EducationalAttainmentName).HasColumnType("nvarchar(max)");
            builder.Property(prop => prop.DateCreated).HasColumnType("datetime2");
            builder.Property(prop => prop.DateDeleted).HasColumnType("datetime2");
            builder.Property(prop => prop.DateDeleted).HasColumnType("datetime2");
        }
    }
}
