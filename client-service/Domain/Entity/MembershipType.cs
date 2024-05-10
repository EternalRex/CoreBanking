using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClientService.Domain.Base;

namespace ClientService.Domain.Entity
{
    public class MembershipType : BaseEntity
    {
        public MembershipTypeId MembershipTypeId { get; private set; }
        public string MembershipTypeName { get; private set; }

        public MembershipType()
        {
            MembershipTypeId = new(Guid.NewGuid());
            MembershipTypeName = string.Empty;
        }

        public MembershipType Create(string membershipName)
        {
            MembershipTypeId membershipTypeId = new(Guid.NewGuid());
            MembershipType membershipType =
                new()
                {
                    MembershipTypeId = membershipTypeId,
                    MembershipTypeName = membershipName,
                    DateCreated = DateTime.Now,
                    IsActive = true
                };
            return membershipType;
        }
    }

    public record MembershipTypeId(Guid Value);
}
