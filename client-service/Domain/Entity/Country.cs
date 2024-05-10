using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClientService.Domain.Base;

namespace ClientService.Domain.Entity
{
    public class Country : BaseEntity
    {
        public CountryId CountryId { get; private set; }
        public string CountryName { get; private set; }

        public Country()
        {
            CountryId = new(Guid.NewGuid());
            CountryName = string.Empty;
        }

        public Country Create(string countryName)
        {
            CountryId countryId = new(Guid.NewGuid());
            Country country =
                new()
                {
                    CountryId = countryId,
                    CountryName = countryName,
                    DateCreated = DateTime.Now,
                    IsActive = true
                };
            return country;
        }
    }

    public record CountryId(Guid Value);
}
