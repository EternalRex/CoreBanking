using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClientService.Domain.Base;
using ClientService.Domain.Enums;
using ClientService.Domain.ValueObjects;

namespace ClientService.Domain.Entity
{
    public class Client : BaseEntity
    {
        public ClientId ClientId { get; private set; }
        public string PrimaryIdentificationTypeNumber { get; private set; }
        public DateTime PrimaryIdentificationTypeExpiration { get; private set; }
        public AdditionalInformation AdditionalInformation { get; private set; }
        public BranchId BranchId { get; private set; } //value will be from branchservice
        public CenterId CenterId { get; private set; } //value will be from branchservice
        public BranchOfficer BranchOfficerId { get; private set; } //value will be from branchservice

        /*Foreign Keys*/
        public PersonId PersonId { get; private set; }
        public PrimaryIdentificationTypeId PrimaryIdentificationTypeId { get; private set; }
        public EconomicActivityId EconomicActivityId { get; private set; }
        public OccupationId OccupationId { get; private set; }
        public MembershipStatusId MembershipStatusId { get; private set; }
        public ClientSourceId ClientSourceId { get; private set; }
        public ClientReferenceId ReferenceId { get; private set; }
        public MembershipTypeId MembershipTypeId { get; private set; }

        /*Navigators*/
        public Person? Person { get; private set; }
        public PrimaryIdentificationType? PrimaryIdentification { get; private set; }
        public EconomicActivity? EconomicActivity { get; private set; }
        public Occupation? Occupation { get; private set; }
        public MembershipStatus? MembershipStatus { get; private set; }
        public ClientSource? ClientSource { get; private set; }
        public ClientReference? ClientReference { get; private set; }
        public MembershipType? MembershipType { get; private set; }

        /*Initializing non nullable values*/
        public Client()
        {
            ClientId = new(Guid.NewGuid());
            PersonId = new(Guid.NewGuid());
            BranchId = new(Guid.NewGuid());
            CenterId = new(Guid.NewGuid());
            OccupationId = new(Guid.NewGuid());
            PrimaryIdentificationTypeId = new(Guid.NewGuid());
            EconomicActivityId = new(Guid.NewGuid());
            BranchOfficerId = new(Guid.NewGuid());
            MembershipStatusId = new(Guid.NewGuid());
            ClientSourceId = new(Guid.NewGuid());
            ReferenceId = new(Guid.NewGuid());
            MembershipTypeId = new(Guid.NewGuid());
            AdditionalInformation = new("", "", "");
            PrimaryIdentificationTypeNumber = string.Empty;
        }

        /*Method to Create new Client*/
        public Client Create(
            PersonId personId,
            PrimaryIdentificationTypeId primaryIdentificationTypeId,
            MembershipStatusId membershipStatusId,
            BranchId branchId,
            CenterId centerId,
            OccupationId occupationId,
            EconomicActivityId economicActivity,
            ClientReferenceId referenceId,
            MembershipTypeId membershipTypeId,
            BranchOfficer branchOfficer,
            DateTime primaryIdExpiration,
            ClientSourceId clientSourceId,
            string primaryIdNumber,
            AdditionalInformation additionalInformation
        )
        {
            ClientId clientId = new(Guid.NewGuid());
            Client client =
                new()
                {
                    ClientId = clientId,
                    PersonId = personId,
                    PrimaryIdentificationTypeId = primaryIdentificationTypeId,
                    PrimaryIdentificationTypeExpiration = primaryIdExpiration,
                    PrimaryIdentificationTypeNumber = primaryIdNumber,
                    EconomicActivityId = economicActivity,
                    MembershipStatusId = membershipStatusId,
                    ClientSourceId = clientSourceId,
                    ReferenceId = referenceId,
                    MembershipTypeId = membershipTypeId,
                    BranchId = branchId,
                    CenterId = centerId,
                    OccupationId = occupationId,
                    AdditionalInformation = additionalInformation,
                    BranchOfficerId = branchOfficer,
                    DateCreated = DateTime.Now,
                    IsActive = true
                };
            return client;
        }
    }

    public record ClientId(Guid Value);

    public record BranchId(Guid Value);

    public record CenterId(Guid Value);

    public record BranchOfficer(Guid Value);
}
