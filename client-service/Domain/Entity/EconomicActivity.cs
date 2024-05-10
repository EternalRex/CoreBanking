using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClientService.Domain.Base;

namespace ClientService.Domain.Entity
{
    public class EconomicActivity : BaseEntity
    {
        public EconomicActivityId EconomicActivityId { get; private set; }
        public string EconomicActivityName { get; private set; }

        public EconomicActivity()
        {
            EconomicActivityId = new EconomicActivityId(Guid.NewGuid());
            EconomicActivityName = string.Empty;
        }

        public EconomicActivity Create(string activityName)
        {
            EconomicActivityId activityId = new(Guid.NewGuid());

            EconomicActivity activity =
                new()
                {
                    EconomicActivityId = activityId,
                    EconomicActivityName = activityName,
                    DateCreated = DateTime.Now,
                    IsActive = true,
                };

            return activity;
        }
    }

    public record EconomicActivityId(Guid Value);
}
