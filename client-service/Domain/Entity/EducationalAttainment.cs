using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClientService.Domain.Base;

//master file
namespace ClientService.Domain.Entity
{
    public class EducationalAttainment : BaseEntity
    {
        public EducationalAttainmentId EducationalAttainmentId { get; private set; }
        public string EducationalAttainmentName { get; private set; }

        public EducationalAttainment()
        {
            EducationalAttainmentId = new(Guid.NewGuid());
            EducationalAttainmentName = string.Empty;
        }

        public EducationalAttainment Create(string educationalAttainmentName)
        {
            EducationalAttainmentId educationalQualificationId = new(Guid.NewGuid());
            EducationalAttainment educationalAttainment =
                new()
                {
                    EducationalAttainmentId = educationalQualificationId,
                    EducationalAttainmentName = educationalAttainmentName,
                    DateCreated = DateTime.Now,
                    IsActive = true
                };
            return educationalAttainment;
        }
    }

    public record EducationalAttainmentId(Guid Value);
}
