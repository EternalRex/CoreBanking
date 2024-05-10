using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClientService.Application.Dto.Request.ClientService.Application.Dto.Request;
using Microsoft.EntityFrameworkCore;

namespace ClientService.Domain.Repositories
{
    public interface IMasterFileRepository
    {
        /*For Getting the values from the master file table*/
        public Task<MasterFileResponse> GetMasterFileData(string request);

        public Task<GetAddressResponse> GetAddressMasterFileData(
            IEnumerable<CountryDto> countryData,
            IEnumerable<RegionDto> regionData,
            IEnumerable<ProvinceDto> provinceData,
            IEnumerable<MunicipalityDto> municipalityData,
            IEnumerable<BarangayDto> barangayData,
            string request
        );

        /*Adding new master file data to an existing master file*/
        public Task<AddMasterFileResponse> AddNewMasterFileData(
            string masterFileName,
            AddMasterFileRequest requestData
        );
    }
}
