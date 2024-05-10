using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClientService.Domain.ValueObjects
{
    public record MicroFinanceEngagement(
        string? MFIEngagement,
        string? MFIEngagementName,
        int? YearsOfMFIEngagementMembership
    );
}
