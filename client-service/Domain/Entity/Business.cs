using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClientService.Domain.Base;
using ClientService.Domain.ValueObjects;

namespace ClientService.Domain.Entity
{
    public class Business : BaseEntity
    {
        public BusinessId BusinessId { get; private set; }
        public string Name { get; private set; }
        public BusinessAddress BusinessAddress { get; private set; }
        public string MobileNumber { get; private set; }
        public string? LandLineNumber { get; private set; }
        public Income BusinessIncome { get; private set; }
        public decimal TotalAssets { get; private set; }
        public decimal ExistingCapital { get; private set; }
        public int FoundingYear { get; private set; }
        public string? TaxIdentificationNumber { get; private set; }
        public string BusinessPermitNumber { get; private set; }
        public int NumberOfStaff { get; private set; }
        public bool IsOperating { get; private set; }
        public MicroFinanceEngagement MicroFinanceEngagement { get; private set; }

        // Foreign Keys
        public ClientId ClientId { get; private set; }
        public EconomicActivityId EconomicActivityId { get; private set; }
        public BusinessSectorId BusinessSectorId { get; private set; }

        //Navigator
        public Client? MyClient { get; private set; }
        public EconomicActivity? EconomicActivity { get; private set; }
        public BusinessSector? BusinessSector { get; private set; }

        public Business()
        {
            ClientId = new ClientId(Guid.NewGuid());
            BusinessId = new BusinessId(Guid.NewGuid());
            EconomicActivityId = new EconomicActivityId(Guid.NewGuid());
            BusinessSectorId = new BusinessSectorId(Guid.NewGuid());
            BusinessIncome = new(0, 0, 0);
            MicroFinanceEngagement = new(string.Empty, string.Empty, 0);
            BusinessAddress = new BusinessAddress(
                string.Empty,
                string.Empty,
                string.Empty,
                string.Empty,
                string.Empty,
                string.Empty,
                string.Empty,
                string.Empty,
                string.Empty,
                string.Empty
            );
            TaxIdentificationNumber = string.Empty;
            BusinessPermitNumber = string.Empty;
            Name = string.Empty;
            MobileNumber = string.Empty;
            LandLineNumber = string.Empty;
        }

        public Business Create(
            ClientId clientId,
            string businessName,
            BusinessAddress address,
            string mobileNumber,
            string? landLineNumber,
            Income businessIncome,
            decimal existingCapital,
            decimal totalAssets,
            int foundingYear,
            string? taxIdentificationNumber,
            string businessPermitNumber,
            int numberOfStaff,
            bool isOperating,
            MicroFinanceEngagement microFinanceEngagement,
            EconomicActivityId economicActivityId,
            BusinessSectorId businessSectorId
        )
        {
            BusinessId businessId = new(Guid.NewGuid());
            Business business =
                new()
                {
                    BusinessId = businessId,
                    ClientId = clientId,
                    Name = businessName,
                    BusinessAddress = address,
                    MobileNumber = mobileNumber,
                    LandLineNumber = landLineNumber,
                    BusinessIncome = businessIncome,
                    ExistingCapital = existingCapital,
                    TotalAssets = totalAssets,
                    FoundingYear = foundingYear,
                    TaxIdentificationNumber = taxIdentificationNumber,
                    BusinessPermitNumber = businessPermitNumber,
                    NumberOfStaff = numberOfStaff,
                    IsOperating = isOperating,
                    MicroFinanceEngagement = microFinanceEngagement,
                    EconomicActivityId = economicActivityId,
                    BusinessSectorId = businessSectorId,
                    DateCreated = DateTime.Now,
                    IsActive = true
                };
            return business;
        }
    }

    public record BusinessId(Guid Value);
}
