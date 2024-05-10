using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClientService.Domain.Base;

namespace ClientService.Domain.Entity
{
    public class MembershipStatus : BaseEntity
    {
        public MembershipStatusId MembershipStatusId { get; private set; }
        public string MembershipStatusName { get; private set; }

        public MembershipStatus()
        {
            MembershipStatusId = new(Guid.NewGuid());
            MembershipStatusName = string.Empty;
        }

        public MembershipStatus Create(string memershipStatusName)
        {
            MembershipStatusId membershipStatusId = new(Guid.NewGuid());

            MembershipStatus membershipStatus =
                new()
                {
                    MembershipStatusId = membershipStatusId,
                    MembershipStatusName = memershipStatusName,
                    DateCreated = DateTime.Now,
                    IsActive = true,
                };

            return membershipStatus;
        }
    }

    public record MembershipStatusId(Guid Value);
}
