using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClientService.Domain.Base;

namespace ClientService.Domain.Entity
{
    public class ClientSource : BaseEntity
    {
        public ClientSourceId ClientSourceId { get; private set; }
        public string ClientSourceName { get; private set; }

        public ClientSource()
        {
            ClientSourceId = new(Guid.NewGuid());
            ClientSourceName = string.Empty;
        }

        public ClientSource Create(string clientSourceName)
        {
            ClientSourceId clientSourceId = new(Guid.NewGuid());

            ClientSource clientSource =
                new()
                {
                    ClientSourceId = clientSourceId,
                    ClientSourceName = clientSourceName,
                    DateCreated = DateTime.Now,
                    IsActive = true
                };

            return clientSource;
        }
    }

    public record ClientSourceId(Guid Value);
}
