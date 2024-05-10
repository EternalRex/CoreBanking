using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClientService.Domain.Base;

namespace ClientService.Domain.Entity
{
    public class Region : BaseEntity
    {
        public RegionId RegionId { get; private set; }
        public string RegionName { get; private set; }
        public string CountryName { get; private set; }

        public Region()
        {
            RegionId = new(Guid.NewGuid());
            RegionName = string.Empty;
            CountryName = string.Empty;
        }

        public Region Create(string regionName, string countryName)
        {
            RegionId regionId = new(Guid.NewGuid());
            Region region =
                new()
                {
                    RegionId = regionId,
                    RegionName = regionName,
                    CountryName = countryName,
                    DateCreated = DateTime.Now,
                    IsActive = true,
                };
            return region;
        }
    }

    public record RegionId(Guid Value);
}
