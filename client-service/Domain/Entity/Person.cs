using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClientService.Domain.Base;
using ClientService.Domain.Enums;
using ClientService.Domain.ValueObjects;
using Google.Protobuf.WellKnownTypes;

namespace ClientService.Domain.Entity
{
    public class Person : BaseEntity
    {
        public PersonId PersonId { get; private set; }
        public Salutation? Salutation { get; private set; }
        public string FirstName { get; private set; }
        public string? MiddleName { get; private set; }
        public string LastName { get; private set; }
        public string Suffix { get; private set; }
        public Gender Gender { get; private set; }
        public int Age { get; private set; }
        public Timestamp DateOfBirth { get; private set; }
        public string? PlaceOfBirth { get; private set; }
        public MaritalStatus MaritalStatus { get; private set; }
        public string? MotherMaidenName { get; private set; }
        public string? TaxPayerIdentificationNumber { get; private set; }
        public int? ChildrenInSchool { get; private set; }
        public int? ChildrenBelow21 { get; private set; }
        public int? DependantCount { get; private set; }
        public Address PersonAddress { get; private set; }
        public ContactDetails ContactDetails { get; private set; }

        /*Foreign Key*/
        public ReligionId ReligionId { get; private set; }
        public EducationalAttainmentId EducationalAttainmentId { get; private set; }
        public NationalityId NationalityId { get; private set; }

        /*Navigation Property*/
        public Religion? ClientReligion { get; private set; }
        public EducationalAttainment? EducationalAttainment { get; private set; }
        public Nationality? Nationality { get; private set; }

        /*Initializing non nullable values*/
        public Person()
        {
            PersonId = new(Guid.NewGuid());
            ReligionId = new(Guid.NewGuid());
            NationalityId = new(Guid.NewGuid());
            EducationalAttainmentId = new(Guid.NewGuid());
            MotherMaidenName = string.Empty;
            DateOfBirth = Timestamp.FromDateTimeOffset(DateTimeOffset.UtcNow);
            PersonAddress = new(
                string.Empty,
                string.Empty,
                string.Empty,
                string.Empty,
                string.Empty,
                string.Empty,
                string.Empty,
                string.Empty,
                string.Empty,
                string.Empty,
                string.Empty,
                string.Empty,
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
            ContactDetails = new(string.Empty, string.Empty, string.Empty, string.Empty);
            FirstName = string.Empty;
            LastName = string.Empty;
            Suffix = string.Empty;
        }

        /*Person Create Method*/
        public Person Create(
            Salutation salutation,
            string firstName,
            string? middleName,
            string lastName,
            string suffix,
            Gender gender,
            int age,
            Timestamp dateOfBirth,
            string placeOfBirth,
            string? taxIdentificationNumber,
            int? childrenInSchool,
            int? childrenBelow21,
            int? dependantCount,
            string motherMaidenName,
            MaritalStatus maritalStatus,
            ReligionId religionId,
            EducationalAttainmentId educationalAttainmentId,
            NationalityId nationalityId,
            Address address,
            ContactDetails contactDetails
        )
        {
            PersonId personId = new(Guid.NewGuid());
            Person person =
                new()
                {
                    PersonId = personId,
                    Salutation = salutation,
                    FirstName = firstName,
                    MiddleName = middleName,
                    LastName = lastName,
                    Suffix = suffix,
                    Gender = gender,
                    Age = age,
                    DateOfBirth = dateOfBirth,
                    MotherMaidenName = motherMaidenName,
                    PlaceOfBirth = placeOfBirth,
                    TaxPayerIdentificationNumber = taxIdentificationNumber,
                    DependantCount = dependantCount,
                    ChildrenBelow21 = childrenBelow21,
                    ChildrenInSchool = childrenInSchool,
                    MaritalStatus = maritalStatus,
                    ReligionId = religionId,
                    EducationalAttainmentId = educationalAttainmentId,
                    NationalityId = nationalityId,
                    PersonAddress = address,
                    ContactDetails = contactDetails,
                    DateCreated = DateTime.Now,
                    IsActive = true,
                };

            return person;
        }
    }

    public record PersonId(Guid Value);
}
