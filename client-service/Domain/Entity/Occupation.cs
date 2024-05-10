using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClientService.Domain.Base;

namespace ClientService.Domain.Entity
{
    public class Occupation : BaseEntity
    {
        public OccupationId OccupationId { get; private set; }
        public string OccupationName { get; private set; }

        public Occupation()
        {
            OccupationId = new(Guid.NewGuid());
            OccupationName = string.Empty;
        }

        public Occupation Create(string occupationName)
        {
            OccupationId occupationId = new(Guid.NewGuid());

            Occupation occupation =
                new()
                {
                    OccupationId = occupationId,
                    OccupationName = occupationName,
                    DateCreated = DateTime.Now,
                    IsActive = true
                };

            return occupation;
        }
    }

    public record OccupationId(Guid Value);
}
