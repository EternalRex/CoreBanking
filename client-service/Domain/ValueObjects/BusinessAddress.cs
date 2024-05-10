using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClientService.Domain.ValueObjects
{
    public record BusinessAddress(
        string? HouseNumber1,
        string Street1,
        string City1,
        string Region1,
        string Province1,
        string Barangay1,
        string Country1,
        string ZipCode1,
        string? Latitude1,
        string? Longitude1
    );
}
