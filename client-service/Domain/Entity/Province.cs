using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClientService.Domain.Base;

namespace ClientService.Domain.Entity
{
    public class Province : BaseEntity
    {
        public ProvinceId ProvinceId { get; private set; }
        public string ProvinceName { get; private set; }
        public string RegionName { get; private set; }
        public string CountryName { get; private set; }

        public Province()
        {
            ProvinceId = new(Guid.NewGuid());
            ProvinceName = string.Empty;
            RegionName = string.Empty;
            CountryName = string.Empty;
            DateCreated = DateTime.Now;
            IsActive = true;
        }

        public Province Create(string provinceName, string regionName, string countryName)
        {
            ProvinceId provinceId = new(Guid.NewGuid());
            Province province =
                new()
                {
                    ProvinceId = provinceId,
                    ProvinceName = provinceName,
                    RegionName = regionName,
                    CountryName = countryName,
                    DateCreated = DateTime.Now,
                    IsActive = true,
                };

            return province;
        }
    }

    public record ProvinceId(Guid Value);
}
