using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClientService.Domain.Base;

namespace ClientService.Domain.Entity
{
    public class BusinessSector : BaseEntity
    {
        public BusinessSectorId BusinessSectorId { get; private set; }
        public string BusinessSectorName { get; private set; }

        public BusinessSector()
        {
            BusinessSectorId = new(Guid.NewGuid());
            BusinessSectorName = string.Empty;
        }

        public BusinessSector Create(string businessSectorName)
        {
            BusinessSectorId sectorId = new(Guid.NewGuid());
            BusinessSector sector =
                new()
                {
                    BusinessSectorId = sectorId,
                    BusinessSectorName = businessSectorName,
                    DateCreated = DateTime.Now,
                    IsActive = true,
                };
            return sector;
        }
    }

    public record BusinessSectorId(Guid Value);
}
