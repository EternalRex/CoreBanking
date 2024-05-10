using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClientService.Domain.Base;

namespace ClientService.Domain.Entity
{
    public class Religion : BaseEntity
    {
        public ReligionId ReligionId { get; private set; }
        public string ReligionName { get; private set; }
        public string? Description { get; private set; }

        /*Initializing non nullable values*/
        public Religion()
        {
            ReligionId = new ReligionId(Guid.NewGuid());
            ReligionName = string.Empty;
            Description = string.Empty;
        }

        /*Method to create a religion*/
        public Religion Create(string religionName, string? religionDescription)
        {
            ReligionId religionId = new(Guid.NewGuid());
            Religion religion =
                new()
                {
                    ReligionId = religionId,
                    ReligionName = religionName,
                    Description = religionDescription,
                    DateCreated = DateTime.Now,
                    IsActive = true,
                };
            return religion;
        }
    }

    public record ReligionId(Guid Value);
}
