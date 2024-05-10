using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClientService.Domain.Base;

namespace ClientService.Domain.Entity
{
    public class ClientReference : BaseEntity
    {
        public ClientReferenceId ClientReferenceId { get; private set; }
        public string ClientReferenceName { get; private set; }

        public ClientReference()
        {
            ClientReferenceId = new(Guid.NewGuid());
            ClientReferenceName = string.Empty;
        }

        public ClientReference Create(string referenceName)
        {
            ClientReferenceId referenceId = new(Guid.NewGuid());
            ClientReference reference =
                new()
                {
                    ClientReferenceId = referenceId,
                    ClientReferenceName = referenceName,
                    DateCreated = DateTime.Now,
                    IsActive = true
                };
            return reference;
        }
    }

    public record ClientReferenceId(Guid Value);
}
