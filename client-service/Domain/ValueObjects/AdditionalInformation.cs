using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClientService.Domain.Enums;

namespace ClientService.Domain.ValueObjects
{
    public record AdditionalInformation(string? Bank, string? BankAccountNumber, string? Notes);
}
