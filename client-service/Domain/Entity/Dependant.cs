using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClientService.Domain.Base;

namespace ClientService.Domain.Entity
{
    public class Dependant : BaseEntity
    {
        public DependantId DependantId { get; private set; }

        /*Foreign Keys*/
        public PersonId PersonId { get; private set; }
        public ClientId ClientId { get; private set; }
        public BusinessSectorId BusinessSectorId { get; private set; }

        /*Navigators*/
        public Person? Person { get; private set; }
        public Client? Client { get; private set; }
        public BusinessSector? BusinessSector { get; private set; }

        public Dependant()
        {
            DependantId = new(Guid.NewGuid());
            PersonId = new PersonId(Guid.NewGuid());
            ClientId = new ClientId(Guid.NewGuid());
            BusinessSectorId = new(Guid.NewGuid());
        }

        public Dependant Create(
            PersonId personId,
            ClientId clientId,
            BusinessSectorId businessSectorId
        )
        {
            DependantId dependantId = new(Guid.NewGuid());
            Dependant dependant =
                new()
                {
                    DependantId = dependantId,
                    PersonId = personId,
                    ClientId = clientId,
                    BusinessSectorId = businessSectorId,
                    DateCreated = DateTime.Now,
                    IsActive = true
                };
            return dependant;
        }
    }

    public record DependantId(Guid Value);
}
