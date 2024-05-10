using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClientService.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class FirstEntitiesMasterFilesMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BarangayMasterFile",
                columns: table => new
                {
                    BarangayId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BarangayName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CityMunicipalityName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProvinceName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RegionName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CountryName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateDeleted = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BarangayMasterFile", x => x.BarangayId);
                });

            migrationBuilder.CreateTable(
                name: "BusinessSectorMasterFile",
                columns: table => new
                {
                    BusinessSectorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BusinessSectorName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateDeleted = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BusinessSectorMasterFile", x => x.BusinessSectorId);
                });

            migrationBuilder.CreateTable(
                name: "CityMunicipalityMasterFile",
                columns: table => new
                {
                    CityMunicipalityId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CityMunicipalityName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProvinceName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RegionName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CountryName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateDeleted = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CityMunicipalityMasterFile", x => x.CityMunicipalityId);
                });

            migrationBuilder.CreateTable(
                name: "ClientReferenceMasterFile",
                columns: table => new
                {
                    ClientReferenceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClientReferenceName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateDeleted = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientReferenceMasterFile", x => x.ClientReferenceId);
                });

            migrationBuilder.CreateTable(
                name: "ClientSourceMasterFile",
                columns: table => new
                {
                    ClientSourceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClientSourceName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateDeleted = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientSourceMasterFile", x => x.ClientSourceId);
                });

            migrationBuilder.CreateTable(
                name: "CountryMasterFile",
                columns: table => new
                {
                    CountryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CountryName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateDeleted = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CountryMasterFile", x => x.CountryId);
                });

            migrationBuilder.CreateTable(
                name: "EconomicActivityMasterFile",
                columns: table => new
                {
                    EconomicActivityId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EconomicActivityName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateDeleted = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EconomicActivityMasterFile", x => x.EconomicActivityId);
                });

            migrationBuilder.CreateTable(
                name: "EducationalAttainmentMasterFile",
                columns: table => new
                {
                    EducationalAttainmentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EducationalAttainmentName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateDeleted = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EducationalAttainmentMasterFile", x => x.EducationalAttainmentId);
                });

            migrationBuilder.CreateTable(
                name: "MembershipStatusMasterFile",
                columns: table => new
                {
                    MembershipStatusId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MembershipStatusName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateDeleted = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MembershipStatusMasterFile", x => x.MembershipStatusId);
                });

            migrationBuilder.CreateTable(
                name: "MembershipTypeMasterFile",
                columns: table => new
                {
                    MembershipTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MembershipTypeName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateDeleted = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MembershipTypeMasterFile", x => x.MembershipTypeId);
                });

            migrationBuilder.CreateTable(
                name: "NationalityMasterFile",
                columns: table => new
                {
                    NationalityId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NationalityName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateDeleted = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NationalityMasterFile", x => x.NationalityId);
                });

            migrationBuilder.CreateTable(
                name: "OccupationMasterFile",
                columns: table => new
                {
                    OccupationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OccupationName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateDeleted = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OccupationMasterFile", x => x.OccupationId);
                });

            migrationBuilder.CreateTable(
                name: "PrimaryIdentificationTypeMasterFile",
                columns: table => new
                {
                    PrimaryIdentificationTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PrimaryIdentificationTypeName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateDeleted = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PrimaryIdentificationTypeMasterFile", x => x.PrimaryIdentificationTypeId);
                });

            migrationBuilder.CreateTable(
                name: "ProvinceMasterFile",
                columns: table => new
                {
                    ProvinceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProvinceName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RegionName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CountryName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateDeleted = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProvinceMasterFile", x => x.ProvinceId);
                });

            migrationBuilder.CreateTable(
                name: "RegionMasterFile",
                columns: table => new
                {
                    RegionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RegionName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CountryName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateDeleted = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RegionMasterFile", x => x.RegionId);
                });

            migrationBuilder.CreateTable(
                name: "ReligionMasterFile",
                columns: table => new
                {
                    ReligionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ReligionName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateDeleted = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReligionMasterFile", x => x.ReligionId);
                });

            migrationBuilder.CreateTable(
                name: "Person",
                columns: table => new
                {
                    PersonId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Salutation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MiddleName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Suffix = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PlaceOfBirth = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MaritalStatus = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MotherMaidenName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TaxPayerIdentificationNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ChildrenInSchool = table.Column<int>(type: "int", nullable: true),
                    ChildrenBelow21 = table.Column<int>(type: "int", nullable: true),
                    DependantCount = table.Column<int>(type: "int", nullable: true),
                    PersonAddressHouseNumber1 = table.Column<string>(name: "PersonAddress_HouseNumber1", type: "nvarchar(max)", nullable: false),
                    PersonAddressStreet1 = table.Column<string>(name: "PersonAddress_Street1", type: "nvarchar(max)", nullable: false),
                    PersonAddressBarangay1 = table.Column<string>(name: "PersonAddress_Barangay1", type: "nvarchar(max)", nullable: false),
                    PersonAddressCity1 = table.Column<string>(name: "PersonAddress_City1", type: "nvarchar(max)", nullable: false),
                    PersonAddressProvince1 = table.Column<string>(name: "PersonAddress_Province1", type: "nvarchar(max)", nullable: false),
                    PersonAddressRegion1 = table.Column<string>(name: "PersonAddress_Region1", type: "nvarchar(max)", nullable: false),
                    PersonAddressCountry1 = table.Column<string>(name: "PersonAddress_Country1", type: "nvarchar(max)", nullable: false),
                    PersonAddressZipCode1 = table.Column<string>(name: "PersonAddress_ZipCode1", type: "nvarchar(max)", nullable: false),
                    PersonAddressLatitude1 = table.Column<string>(name: "PersonAddress_Latitude1", type: "nvarchar(max)", nullable: false),
                    PersonAddressLongitude1 = table.Column<string>(name: "PersonAddress_Longitude1", type: "nvarchar(max)", nullable: false),
                    PersonAddressHomeOwnership1 = table.Column<string>(name: "PersonAddress_HomeOwnership1", type: "nvarchar(max)", nullable: false),
                    PersonAddressHouseNumber2 = table.Column<string>(name: "PersonAddress_HouseNumber2", type: "nvarchar(max)", nullable: false),
                    PersonAddressStreet2 = table.Column<string>(name: "PersonAddress_Street2", type: "nvarchar(max)", nullable: false),
                    PersonAddressBarangay2 = table.Column<string>(name: "PersonAddress_Barangay2", type: "nvarchar(max)", nullable: false),
                    PersonAddressCity2 = table.Column<string>(name: "PersonAddress_City2", type: "nvarchar(max)", nullable: false),
                    PersonAddressProvince2 = table.Column<string>(name: "PersonAddress_Province2", type: "nvarchar(max)", nullable: false),
                    PersonAddressRegion2 = table.Column<string>(name: "PersonAddress_Region2", type: "nvarchar(max)", nullable: false),
                    PersonAddressCountry2 = table.Column<string>(name: "PersonAddress_Country2", type: "nvarchar(max)", nullable: false),
                    PersonAddressZipCode2 = table.Column<string>(name: "PersonAddress_ZipCode2", type: "nvarchar(max)", nullable: false),
                    PersonAddressLatitude2 = table.Column<string>(name: "PersonAddress_Latitude2", type: "nvarchar(max)", nullable: false),
                    PersonAddressLongitude2 = table.Column<string>(name: "PersonAddress_Longitude2", type: "nvarchar(max)", nullable: false),
                    PersonAddressHomeOwnership2 = table.Column<string>(name: "PersonAddress_HomeOwnership2", type: "nvarchar(max)", nullable: false),
                    ContactDetailsMobileNumber = table.Column<string>(name: "ContactDetails_MobileNumber", type: "nvarchar(max)", nullable: false),
                    ContactDetailsEmailAddress = table.Column<string>(name: "ContactDetails_EmailAddress", type: "nvarchar(max)", nullable: false),
                    ContactDetailsContactPersonName = table.Column<string>(name: "ContactDetails_ContactPersonName", type: "nvarchar(max)", nullable: false),
                    ContactDetailsContactPersonMobileNumber = table.Column<string>(name: "ContactDetails_ContactPersonMobileNumber", type: "nvarchar(max)", nullable: false),
                    ReligionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EducationalAttainmentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NationalityId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateDeleted = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Person", x => x.PersonId);
                    table.ForeignKey(
                        name: "FK_Person_EducationalAttainmentMasterFile_EducationalAttainmentId",
                        column: x => x.EducationalAttainmentId,
                        principalTable: "EducationalAttainmentMasterFile",
                        principalColumn: "EducationalAttainmentId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Person_NationalityMasterFile_NationalityId",
                        column: x => x.NationalityId,
                        principalTable: "NationalityMasterFile",
                        principalColumn: "NationalityId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Person_ReligionMasterFile_ReligionId",
                        column: x => x.ReligionId,
                        principalTable: "ReligionMasterFile",
                        principalColumn: "ReligionId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Client",
                columns: table => new
                {
                    ClientId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PrimaryIdentificationTypeNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PrimaryIdentificationTypeExpiration = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AdditionalInformationBank = table.Column<string>(name: "AdditionalInformation_Bank", type: "nvarchar(max)", nullable: true),
                    AdditionalInformationBankAccountNumber = table.Column<string>(name: "AdditionalInformation_BankAccountNumber", type: "nvarchar(max)", nullable: true),
                    AdditionalInformationNotes = table.Column<string>(name: "AdditionalInformation_Notes", type: "nvarchar(max)", nullable: true),
                    BranchId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CenterId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BranchOfficerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PersonId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PrimaryIdentificationTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EconomicActivityId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OccupationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MembershipStatusId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClientSourceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ReferenceId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MembershipTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateDeleted = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Client", x => x.ClientId);
                    table.ForeignKey(
                        name: "FK_Client_ClientReferenceMasterFile_ReferenceId",
                        column: x => x.ReferenceId,
                        principalTable: "ClientReferenceMasterFile",
                        principalColumn: "ClientReferenceId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Client_ClientSourceMasterFile_ClientSourceId",
                        column: x => x.ClientSourceId,
                        principalTable: "ClientSourceMasterFile",
                        principalColumn: "ClientSourceId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Client_EconomicActivityMasterFile_EconomicActivityId",
                        column: x => x.EconomicActivityId,
                        principalTable: "EconomicActivityMasterFile",
                        principalColumn: "EconomicActivityId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Client_MembershipStatusMasterFile_MembershipStatusId",
                        column: x => x.MembershipStatusId,
                        principalTable: "MembershipStatusMasterFile",
                        principalColumn: "MembershipStatusId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Client_MembershipTypeMasterFile_MembershipTypeId",
                        column: x => x.MembershipTypeId,
                        principalTable: "MembershipTypeMasterFile",
                        principalColumn: "MembershipTypeId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Client_OccupationMasterFile_OccupationId",
                        column: x => x.OccupationId,
                        principalTable: "OccupationMasterFile",
                        principalColumn: "OccupationId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Client_Person_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Person",
                        principalColumn: "PersonId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Client_PrimaryIdentificationTypeMasterFile_PrimaryIdentificationTypeId",
                        column: x => x.PrimaryIdentificationTypeId,
                        principalTable: "PrimaryIdentificationTypeMasterFile",
                        principalColumn: "PrimaryIdentificationTypeId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Business",
                columns: table => new
                {
                    BusinessId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BusinessAddressHouseNumber1 = table.Column<string>(name: "BusinessAddress_HouseNumber1", type: "nvarchar(max)", nullable: true),
                    BusinessAddressStreet1 = table.Column<string>(name: "BusinessAddress_Street1", type: "nvarchar(max)", nullable: false),
                    BusinessAddressCity1 = table.Column<string>(name: "BusinessAddress_City1", type: "nvarchar(max)", nullable: false),
                    BusinessAddressRegion1 = table.Column<string>(name: "BusinessAddress_Region1", type: "nvarchar(max)", nullable: false),
                    BusinessAddressProvince1 = table.Column<string>(name: "BusinessAddress_Province1", type: "nvarchar(max)", nullable: false),
                    BusinessAddressBarangay1 = table.Column<string>(name: "BusinessAddress_Barangay1", type: "nvarchar(max)", nullable: false),
                    BusinessAddressCountry1 = table.Column<string>(name: "BusinessAddress_Country1", type: "nvarchar(max)", nullable: false),
                    BusinessAddressZipCode1 = table.Column<string>(name: "BusinessAddress_ZipCode1", type: "nvarchar(max)", nullable: false),
                    BusinessAddressLatitude1 = table.Column<string>(name: "BusinessAddress_Latitude1", type: "nvarchar(max)", nullable: true),
                    BusinessAddressLongitude1 = table.Column<string>(name: "BusinessAddress_Longitude1", type: "nvarchar(max)", nullable: true),
                    MobileNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LandLineNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BusinessIncomeWeeklyIncome = table.Column<decimal>(name: "BusinessIncome_WeeklyIncome", type: "decimal(18,2)", nullable: false),
                    BusinessIncomeMonthlyIncome = table.Column<decimal>(name: "BusinessIncome_MonthlyIncome", type: "decimal(18,2)", nullable: false),
                    BusinessIncomeAnnualGrossIncome = table.Column<decimal>(name: "BusinessIncome_AnnualGrossIncome", type: "decimal(18,2)", nullable: false),
                    TotalAssets = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ExistingCapital = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    FoundingYear = table.Column<int>(type: "int", nullable: false),
                    TaxIdentificationNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BusinessPermitNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NumberOfStaff = table.Column<int>(type: "int", nullable: false),
                    IsOperating = table.Column<bool>(type: "bit", nullable: false),
                    MicroFinanceEngagementMFIEngagement = table.Column<string>(name: "MicroFinanceEngagement_MFIEngagement", type: "nvarchar(max)", nullable: true),
                    MicroFinanceEngagementMFIEngagementName = table.Column<string>(name: "MicroFinanceEngagement_MFIEngagementName", type: "nvarchar(max)", nullable: true),
                    MicroFinanceEngagementYearsOfMFIEngagementMembership = table.Column<int>(name: "MicroFinanceEngagement_YearsOfMFIEngagementMembership", type: "int", nullable: true),
                    ClientId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EconomicActivityId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BusinessSectorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateDeleted = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Business", x => x.BusinessId);
                    table.ForeignKey(
                        name: "FK_Business_BusinessSectorMasterFile_BusinessSectorId",
                        column: x => x.BusinessSectorId,
                        principalTable: "BusinessSectorMasterFile",
                        principalColumn: "BusinessSectorId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Business_Client_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Client",
                        principalColumn: "ClientId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Business_EconomicActivityMasterFile_EconomicActivityId",
                        column: x => x.EconomicActivityId,
                        principalTable: "EconomicActivityMasterFile",
                        principalColumn: "EconomicActivityId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Dependant",
                columns: table => new
                {
                    DependantId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PersonId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClientId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BusinessSectorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateDeleted = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dependant", x => x.DependantId);
                    table.ForeignKey(
                        name: "FK_Dependant_BusinessSectorMasterFile_BusinessSectorId",
                        column: x => x.BusinessSectorId,
                        principalTable: "BusinessSectorMasterFile",
                        principalColumn: "BusinessSectorId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Dependant_Client_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Client",
                        principalColumn: "ClientId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Dependant_Person_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Person",
                        principalColumn: "PersonId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Spouse",
                columns: table => new
                {
                    SpouseId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MonthlyIncome = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    EmployerName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PersonId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClientId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BusinessSectorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OccupationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateDeleted = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Spouse", x => x.SpouseId);
                    table.ForeignKey(
                        name: "FK_Spouse_BusinessSectorMasterFile_BusinessSectorId",
                        column: x => x.BusinessSectorId,
                        principalTable: "BusinessSectorMasterFile",
                        principalColumn: "BusinessSectorId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Spouse_Client_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Client",
                        principalColumn: "ClientId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Spouse_OccupationMasterFile_OccupationId",
                        column: x => x.OccupationId,
                        principalTable: "OccupationMasterFile",
                        principalColumn: "OccupationId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Spouse_Person_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Person",
                        principalColumn: "PersonId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Document",
                columns: table => new
                {
                    DocumentId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DocumentName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DocumentType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DocumentPath = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DocumentExtension = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ClientId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    SpouseId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DependantId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateUpdated = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DateDeleted = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Document", x => x.DocumentId);
                    table.ForeignKey(
                        name: "FK_Document_Client_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Client",
                        principalColumn: "ClientId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Document_Dependant_DependantId",
                        column: x => x.DependantId,
                        principalTable: "Dependant",
                        principalColumn: "DependantId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Document_Spouse_SpouseId",
                        column: x => x.SpouseId,
                        principalTable: "Spouse",
                        principalColumn: "SpouseId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Business_BusinessSectorId",
                table: "Business",
                column: "BusinessSectorId");

            migrationBuilder.CreateIndex(
                name: "IX_Business_ClientId",
                table: "Business",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Business_EconomicActivityId",
                table: "Business",
                column: "EconomicActivityId");

            migrationBuilder.CreateIndex(
                name: "IX_Client_ClientSourceId",
                table: "Client",
                column: "ClientSourceId");

            migrationBuilder.CreateIndex(
                name: "IX_Client_EconomicActivityId",
                table: "Client",
                column: "EconomicActivityId");

            migrationBuilder.CreateIndex(
                name: "IX_Client_MembershipStatusId",
                table: "Client",
                column: "MembershipStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Client_MembershipTypeId",
                table: "Client",
                column: "MembershipTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Client_OccupationId",
                table: "Client",
                column: "OccupationId");

            migrationBuilder.CreateIndex(
                name: "IX_Client_PersonId",
                table: "Client",
                column: "PersonId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Client_PrimaryIdentificationTypeId",
                table: "Client",
                column: "PrimaryIdentificationTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Client_ReferenceId",
                table: "Client",
                column: "ReferenceId");

            migrationBuilder.CreateIndex(
                name: "IX_Dependant_BusinessSectorId",
                table: "Dependant",
                column: "BusinessSectorId");

            migrationBuilder.CreateIndex(
                name: "IX_Dependant_ClientId",
                table: "Dependant",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Dependant_PersonId",
                table: "Dependant",
                column: "PersonId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Document_ClientId",
                table: "Document",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Document_DependantId",
                table: "Document",
                column: "DependantId");

            migrationBuilder.CreateIndex(
                name: "IX_Document_SpouseId",
                table: "Document",
                column: "SpouseId");

            migrationBuilder.CreateIndex(
                name: "IX_Person_EducationalAttainmentId",
                table: "Person",
                column: "EducationalAttainmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Person_NationalityId",
                table: "Person",
                column: "NationalityId");

            migrationBuilder.CreateIndex(
                name: "IX_Person_ReligionId",
                table: "Person",
                column: "ReligionId");

            migrationBuilder.CreateIndex(
                name: "IX_Spouse_BusinessSectorId",
                table: "Spouse",
                column: "BusinessSectorId");

            migrationBuilder.CreateIndex(
                name: "IX_Spouse_ClientId",
                table: "Spouse",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Spouse_OccupationId",
                table: "Spouse",
                column: "OccupationId");

            migrationBuilder.CreateIndex(
                name: "IX_Spouse_PersonId",
                table: "Spouse",
                column: "PersonId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BarangayMasterFile");

            migrationBuilder.DropTable(
                name: "Business");

            migrationBuilder.DropTable(
                name: "CityMunicipalityMasterFile");

            migrationBuilder.DropTable(
                name: "CountryMasterFile");

            migrationBuilder.DropTable(
                name: "Document");

            migrationBuilder.DropTable(
                name: "ProvinceMasterFile");

            migrationBuilder.DropTable(
                name: "RegionMasterFile");

            migrationBuilder.DropTable(
                name: "Dependant");

            migrationBuilder.DropTable(
                name: "Spouse");

            migrationBuilder.DropTable(
                name: "BusinessSectorMasterFile");

            migrationBuilder.DropTable(
                name: "Client");

            migrationBuilder.DropTable(
                name: "ClientReferenceMasterFile");

            migrationBuilder.DropTable(
                name: "ClientSourceMasterFile");

            migrationBuilder.DropTable(
                name: "EconomicActivityMasterFile");

            migrationBuilder.DropTable(
                name: "MembershipStatusMasterFile");

            migrationBuilder.DropTable(
                name: "MembershipTypeMasterFile");

            migrationBuilder.DropTable(
                name: "OccupationMasterFile");

            migrationBuilder.DropTable(
                name: "Person");

            migrationBuilder.DropTable(
                name: "PrimaryIdentificationTypeMasterFile");

            migrationBuilder.DropTable(
                name: "EducationalAttainmentMasterFile");

            migrationBuilder.DropTable(
                name: "NationalityMasterFile");

            migrationBuilder.DropTable(
                name: "ReligionMasterFile");
        }
    }
}
