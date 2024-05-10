using System;
using System.Collections.Generic;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClientService.Domain.Entity;

namespace ClientService.Application.Dto.Request
{
    namespace ClientService.Application.Dto.Request
    {
        public class CountryDto
        {
            public int CountryCode { get; set; }
            public string CountryName { get; set; } = string.Empty;
        }

        public class RegionDto
        {
            public int RegionCode { get; set; }
            public int CountryCode { get; set; }
            public string RegionName { get; set; } = string.Empty;
            public string ReginDescription { get; set; } = string.Empty;
        }

        public class ProvinceDto
        {
            public int ProvinceCode { get; set; }
            public int RegionCode { get; set; }
            public string ProvinceName { get; set; } = string.Empty;
        }

        public class MunicipalityDto
        {
            public int MunicipalityCode { get; set; }
            public int ProvinceCode { get; set; }
            public string MunicipalityName { get; set; } = string.Empty;
        }

        public class BarangayDto
        {
            public int BarangayCode { get; set; }
            public int MunicipalityCode { get; set; }
            public string BarangayName { get; set; } = string.Empty;
        }
    }
}
