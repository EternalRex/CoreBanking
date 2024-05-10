using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClientService.Domain.Base;

namespace ClientService.Domain.Entity
{
    public class Spouse : BaseEntity
    {
        public SpouseId SpouseId { get; private set; }
        public decimal MonthlyIncome { get; private set; }
        public string EmployerName { get; private set; }

        /*Foreign Keys*/
        public PersonId PersonId { get; private set; }
        public ClientId ClientId { get; private set; }
        public BusinessSectorId BusinessSectorId { get; private set; }
        public OccupationId OccupationId { get; private set; }

        /*Navigators*/
        public Person? Person { get; private set; }
        public Client? Client { get; private set; }
        public BusinessSector? BusinessSector { get; private set; }
        public Occupation? Occupation { get; private set; }

        public Spouse()
        {
            SpouseId = new(Guid.NewGuid());
            ClientId = new(Guid.NewGuid());
            PersonId = new(Guid.NewGuid());
            BusinessSectorId = new(Guid.NewGuid());
            OccupationId = new(Guid.NewGuid());
            MonthlyIncome = 0;
            EmployerName = string.Empty;
        }

        public Spouse Create(
            ClientId clientId,
            PersonId personId,
            BusinessSectorId businessSectorId,
            OccupationId occupationId,
            decimal monthlyIncome,
            string employerName
        )
        {
            SpouseId spouseId = new(Guid.NewGuid());
            Spouse spouse =
                new()
                {
                    SpouseId = spouseId,
                    MonthlyIncome = monthlyIncome,
                    EmployerName = employerName,
                    PersonId = personId,
                    ClientId = clientId,
                    BusinessSectorId = businessSectorId,
                    OccupationId = occupationId,
                    DateCreated = DateTime.Now,
                    IsActive = true,
                };
            return spouse;
        }
    }

    public record SpouseId(Guid Value);
}
