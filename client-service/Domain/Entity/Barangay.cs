using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClientService.Domain.Base;

namespace ClientService.Domain.Entity
{
    public class Barangay : BaseEntity
    {
        public BarangayId BarangayId { get; private set; }
        public string BarangayName { get; private set; }
        public string CityMunicipalityName { get; private set; }
        public string ProvinceName { get; private set; }
        public string RegionName { get; private set; }
        public string CountryName { get; private set; }

        public Barangay()
        {
            BarangayId = new(Guid.NewGuid());
            BarangayName = string.Empty;
            CityMunicipalityName = string.Empty;
            ProvinceName = string.Empty;
            RegionName = string.Empty;
            CountryName = string.Empty;
        }

        public Barangay Create(
            string barangayName,
            string cityMunicipalityName,
            string provinceName,
            string regionName,
            string countryName
        )
        {
            BarangayId barangayId = new(Guid.NewGuid());
            Barangay barangay =
                new()
                {
                    BarangayId = barangayId,
                    BarangayName = barangayName,
                    CityMunicipalityName = cityMunicipalityName,
                    ProvinceName = provinceName,
                    RegionName = regionName,
                    CountryName = countryName,
                    DateCreated = DateTime.Now,
                    IsActive = true
                };
            return barangay;
        }
    }

    public record BarangayId(Guid Value);
}
