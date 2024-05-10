using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ClientService.Domain.Entity;
using ClientService.Domain.Enums;
using ClientService.Domain.ValueObjects;
using Google.Protobuf.WellKnownTypes;

namespace ClientService.Infrastructure.Middleware
{
    public class MappingMiddleware : Profile
    {
        public MappingMiddleware()
        {
            /*Client basic details to person*/
            CreateMap<ClientDetails, Person>()
                .ConstructUsing(
                    (source, context) =>
                    {
                        var salutation = context.Mapper.Map<Salutation>(
                            source.PersonDetails.Salutation
                        );
                        var gender = context.Mapper.Map<Gender>(source.PersonDetails.Gender);
                        var maritalStatus = context.Mapper.Map<MaritalStatus>(
                            source.PersonDetails.MaritalStatus
                        );

                        // Parse string IDs to Guid
                        var religionId = new ReligionId(
                            Guid.Parse(source.PersonDetails.ReligionId)
                        );
                        var educationalAttainmentId = new EducationalAttainmentId(
                            Guid.Parse(source.PersonDetails.EducationalAttainmentId)
                        );
                        var nationalityId = new NationalityId(
                            Guid.Parse(source.PersonDetails.NationalityId)
                        );

                        var addressDetails = new Address(
                            HouseNumber1: source.PersonDetails.PersonAddress.HouseNumber1,
                            Street1: source.PersonDetails.PersonAddress.Street1,
                            Barangay1: source.PersonDetails.PersonAddress.Barangay1,
                            City1: source.PersonDetails.PersonAddress.City1,
                            Province1: source.PersonDetails.PersonAddress.Province1,
                            Region1: source.PersonDetails.PersonAddress.Region1,
                            Country1: source.PersonDetails.PersonAddress.Country1,
                            ZipCode1: source.PersonDetails.PersonAddress.ZipCode1,
                            Latitude1: source.PersonDetails.PersonAddress.Latitude1,
                            Longitude1: source.PersonDetails.PersonAddress.Longitude1,
                            HomeOwnership1: source.PersonDetails.PersonAddress.HomeOwnership1,
                            HouseNumber2: source.PersonDetails.PersonAddress.HouseNumber2,
                            Street2: source.PersonDetails.PersonAddress.Street2,
                            Barangay2: source.PersonDetails.PersonAddress.Barangay2,
                            City2: source.PersonDetails.PersonAddress.City2,
                            Province2: source.PersonDetails.PersonAddress.Province2,
                            Region2: source.PersonDetails.PersonAddress.Region2,
                            Country2: source.PersonDetails.PersonAddress.Country2,
                            ZipCode2: source.PersonDetails.PersonAddress.ZipCode2,
                            Latitude2: source.PersonDetails.PersonAddress.Latitude2,
                            Longitude2: source.PersonDetails.PersonAddress.Longitude2,
                            HomeOwnership2: source.PersonDetails.PersonAddress.HomeOwnership2
                        );

                        var contactDetails = new ContactDetails(
                            MobileNumber: source.PersonDetails.ContactDetails.MobileNumber,
                            EmailAddress: source.PersonDetails.ContactDetails.EmailAddress,
                            ContactPersonName: source
                                .PersonDetails
                                .ContactDetails
                                .ContactPersonName,
                            ContactPersonMobileNumber: source
                                .PersonDetails
                                .ContactDetails
                                .ContactPersonMobileNumber
                        );

                        // Create and return Person instance
                        Person person = new();
                        return person.Create(
                            salutation: salutation,
                            firstName: source.PersonDetails.FirstName,
                            middleName: source.PersonDetails.MiddleName,
                            lastName: source.PersonDetails.LastName,
                            suffix: source.PersonDetails.Suffix,
                            gender: gender,
                            age: source.PersonDetails.Age,
                            dateOfBirth: source.PersonDetails.DateOfBirth,
                            placeOfBirth: source.PersonDetails.PlaceOfBirth,
                            taxIdentificationNumber: source
                                .PersonDetails
                                .TaxPayerIdentificationNumber,
                            dependantCount: source.PersonDetails.DependantCount,
                            childrenBelow21: source.PersonDetails.ChildrenBelow21,
                            childrenInSchool: source.PersonDetails.ChildrenInSchool,
                            motherMaidenName: source.PersonDetails.MotherMaidenName,
                            maritalStatus: maritalStatus,
                            religionId: religionId,
                            educationalAttainmentId: educationalAttainmentId,
                            nationalityId: nationalityId,
                            address: addressDetails,
                            contactDetails: contactDetails
                        );
                    }
                );

            /*Client details to client*/
            CreateMap<CreateClientRequest, Client>()
                .ConstructUsing(
                    (source, context) =>
                    {
                        Client client = new();
                        PersonId personId = (PersonId)context.Items["PersonId"];
                        BranchId branchId = new(Value: Guid.Parse(source.ClientDetails.BranchId));
                        CenterId centerId = new(Value: Guid.Parse(source.ClientDetails.CenterId));
                        EconomicActivityId economicActivityId =
                            new(Value: Guid.Parse(source.ClientDetails.EconomicActivityId));
                        BranchOfficer branchOfficer =
                            new(Value: Guid.Parse(source.ClientDetails.BranchOfficerId));
                        PrimaryIdentificationTypeId primaryIdentificationId =
                            new(
                                Value: Guid.Parse(source.ClientDetails.PrimaryIdentificationTypeId)
                            );
                        OccupationId occupationId =
                            new(Value: Guid.Parse(source.ClientDetails.OccupationId));
                        MembershipStatusId membershipStatusId =
                            new(Value: Guid.Parse(source.ClientDetails.MembershipStatusId));
                        ClientSourceId clientSourceId =
                            new(Value: Guid.Parse(source.ClientDetails.ClientSourceId));
                        ClientReferenceId referenceId =
                            new(Value: Guid.Parse(source.ClientDetails.ReferenceId));
                        MembershipTypeId membershipTypeId =
                            new(Value: Guid.Parse(source.ClientDetails.MembershipTypeId));

                        AdditionalInformation additionalInformation =
                            new(
                                Bank: source.ClientDetails.AdditionalInformation.Bank,
                                BankAccountNumber: source
                                    .ClientDetails
                                    .AdditionalInformation
                                    .BankAccountNumber,
                                Notes: source.ClientDetails.AdditionalInformation.Notes
                            );

                        return client.Create(
                            personId: personId,
                            primaryIdentificationTypeId: primaryIdentificationId,
                            membershipStatusId: membershipStatusId,
                            branchId: branchId,
                            centerId: centerId,
                            occupationId: occupationId,
                            economicActivity: economicActivityId,
                            branchOfficer: branchOfficer,
                            primaryIdExpiration: source.ClientDetails.PrimaryIdentificationTypeExpiration.ToDateTime(),
                            clientSourceId: clientSourceId,
                            membershipTypeId: membershipTypeId,
                            referenceId: referenceId,
                            primaryIdNumber: source.ClientDetails.PrimaryIdentificationTypeNumber,
                            additionalInformation: additionalInformation
                        );
                    }
                );

            /*Client or spouse or dependant document to document*/
            CreateMap<CreateClientRequest, List<Document>>()
                .ConstructUsing(
                    (source, context) =>
                    {
                        var identifier = (string)context.Items["IDENTIFIER"];
                        if (identifier.Equals("CLIENT"))
                        {
                            return source
                                .ClientDetails.DocumentDetails.Select(
                                    (details, index) =>
                                    {
                                        ClientId clientId = (ClientId)context.Items["ClientId"];

                                        var newDocumentList =
                                            (List<DocumentDetails>)context.Items["ListOfDocuments"];
                                        var documentData = newDocumentList[index];

                                        Document document = new();
                                        return document.Create(
                                            clientId: clientId,
                                            spouseId: null,
                                            dependantId: null,
                                            documentName: documentData.FileName,
                                            documentType: documentData.FileType.ToString(),
                                            documentPath: documentData.FilePath,
                                            documentExtension: documentData.FileExtenstion
                                        );
                                    }
                                )
                                .ToList();
                        }
                        else if (identifier.Equals("SPOUSE"))
                        {
                            return source
                                .SpouseDetails.SelectMany(
                                    (spouseDetails, spouseIndex) =>
                                    {
                                        var spouseListId =
                                            (List<SpouseId>)context.Items["SpouseIdList"];
                                        var spouseId = spouseListId[spouseIndex];

                                        var spouseDocuments = spouseDetails.DocumentDetails;

                                        var documentsForSpouse = spouseDocuments.Select(
                                            (documentDetails, documentIndex) =>
                                            {
                                                var newDocumentList =
                                                    (List<DocumentDetails>)
                                                        context.Items["ListOfDocuments"];

                                                /*newDocumentList now contains all the documents of all the dependants since
                                                we flattened the list using select many*/

                                                /*documentData has the expression that pinpoints the exact index of the document
                                                of the spouse, it goes like this, if i have doc1, doc2, doc3, doc4 in newDocumentList
                                                , then for spouse1, he will have the spouseIndex of 0, and if he has 2 documents, for the
                                                first document that index would be, ((0*3) + 0 = 0) is 0, for the second document the index
                                                would be, ((0*3) + 1 = 1) = 1, Then therefore the owner of the documents
                                                that is in index 0 and 1 in newDocumentList which is doc1 and doc2 is the first spouse*/

                                                /*In continuation spouse2 will have the spouseIndex of 1, if he has 2 documents then
                                                the index of his first document is ((1*2) + 0) = 2 and his second document is ((1*2) + 1 = 3, and
                                                thus spouse2 owns documents in the index 2 and 3 which is doc3 and doc4*/


                                                var documentData = newDocumentList[
                                                    spouseIndex * spouseDocuments.Count
                                                        + documentIndex
                                                ];

                                                Document document = new();
                                                return document.Create(
                                                    clientId: null,
                                                    spouseId: spouseId,
                                                    dependantId: null,
                                                    documentName: documentData.FileName,
                                                    documentType: documentData.FileType.ToString(),
                                                    documentPath: documentData.FilePath,
                                                    documentExtension: documentData.FileExtenstion
                                                );
                                            }
                                        );

                                        return documentsForSpouse;
                                    }
                                )
                                .ToList();
                        }
                        else
                        {
                            return source
                                .DependantDetails.SelectMany(
                                    (dependantDetails, dependantIndex) =>
                                    {
                                        /*Getting the values of the dependant id and documents from
                                        the context library of automapper*/
                                        var dependantIdList =
                                            (List<DependantId>)context.Items["DependantIdListId"];
                                        var newDocumentList =
                                            (List<DocumentDetails>)context.Items["ListOfDocuments"];

                                        var dependantDocuments = dependantDetails.DocumentDetails;

                                        /*Iterating the document of each dependant*/
                                        var documentsForDependant = dependantDocuments.Select(
                                            (documentDetails, documentIndex) =>
                                            {
                                                var dependantId = dependantIdList[dependantIndex];

                                                /*newDocumentList now contains all the documents of all the dependants since
                                                we flattened the list using select many*/

                                                /*documentData has the expression that pinpoints the exact index of the document
                                                of the dependant, it goes like this, if i have doc1, doc2, doc3, doc4 in newDocumentList
                                                , then for dependant1, he will have the dependatIndex of 0, and if he has 2 documents, for the
                                                first document that index would be, ((0*3) + 0 = 0) is 0, for the second document the index
                                                would be, ((0*3) + 1 = 1) = 1, Then therefore the owner of the documents
                                                that is in index 0 and 1 in newDocumentList which is doc1 and doc2 is the first dependant*/

                                                /*In continuation dependant2 will have the dependantIndex of 1, if he has 2 documents then
                                                the index of his first document is ((1*2) + 0) = 2 and his second document is ((1*2) + 1 = 3, and
                                                thus dependant2 owns documents in the index 2 and 3 which is doc3 and doc4*/

                                                var documentData = newDocumentList[
                                                    dependantIndex * dependantDocuments.Count
                                                        + documentIndex
                                                ];

                                                // Create and return the document entity
                                                Document document = new();
                                                return document.Create(
                                                    clientId: null,
                                                    spouseId: null,
                                                    dependantId: dependantId,
                                                    documentName: documentData.FileName,
                                                    documentType: documentData.FileType.ToString(),
                                                    documentPath: documentData.FilePath,
                                                    documentExtension: documentData.FileExtenstion
                                                );
                                            }
                                        );

                                        return documentsForDependant;
                                    }
                                )
                                .ToList();
                        }
                    }
                );

            /*Mapping spouse basic details to person or dependatn basic details to person */
            CreateMap<CreateClientRequest, List<Person>>()
                .ConstructUsing(
                    (source, context) =>
                    {
                        var identifier = (string)context.Items["IDENTIFIER"];
                        if (identifier.Equals("SPOUSE"))
                        {
                            return source
                                .SpouseDetails.Select(
                                    (details, index) =>
                                    {
                                        var spousePersonDetailsList =
                                            (List<PersonDetails>)
                                                context.Items["ListOfSpousePersonDetails"];
                                        var spousePersonDetails = spousePersonDetailsList[index];

                                        var salutation = context.Mapper.Map<Salutation>(
                                            spousePersonDetails.Salutation
                                        );
                                        var gender = context.Mapper.Map<Gender>(
                                            spousePersonDetails.Gender
                                        );
                                        var maritalStatus = context.Mapper.Map<MaritalStatus>(
                                            spousePersonDetails.MaritalStatus
                                        );

                                        var religionId = new ReligionId(
                                            Guid.Parse(spousePersonDetails.ReligionId)
                                        );
                                        var educationalAttainmentId = new EducationalAttainmentId(
                                            Guid.Parse(spousePersonDetails.EducationalAttainmentId)
                                        );
                                        var nationalityId = new NationalityId(
                                            Guid.Parse(spousePersonDetails.NationalityId)
                                        );

                                        var addressDetails = new Address(
                                            HouseNumber1: spousePersonDetails
                                                .PersonAddress
                                                .HouseNumber1,
                                            Street1: spousePersonDetails.PersonAddress.Street1,
                                            Barangay1: spousePersonDetails.PersonAddress.Barangay1,
                                            City1: spousePersonDetails.PersonAddress.City1,
                                            Province1: spousePersonDetails.PersonAddress.Province1,
                                            Region1: spousePersonDetails.PersonAddress.Region1,
                                            Country1: spousePersonDetails.PersonAddress.Country1,
                                            ZipCode1: spousePersonDetails.PersonAddress.ZipCode1,
                                            Latitude1: spousePersonDetails.PersonAddress.Latitude1,
                                            Longitude1: spousePersonDetails
                                                .PersonAddress
                                                .Longitude1,
                                            HomeOwnership1: spousePersonDetails
                                                .PersonAddress
                                                .HomeOwnership1,
                                            HouseNumber2: spousePersonDetails
                                                .PersonAddress
                                                .HouseNumber2,
                                            Street2: spousePersonDetails.PersonAddress.Street2,
                                            Barangay2: spousePersonDetails.PersonAddress.Barangay2,
                                            City2: spousePersonDetails.PersonAddress.City2,
                                            Province2: spousePersonDetails.PersonAddress.Province2,
                                            Region2: spousePersonDetails.PersonAddress.Region2,
                                            Country2: spousePersonDetails.PersonAddress.Country2,
                                            ZipCode2: spousePersonDetails.PersonAddress.ZipCode2,
                                            Latitude2: spousePersonDetails.PersonAddress.Latitude2,
                                            Longitude2: spousePersonDetails
                                                .PersonAddress
                                                .Longitude2,
                                            HomeOwnership2: spousePersonDetails
                                                .PersonAddress
                                                .HomeOwnership2
                                        );

                                        var contactDetails = new ContactDetails(
                                            MobileNumber: spousePersonDetails
                                                .ContactDetails
                                                .MobileNumber,
                                            EmailAddress: spousePersonDetails
                                                .ContactDetails
                                                .EmailAddress,
                                            ContactPersonName: spousePersonDetails
                                                .ContactDetails
                                                .ContactPersonName,
                                            ContactPersonMobileNumber: spousePersonDetails
                                                .ContactDetails
                                                .ContactPersonMobileNumber
                                        );

                                        Person person = new();
                                        return person.Create(
                                            salutation: salutation,
                                            firstName: spousePersonDetails.FirstName,
                                            middleName: spousePersonDetails.MiddleName,
                                            lastName: spousePersonDetails.LastName,
                                            suffix: spousePersonDetails.Suffix,
                                            gender: gender,
                                            age: spousePersonDetails.Age,
                                            dateOfBirth: spousePersonDetails.DateOfBirth,
                                            placeOfBirth: spousePersonDetails.PlaceOfBirth,
                                            taxIdentificationNumber: spousePersonDetails.TaxPayerIdentificationNumber,
                                            dependantCount: spousePersonDetails.DependantCount,
                                            childrenBelow21: spousePersonDetails.ChildrenBelow21,
                                            childrenInSchool: spousePersonDetails.ChildrenInSchool,
                                            motherMaidenName: spousePersonDetails.MotherMaidenName,
                                            maritalStatus: maritalStatus,
                                            religionId: religionId,
                                            educationalAttainmentId: educationalAttainmentId,
                                            nationalityId: nationalityId,
                                            address: addressDetails,
                                            contactDetails: contactDetails
                                        );
                                    }
                                )
                                .ToList();
                        }
                        else
                        {
                            return source
                                .DependantDetails.Select(
                                    (details, index) =>
                                    {
                                        var dependantPersonDetailsList =
                                            (List<PersonDetails>)
                                                context.Items["ListOfDependantPersonDetails"];
                                        var dependantPersonDetails = dependantPersonDetailsList[
                                            index
                                        ];

                                        var salutation = context.Mapper.Map<Salutation>(
                                            dependantPersonDetails.Salutation
                                        );
                                        var gender = context.Mapper.Map<Gender>(
                                            dependantPersonDetails.Gender
                                        );
                                        var maritalStatus = context.Mapper.Map<MaritalStatus>(
                                            dependantPersonDetails.MaritalStatus
                                        );

                                        // Parse string IDs to Guid
                                        var religionId = new ReligionId(
                                            Guid.Parse(dependantPersonDetails.ReligionId)
                                        );
                                        var educationalAttainmentId = new EducationalAttainmentId(
                                            Guid.Parse(
                                                dependantPersonDetails.EducationalAttainmentId
                                            )
                                        );
                                        var nationalityId = new NationalityId(
                                            Guid.Parse(dependantPersonDetails.NationalityId)
                                        );

                                        var addressDetails = new Address(
                                            HouseNumber1: dependantPersonDetails
                                                .PersonAddress
                                                .HouseNumber1,
                                            Street1: dependantPersonDetails.PersonAddress.Street1,
                                            Barangay1: dependantPersonDetails
                                                .PersonAddress
                                                .Barangay1,
                                            City1: dependantPersonDetails.PersonAddress.City1,
                                            Province1: dependantPersonDetails
                                                .PersonAddress
                                                .Province1,
                                            Region1: dependantPersonDetails.PersonAddress.Region1,
                                            Country1: dependantPersonDetails.PersonAddress.Country1,
                                            ZipCode1: dependantPersonDetails.PersonAddress.ZipCode1,
                                            Latitude1: dependantPersonDetails
                                                .PersonAddress
                                                .Latitude1,
                                            Longitude1: dependantPersonDetails
                                                .PersonAddress
                                                .Longitude1,
                                            HomeOwnership1: dependantPersonDetails
                                                .PersonAddress
                                                .HomeOwnership1,
                                            HouseNumber2: dependantPersonDetails
                                                .PersonAddress
                                                .HouseNumber2,
                                            Street2: dependantPersonDetails.PersonAddress.Street2,
                                            Barangay2: dependantPersonDetails
                                                .PersonAddress
                                                .Barangay2,
                                            City2: dependantPersonDetails.PersonAddress.City2,
                                            Province2: dependantPersonDetails
                                                .PersonAddress
                                                .Province2,
                                            Region2: dependantPersonDetails.PersonAddress.Region2,
                                            Country2: dependantPersonDetails.PersonAddress.Country2,
                                            ZipCode2: dependantPersonDetails.PersonAddress.ZipCode2,
                                            Latitude2: dependantPersonDetails
                                                .PersonAddress
                                                .Latitude2,
                                            Longitude2: dependantPersonDetails
                                                .PersonAddress
                                                .Longitude2,
                                            HomeOwnership2: dependantPersonDetails
                                                .PersonAddress
                                                .HomeOwnership2
                                        );

                                        var contactDetails = new ContactDetails(
                                            MobileNumber: dependantPersonDetails
                                                .ContactDetails
                                                .MobileNumber,
                                            EmailAddress: dependantPersonDetails
                                                .ContactDetails
                                                .EmailAddress,
                                            ContactPersonName: dependantPersonDetails
                                                .ContactDetails
                                                .ContactPersonName,
                                            ContactPersonMobileNumber: dependantPersonDetails
                                                .ContactDetails
                                                .ContactPersonMobileNumber
                                        );

                                        // Create and return Person instance
                                        Person person = new();
                                        return person.Create(
                                            salutation: salutation,
                                            firstName: dependantPersonDetails.FirstName,
                                            middleName: dependantPersonDetails.MiddleName,
                                            lastName: dependantPersonDetails.LastName,
                                            suffix: dependantPersonDetails.Suffix,
                                            gender: gender,
                                            age: dependantPersonDetails.Age,
                                            dateOfBirth: dependantPersonDetails.DateOfBirth,
                                            placeOfBirth: dependantPersonDetails.PlaceOfBirth,
                                            taxIdentificationNumber: dependantPersonDetails.TaxPayerIdentificationNumber,
                                            dependantCount: dependantPersonDetails.DependantCount,
                                            childrenBelow21: dependantPersonDetails.ChildrenBelow21,
                                            childrenInSchool: dependantPersonDetails.ChildrenInSchool,
                                            motherMaidenName: dependantPersonDetails.MotherMaidenName,
                                            maritalStatus: maritalStatus,
                                            religionId: religionId,
                                            educationalAttainmentId: educationalAttainmentId,
                                            nationalityId: nationalityId,
                                            address: addressDetails,
                                            contactDetails: contactDetails
                                        );
                                    }
                                )
                                .ToList();
                        }
                    }
                );

            /*Spouse details to spouse*/
            CreateMap<CreateClientRequest, List<Spouse>>()
                .ConstructUsing(
                    (source, context) =>
                        source
                            .SpouseDetails.Select(
                                (details, index) =>
                                {
                                    ClientId clientId = (ClientId)context.Items["ClientId"];
                                    var personIdList =
                                        (List<PersonId>)context.Items["ListOfPersonId"];

                                    /*In each iteration use the index parameter to access the person id
                                    corresponding to the spouse details of the current iteration*/
                                    var personId = personIdList[index];

                                    BusinessSectorId businessSectorId =
                                        new(Value: Guid.Parse(details.BusinessSectorId));
                                    OccupationId occupationId =
                                        new(Value: Guid.Parse(details.OccupationId));

                                    Spouse spouse = new();
                                    return spouse.Create(
                                        personId: personId,
                                        clientId: clientId,
                                        businessSectorId: businessSectorId,
                                        occupationId: occupationId,
                                        monthlyIncome: details.MonthlyIncome,
                                        employerName: details.EmployerName
                                    );
                                }
                            )
                            .ToList()
                );

            /*Dependant details to dependant*/
            CreateMap<CreateClientRequest, List<Dependant>>()
                .ConstructUsing(
                    (source, context) =>
                        source
                            .DependantDetails.Select(
                                (details, index) =>
                                {
                                    ClientId clientId = (ClientId)context.Items["ClientId"];
                                    var personIdList =
                                        (List<PersonId>)context.Items["ListOfPersonId"];

                                    /*In each iteration use the index parameter to access the person id
                                    corresponding to the dependant details of the current iteration*/
                                    var personId = personIdList[index];

                                    BusinessSectorId businessSectorId =
                                        new(Value: Guid.Parse(details.BusinessSectorId));

                                    Dependant dependant = new();
                                    return dependant.Create(
                                        personId: personId,
                                        clientId: clientId,
                                        businessSectorId: businessSectorId
                                    );
                                }
                            )
                            .ToList()
                );

            /*Business Entity Mapping*/
            CreateMap<CreateClientRequest, List<Business>>()
                .ConstructUsing(
                    (source, context) =>
                        source
                            .BusinessesDetails.Select(details =>
                            {
                                ClientId clientId = (ClientId)context.Items["ClientId"];

                                EconomicActivityId economicActivityId =
                                    new(Value: Guid.Parse(details.EconomicActivityId));
                                BusinessSectorId businessSectorId =
                                    new(Value: Guid.Parse(details.BusinessSectorId));

                                Business business = new();

                                BusinessAddress address =
                                    new(
                                        HouseNumber1: details.BusinessAddress.HouseNumber1,
                                        Street1: details.BusinessAddress.Street1,
                                        City1: details.BusinessAddress.City1,
                                        Region1: details.BusinessAddress.Region1,
                                        Province1: details.BusinessAddress.Province1,
                                        Barangay1: details.BusinessAddress.Barangay1,
                                        Country1: details.BusinessAddress.Country1,
                                        ZipCode1: details.BusinessAddress.ZipCode1,
                                        Latitude1: details.BusinessAddress.Latitude1
                                            ?? string.Empty, // Handle nullable property
                                        Longitude1: details.BusinessAddress.Longitude1
                                            ?? string.Empty // Handle nullable property
                                    );

                                Income businessIncome =
                                    new(
                                        WeeklyIncome: details.BusinessIncome.WeeklyIncome,
                                        MonthlyIncome: details.BusinessIncome.MonthlyIncome,
                                        AnnualGrossIncome: details.BusinessIncome.AnnualGrossIncome
                                    );

                                MicroFinanceEngagement engagement =
                                    new(
                                        MFIEngagement: details.MicroFinanceEngagement.MFIEngagement,
                                        MFIEngagementName: details
                                            .MicroFinanceEngagement
                                            .MFIEngagementName,
                                        YearsOfMFIEngagementMembership: details
                                            .MicroFinanceEngagement
                                            .YearsOfMFIEngagementMembership
                                    );

                                return business.Create(
                                    clientId: clientId,
                                    businessName: details.Name,
                                    address: address,
                                    mobileNumber: details.MobileNumber,
                                    landLineNumber: details.LandLineNumber,
                                    businessIncome: businessIncome,
                                    existingCapital: details.ExistingCapital,
                                    totalAssets: details.TotalAssets,
                                    foundingYear: details.FoundingYear,
                                    taxIdentificationNumber: details.TaxIdentificationNumber,
                                    businessPermitNumber: details.BusinessPermitNumber,
                                    numberOfStaff: details.NumberOfStaff,
                                    isOperating: details.IsOperating,
                                    microFinanceEngagement: engagement,
                                    economicActivityId: economicActivityId,
                                    businessSectorId: businessSectorId
                                );
                            })
                            .ToList()
                );

            /*Mapping requested master file data from database to proto*/
            CreateMap<List<PrimaryIdentificationType>, MasterFileResponse>()
                .ForMember(
                    destination => destination.MasterFileValues,
                    options =>
                        options.MapFrom(source =>
                            source.Select(details => new MasterFileResponse.Types.MasterFileData
                            {
                                Id = details.PrimaryIdentificationTypeId.Value.ToString(),
                                Value = details.PrimaryIdentificationTypeName
                            })
                        )
                );

            /*Maping requesed economic activity master file data from database to proto*/
            CreateMap<List<EconomicActivity>, MasterFileResponse>()
                .ForMember(
                    destination => destination.MasterFileValues,
                    options =>
                        options.MapFrom(source =>
                            source.Select(details => new MasterFileResponse.Types.MasterFileData
                            {
                                Id = details.EconomicActivityId.Value.ToString(),
                                Value = details.EconomicActivityName,
                            })
                        )
                );

            /*Mapping requested business nature master file data from database to proto*/
            CreateMap<List<BusinessSector>, MasterFileResponse>()
                .ForMember(
                    destination => destination.MasterFileValues,
                    options =>
                        options.MapFrom(source =>
                            source.Select(details => new MasterFileResponse.Types.MasterFileData
                            {
                                Id = details.BusinessSectorId.Value.ToString(),
                                Value = details.BusinessSectorName
                            })
                        )
                );

            /*Mapping requested occupation master file data from database to proto*/
            CreateMap<List<Occupation>, MasterFileResponse>()
                .ForMember(
                    destination => destination.MasterFileValues,
                    options =>
                        options.MapFrom(source =>
                            source.Select(details => new MasterFileResponse.Types.MasterFileData
                            {
                                Id = details.OccupationId.Value.ToString(),
                                Value = details.OccupationName,
                            })
                        )
                );

            /*Mapping requested membership status master file data from database to proto*/
            CreateMap<List<MembershipStatus>, MasterFileResponse>()
                .ForMember(
                    destination => destination.MasterFileValues,
                    options =>
                        options.MapFrom(source =>
                            source.Select(details => new MasterFileResponse.Types.MasterFileData
                            {
                                Id = details.MembershipStatusId.Value.ToString(),
                                Value = details.MembershipStatusName
                            })
                        )
                );

            /*Mapping requested educational qualification data from database to proto*/
            CreateMap<List<EducationalAttainment>, MasterFileResponse>()
                .ForMember(
                    destination => destination.MasterFileValues,
                    options =>
                        options.MapFrom(source =>
                            source.Select(details => new MasterFileResponse.Types.MasterFileData
                            {
                                Id = details.EducationalAttainmentId.Value.ToString(),
                                Value = details.EducationalAttainmentName
                            })
                        )
                );

            /*Mapping requested client source data to from database to proto*/
            CreateMap<List<ClientSource>, MasterFileResponse>()
                .ForMember(
                    destination => destination.MasterFileValues,
                    options =>
                        options.MapFrom(source =>
                            source.Select(details => new MasterFileResponse.Types.MasterFileData
                            {
                                Id = details.ClientSourceId.Value.ToString(),
                                Value = details.ClientSourceName
                            })
                        )
                );

            /*Mapping requested client reference data to from database to proto*/
            CreateMap<List<ClientReference>, MasterFileResponse>()
                .ForMember(
                    destination => destination.MasterFileValues,
                    options =>
                        options.MapFrom(source =>
                            source.Select(details => new MasterFileResponse.Types.MasterFileData
                            {
                                Id = details.ClientReferenceId.Value.ToString(),
                                Value = details.ClientReferenceName
                            })
                        )
                );

            /*Mapping requested client membership type data to from database to proto*/
            CreateMap<List<MembershipType>, MasterFileResponse>()
                .ForMember(
                    destination => destination.MasterFileValues,
                    options =>
                        options.MapFrom(source =>
                            source.Select(details => new MasterFileResponse.Types.MasterFileData
                            {
                                Id = details.MembershipTypeId.Value.ToString(),
                                Value = details.MembershipTypeName,
                            })
                        )
                );

            /*Mapping requested client membership type data to from database to proto*/
            CreateMap<List<Nationality>, MasterFileResponse>()
                .ForMember(
                    destination => destination.MasterFileValues,
                    options =>
                        options.MapFrom(source =>
                            source.Select(details => new MasterFileResponse.Types.MasterFileData
                            {
                                Id = details.NationalityId.Value.ToString(),
                                Value = details.NationalityName,
                            })
                        )
                );

            /*Mapping requested client membership type data to from database to proto*/
            CreateMap<List<Religion>, MasterFileResponse>()
                .ForMember(
                    destination => destination.MasterFileValues,
                    options =>
                        options.MapFrom(source =>
                            source.Select(details => new MasterFileResponse.Types.MasterFileData
                            {
                                Id = details.ReligionId.Value.ToString(),
                                Value = details.ReligionName,
                            })
                        )
                );

            /*Maping requested country data from database to proto response*/
            CreateMap<List<Country>, GetAddressResponse>()
                .ForMember(
                    destination => destination.CountryResponse,
                    options =>
                        options.MapFrom(source =>
                            source.Select(details => new GetAddressResponse.Types.Country
                            {
                                CountryId = details.CountryId.Value.ToString(),
                                CountryName = details.CountryName
                            })
                        )
                );

            /*Maping requested region data from database to proto response*/
            CreateMap<List<Region>, GetAddressResponse>()
                .ForMember(
                    destination => destination.RegionResponse,
                    options =>
                        options.MapFrom(source =>
                            source.Select(details => new GetAddressResponse.Types.Region
                            {
                                RegionId = details.RegionId.Value.ToString(),
                                RegionName = details.RegionName,
                                CountryName = details.CountryName
                            })
                        )
                );

            /*Maping requested province data from database to proto response*/
            CreateMap<List<Province>, GetAddressResponse>()
                .ForMember(
                    destination => destination.ProvinceResponse,
                    options =>
                        options.MapFrom(source =>
                            source.Select(details => new GetAddressResponse.Types.Province
                            {
                                ProvinceId = details.ProvinceId.Value.ToString(),
                                ProvinceName = details.ProvinceName,
                                RegionName = details.RegionName,
                                CountryName = details.CountryName
                            })
                        )
                );

            /*Mapping requested city municipality datga from database toproto*/
            CreateMap<List<CityMunicipality>, GetAddressResponse>()
                .ForMember(
                    destination => destination.CityMunicipalityResponse,
                    options =>
                        options.MapFrom(source =>
                            source.Select(details => new GetAddressResponse.Types.CityMunicipality
                            {
                                CityMunicipalityId = details.CityMunicipalityId.Value.ToString(),
                                CityMunicipalityName = details.CityMunicipalityName,
                                RegionName = details.RegionName,
                                ProvinceName = details.ProvinceName,
                                CountryName = details.CountryName,
                            })
                        )
                );

            CreateMap<List<Barangay>, GetAddressResponse>()
                .ForMember(
                    destination => destination.BarangayResponse,
                    options =>
                        options.MapFrom(source =>
                            source.Select(details => new GetAddressResponse.Types.Barangay
                            {
                                BarangayId = details.BarangayId.Value.ToString(),
                                BarangayName = details.BarangayName,
                                CityMunicipalityName = details.CityMunicipalityName,
                                ProvinceName = details.ProvinceName,
                                RegionName = details.RegionName,
                                CountryName = details.CountryName,
                            })
                        )
                );
        }
    }
}
