using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClientService.Domain.Base;

namespace ClientService.Domain.Entity
{
    public class CityMunicipality : BaseEntity
    {
        public CityMunicipalityId CityMunicipalityId { get; private set; }
        public string CityMunicipalityName { get; private set; }
        public string ProvinceName { get; private set; }
        public string RegionName { get; private set; }
        public string CountryName { get; private set; }

        public CityMunicipality()
        {
            CityMunicipalityId = new(Guid.NewGuid());
            CityMunicipalityName = string.Empty;
            ProvinceName = string.Empty;
            RegionName = string.Empty;
            CountryName = string.Empty;
        }

        public CityMunicipality Create(
            string cityMunicipalityName,
            string provinceName,
            string regionName,
            string countryName
        )
        {
            CityMunicipalityId cityMunicipalityId = new(Guid.NewGuid());
            CityMunicipality cityMunicipality =
                new()
                {
                    CityMunicipalityId = cityMunicipalityId,
                    CityMunicipalityName = cityMunicipalityName,
                    ProvinceName = provinceName,
                    RegionName = regionName,
                    CountryName = countryName,
                    DateCreated = DateTime.Now,
                    IsActive = true,
                };
            return cityMunicipality;
        }
    }

    public record CityMunicipalityId(Guid Value);
}
