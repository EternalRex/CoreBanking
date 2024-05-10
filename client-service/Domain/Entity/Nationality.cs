using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClientService.Domain.Base;

//master file
namespace ClientService.Domain.Entity
{
    public class Nationality : BaseEntity
    {
        public NationalityId NationalityId { get; private set; }
        public string NationalityName { get; private set; }

        public Nationality()
        {
            NationalityId = new(Guid.NewGuid());
            NationalityName = string.Empty;
        }

        public Nationality Create(string nationalityName)
        {
            NationalityId nationalityId = new(Guid.NewGuid());
            Nationality nationality =
                new()
                {
                    NationalityId = nationalityId,
                    NationalityName = nationalityName,
                    DateCreated = DateTime.Now,
                    IsActive = true
                };
            return nationality;
        }
    }

    public record NationalityId(Guid Value);
}
