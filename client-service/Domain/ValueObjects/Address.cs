using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClientService.Domain.ValueObjects
{
    public record Address(
        /*Subject to changes when addresses is in the masterfile form
        for now it stays like this*/
        string HouseNumber1,
        string Street1,
        string Barangay1,
        string City1,
        string Province1,
        string Region1,
        string Country1,
        string ZipCode1,
        string Latitude1,
        string Longitude1,
        string HomeOwnership1,
        string HouseNumber2,
        string Street2,
        string Barangay2,
        string City2,
        string Province2,
        string Region2,
        string Country2,
        string ZipCode2,
        string Latitude2,
        string Longitude2,
        string HomeOwnership2
    );
}
