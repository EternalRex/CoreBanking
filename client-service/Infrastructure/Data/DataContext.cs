using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClientService.Domain.Entity;
using ClientService.Infrastructure.Data.EntityConfiguration;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClientService.Infrastructure.Data
{
    public class DataContext : DbContext
    {
        private readonly IConfiguration _configuration;

        public DataContext(DbContextOptions<DataContext> options, IConfiguration configuration)
            : base(options)
        {
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            /*When deployed, this conection string will be triggered*/
            string connectionString = Environment.GetEnvironmentVariable(
                "ConnectionStrings__DefaultConnection"
            )!;

            /*If run locally, this local connection string will be triggered*/
            if (connectionString == null)
            {
                connectionString = _configuration.GetConnectionString("LocalDBConnection")!;
            }

            optionsBuilder.UseSqlServer(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            /*Applying entity configuration*/
            modelBuilder.ApplyConfiguration(new PersonEntityConfiguration());
            modelBuilder.ApplyConfiguration(new ClientEntityConfiguration());
            modelBuilder.ApplyConfiguration(new PrimaryIdTypeEntityConfiguration());
            modelBuilder.ApplyConfiguration(new EconomicActivityEntityConfiguration());
            modelBuilder.ApplyConfiguration(new OccupationEntityConfiguration());
            modelBuilder.ApplyConfiguration(new MembershipStatusEntityConfiguration());
            modelBuilder.ApplyConfiguration(new ClientSourceEntityConfiguration());
            modelBuilder.ApplyConfiguration(new ClientReferenceEntityConfiguration());
            modelBuilder.ApplyConfiguration(new MembershipTypeEntityConfiguration());
            modelBuilder.ApplyConfiguration(new ReligionEntityConfiguration());
            modelBuilder.ApplyConfiguration(new EducationalAttainmentEntityConfiguration());
            modelBuilder.ApplyConfiguration(new NationalityEntityConfiguration());
            modelBuilder.ApplyConfiguration(new BusinessEntityConfiguration());
            modelBuilder.ApplyConfiguration(new BusinessSectorEntityConfiguration());
            modelBuilder.ApplyConfiguration(new SpouseEntityConfiguration());
            modelBuilder.ApplyConfiguration(new DependantEntityConfiguration());
            modelBuilder.ApplyConfiguration(new DocumentEntityConfiguration());
            modelBuilder.ApplyConfiguration(new CountryEntityConfiguration());
            modelBuilder.ApplyConfiguration(new RegionEntityConfiguration());
            modelBuilder.ApplyConfiguration(new ProvinceEntityConfiguration());
            modelBuilder.ApplyConfiguration(new CityMunicipalityEntityConfiguration());
            modelBuilder.ApplyConfiguration(new BarangayEntityConfiguration());
        }

        public DbSet<Person> Person { get; set; }
        public DbSet<Client> Client { get; set; }
        public DbSet<Business> Business { get; set; }
        public DbSet<Spouse> Spouse { get; set; }
        public DbSet<Dependant> Dependant { get; set; }
        public DbSet<Document> Document { get; set; }
        public DbSet<BusinessSector> BusinessSectorMasterFile { get; set; }
        public DbSet<PrimaryIdentificationType> PrimaryIdentificationTypeMasterFile { get; set; }
        public DbSet<EconomicActivity> EconomicActivityMasterFile { get; set; }
        public DbSet<Occupation> OccupationMasterFile { get; set; }
        public DbSet<MembershipStatus> MembershipStatusMasterFile { get; set; }
        public DbSet<EducationalAttainment> EducationalAttainmentMasterFile { get; set; }
        public DbSet<ClientSource> ClientSourceMasterFile { get; set; }
        public DbSet<ClientReference> ClientReferenceMasterFile { get; set; }
        public DbSet<MembershipType> MembershipTypeMasterFile { get; set; }
        public DbSet<Religion> ReligionMasterFile { get; set; }
        public DbSet<Nationality> NationalityMasterFile { get; set; }
        public DbSet<Country> CountryMasterFile { get; set; }
        public DbSet<Region> RegionMasterFile { get; set; }
        public DbSet<Province> ProvinceMasterFile { get; set; }
        public DbSet<CityMunicipality> CityMunicipalityMasterFile { get; set; }
        public DbSet<Barangay> BarangayMasterFile { get; set; }
    }
}
