using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using ClientService.Application.Dto.Request;
using ClientService.Application.Dto.Request.ClientService.Application.Dto.Request;
using ClientService.Domain.Repositories;
using Newtonsoft.Json;

namespace ClientService.Application.Query.List
{
    public class QueryList : IQueryList
    {
        private readonly IMasterFileRepository _masterFile;
        private readonly ILogger<QueryList> _logger;

        public QueryList(IMasterFileRepository masterFile, ILogger<QueryList> logger)
        {
            _masterFile = masterFile;
            _logger = logger;
        }

        public async Task<MasterFileResponse> GetMasterFileData(MasterFileRequest request)
        {
            try
            {
                /*Map the proto enums with its equivalent string value*/
                var masterFileMap = new Dictionary<MasterFilesEnum, string>
                {
                    { MasterFilesEnum.PrimaryIdentificationTypes, "PRIMARYIDTYPES" },
                    { MasterFilesEnum.EconomicActivity, "ECONOMICACTIVITY" },
                    { MasterFilesEnum.BusinessSector, "BUSINESSSECTOR" },
                    { MasterFilesEnum.Occupation, "OCCUPATION" },
                    { MasterFilesEnum.MembershipStatus, "MEMBERSHIPSTATUS" },
                    { MasterFilesEnum.EducationalAttainment, "EDUCATIONALATTAINMENT" },
                    { MasterFilesEnum.ClientSource, "CLIENTSOURCE" },
                    { MasterFilesEnum.ClientReference, "CLIENTREFERENCE" },
                    { MasterFilesEnum.MembershipType, "MEMBERSHIPTYPE" },
                    { MasterFilesEnum.Nationailty, "NATIONALITY" },
                    { MasterFilesEnum.Religion, "RELIGION" }
                };

                /*Check if the request value is a key in the masterFileMap Dictionary,if it is,
                 get the equivalent string value and store it inside the newRequest variable*/
                if (masterFileMap.TryGetValue(request.MasterFileName, out var newRequest))
                {
                    var response = await _masterFile.GetMasterFileData(newRequest);
                    return response;
                }
                else
                {
                    _logger.LogError("Unresolved master file request");
                    throw new ArgumentException("Unresolved master file request");
                }
            }
            catch (Exception exception)
            {
                _logger.LogError("Failed to retrieve MasterFile request");
                throw new Exception($"Failed to retrieve{exception}");
            }
        }

        public async Task<GetAddressResponse> GetAddressMasterFileData(GetAddressRequest request)
        {
            try
            {
                var addressMasterFileMap = new Dictionary<AddressMasterFileEnum, string>
                {
                    { AddressMasterFileEnum.Country, "COUNTRY" },
                    { AddressMasterFileEnum.Region, "REGION" },
                    { AddressMasterFileEnum.Province, "PROVINCE" },
                    { AddressMasterFileEnum.CityMunicipality, "CITYMUNICIPALITY" },
                    { AddressMasterFileEnum.Barangay, "BARANGAY" }
                };

                IConfiguration configuration = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json")
                    .Build();

                /*Accessing the paths of json files from appsettings.json*/
                string countryFilePath = configuration["AddressJsonFiles:CountryJsonFilePath"]!;
                string regionFilePath = configuration["AddressJsonFiles:RegionJsonFilePath"]!;
                string provinceFilePath = configuration["AddressJsonFiles:ProvinceJsonFilePath"]!;
                string cityFilePath = configuration["AddressJsonFiles:CityMunicipalJsonFilePath"]!;
                string barangayFilePath = configuration["AddressJsonFiles:BarangayJsonFilePath"]!;

                /*Ensuring that the path created always have the base directory of the deployment environment*/
                string countryJson = File.ReadAllText(
                    Path.Combine(AppDomain.CurrentDomain.BaseDirectory, countryFilePath)
                );

                string regionJson = File.ReadAllText(
                    Path.Combine(AppDomain.CurrentDomain.BaseDirectory, regionFilePath)
                );

                string provinceJson = File.ReadAllText(
                    Path.Combine(AppDomain.CurrentDomain.BaseDirectory, provinceFilePath)
                );

                string municipalityJson = File.ReadAllText(
                    Path.Combine(AppDomain.CurrentDomain.BaseDirectory, cityFilePath)
                );

                string barangayJson = File.ReadAllText(
                    Path.Combine(AppDomain.CurrentDomain.BaseDirectory, barangayFilePath)
                );

                if (addressMasterFileMap.TryGetValue(request.AddressType, out var addressType))
                {
                    /*Deserializing json files to their matching Object that is of type IEnumerable
                    so that we can manipulate this using linq*/
                    IEnumerable<CountryDto> countryData = JsonConvert.DeserializeObject<
                        IEnumerable<CountryDto>
                    >(countryJson)!;

                    IEnumerable<RegionDto> regionData = JsonConvert.DeserializeObject<
                        IEnumerable<RegionDto>
                    >(regionJson)!;

                    IEnumerable<ProvinceDto> provinceData = JsonConvert.DeserializeObject<
                        IEnumerable<ProvinceDto>
                    >(provinceJson)!;

                    IEnumerable<MunicipalityDto> municipalityData = JsonConvert.DeserializeObject<
                        IEnumerable<MunicipalityDto>
                    >(municipalityJson)!;

                    IEnumerable<BarangayDto> barangayData = JsonConvert.DeserializeObject<
                        IEnumerable<BarangayDto>
                    >(barangayJson)!;

                    var response = await _masterFile.GetAddressMasterFileData(
                        countryData,
                        regionData,
                        provinceData,
                        municipalityData,
                        barangayData,
                        addressType
                    );
                    return response;
                }
                else
                {
                    _logger.LogError("Unresolved master file request");
                    throw new ArgumentException("Unresolved master file request");
                }
            }
            catch (Exception exception)
            {
                _logger.LogError("Failed to retrieve MasterFile request");
                throw new Exception($"Failed to retrieve{exception}");
            }
        }
    }
}
