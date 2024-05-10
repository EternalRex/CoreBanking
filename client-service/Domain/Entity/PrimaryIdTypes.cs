using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClientService.Domain.Base;

namespace ClientService.Domain.Entity
{
    public class PrimaryIdentificationType : BaseEntity
    {
        public PrimaryIdentificationTypeId PrimaryIdentificationTypeId { get; private set; }
        public string PrimaryIdentificationTypeName { get; private set; }

        public PrimaryIdentificationType()
        {
            PrimaryIdentificationTypeId = new(Guid.NewGuid());
            PrimaryIdentificationTypeName = string.Empty;
        }

        public PrimaryIdentificationType Create(string primaryIdName)
        {
            PrimaryIdentificationTypeId primaryIdentificationId = new(Guid.NewGuid());
            PrimaryIdentificationType primaryIdentification =
                new()
                {
                    PrimaryIdentificationTypeId = primaryIdentificationId,
                    PrimaryIdentificationTypeName = primaryIdName,
                    DateCreated = DateTime.Now,
                    IsActive = true,
                };
            return primaryIdentification;
        }
    }

    public record PrimaryIdentificationTypeId(Guid Value);
}
