using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClientService.Domain.ValueObjects
{
    public record ContactDetails(
        string MobileNumber,
        string EmailAddress,
        string ContactPersonName,
        string ContactPersonMobileNumber
    );
}
