using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text.Json;
using System.Threading.Tasks;
using AutoMapper;
using Azure.Core;
using ClientService.Application.Dto.Request;
using ClientService.Application.Dto.Request.ClientService.Application.Dto.Request;
using ClientService.Domain.Entity;
using ClientService.Domain.Repositories;
using ClientService.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using Newtonsoft.Json;

namespace ClientService.Infrastructure.Repositories
{
    public class MasterFileRepository : IMasterFileRepository
    {
        private readonly DataContext _dataContext;
        private readonly IMapper _mapper;
        private readonly ILogger<MasterFileRepository> _logger;

        public MasterFileRepository(
            DataContext dataContext,
            IMapper mapper,
            ILogger<MasterFileRepository> logger
        )
        {
            _dataContext = dataContext;
            _mapper = mapper;
            _logger = logger;
        }

        /*Get master file data, for testing purposes, each time client first request a master file
        and whenever there is no master files yet in the dataabse, a default master file data will
        be created and returned to the client*/
        public Task<MasterFileResponse> GetMasterFileData(string request)
        {
            switch (request)
            {
                case "PRIMARYIDTYPES":
                    return ImplementGetMasterFileData<PrimaryIdentificationType>(
                        prop => prop.PrimaryIdentificationTypeName,
                        _dataContext.PrimaryIdentificationTypeMasterFile
                    );

                case "ECONOMICACTIVITY":
                    return ImplementGetMasterFileData<EconomicActivity>(
                        prop => prop.EconomicActivityName,
                        _dataContext.EconomicActivityMasterFile
                    );

                case "BUSINESSSECTOR":
                    return ImplementGetMasterFileData<BusinessSector>(
                        prop => prop.BusinessSectorName,
                        _dataContext.BusinessSectorMasterFile
                    );

                case "OCCUPATION":
                    return ImplementGetMasterFileData<Occupation>(
                        prop => prop.OccupationName,
                        _dataContext.OccupationMasterFile
                    );

                case "MEMBERSHIPSTATUS":
                    return ImplementGetMasterFileData<MembershipStatus>(
                        prop => prop.MembershipStatusName,
                        _dataContext.MembershipStatusMasterFile
                    );

                case "EDUCATIONALATTAINMENT":
                    return ImplementGetMasterFileData<EducationalAttainment>(
                        prop => prop.EducationalAttainmentName,
                        _dataContext.EducationalAttainmentMasterFile
                    );

                case "CLIENTSOURCE":
                    return ImplementGetMasterFileData<ClientSource>(
                        prop => prop.ClientSourceName,
                        _dataContext.ClientSourceMasterFile
                    );

                case "CLIENTREFERENCE":
                    return ImplementGetMasterFileData<ClientReference>(
                        prop => prop.ClientReferenceName,
                        _dataContext.ClientReferenceMasterFile
                    );

                case "MEMBERSHIPTYPE":
                    return ImplementGetMasterFileData<MembershipType>(
                        prop => prop.MembershipTypeName,
                        _dataContext.MembershipTypeMasterFile
                    );

                case "RELIGION":
                    return ImplementGetMasterFileData<Religion>(
                        prop => prop.ReligionName,
                        _dataContext.ReligionMasterFile
                    );

                case "NATIONALITY":
                    return ImplementGetMasterFileData<Nationality>(
                        prop => prop.NationalityName,
                        _dataContext.NationalityMasterFile
                    );

                default:
                    throw new Exception($"Failed retrieving {request} master file");
            }
        }

        /*Different data source e.g. admin and etc. can add multiple master file values to a single master file*/
        public Task<AddMasterFileResponse> AddNewMasterFileData(
            string masterFileName,
            AddMasterFileRequest requestData
        )
        {
            switch (masterFileName)
            {
                case "PRIMARYIDTYPES":
                    return ImplementAddNewMasterFileData<PrimaryIdentificationType>(
                        requestData,
                        prop => prop.PrimaryIdentificationTypeName,
                        _dataContext.PrimaryIdentificationTypeMasterFile
                    );

                case "ECONOMICACTIVITY":
                    return ImplementAddNewMasterFileData<EconomicActivity>(
                        requestData,
                        prop => prop.EconomicActivityName,
                        _dataContext.EconomicActivityMasterFile
                    );

                case "BUSINESSSECTOR":
                    return ImplementAddNewMasterFileData<BusinessSector>(
                        requestData,
                        prop => prop.BusinessSectorName,
                        _dataContext.BusinessSectorMasterFile
                    );

                case "OCCUPATION":
                    return ImplementAddNewMasterFileData<Occupation>(
                        requestData,
                        prop => prop.OccupationName,
                        _dataContext.OccupationMasterFile
                    );

                case "MEMBERSHIPSTATUS":
                    return ImplementAddNewMasterFileData<MembershipStatus>(
                        requestData,
                        prop => prop.MembershipStatusName,
                        _dataContext.MembershipStatusMasterFile
                    );

                case "EDUCATIONALATTAINMENT":
                    return ImplementAddNewMasterFileData<EducationalAttainment>(
                        requestData,
                        prop => prop.EducationalAttainmentName,
                        _dataContext.EducationalAttainmentMasterFile
                    );

                case "CLIENTSOURCE":
                    return ImplementAddNewMasterFileData<ClientSource>(
                        requestData,
                        prop => prop.ClientSourceName,
                        _dataContext.ClientSourceMasterFile
                    );
                case "CLIENTREFERENCE":
                    return ImplementAddNewMasterFileData<ClientReference>(
                        requestData,
                        prop => prop.ClientReferenceName,
                        _dataContext.ClientReferenceMasterFile
                    );

                case "MEMBERSHIPTYPE":
                    return ImplementAddNewMasterFileData<MembershipType>(
                        requestData,
                        prop => prop.MembershipTypeName,
                        _dataContext.MembershipTypeMasterFile
                    );

                case "RELIGION":
                    return ImplementAddNewMasterFileData<Religion>(
                        requestData,
                        prop => prop.ReligionName,
                        _dataContext.ReligionMasterFile
                    );

                case "NATIONALITY":
                    return ImplementAddNewMasterFileData<Nationality>(
                        requestData,
                        prop => prop.NationalityName,
                        _dataContext.NationalityMasterFile
                    );
                default:
                    _logger.LogError("Failed adding master file data", masterFileName);
                    throw new Exception("Failed Adding New Master File Data");
            }
        }

        /*Reqeust to get the data of address masterfiles such as country, region, province, city municipality*/
        public Task<GetAddressResponse> GetAddressMasterFileData(
            IEnumerable<CountryDto> countryData,
            IEnumerable<RegionDto> regionData,
            IEnumerable<ProvinceDto> provinceData,
            IEnumerable<MunicipalityDto> municipalityData,
            IEnumerable<BarangayDto> barangayData,
            string request
        )
        {
            switch (request)
            {
                case "COUNTRY":
                    return ImplementGetAddressMasterFileData<Country>(
                        countryData,
                        regionData,
                        provinceData,
                        municipalityData,
                        barangayData,
                        _dataContext.CountryMasterFile
                    );
                case "REGION":
                    return ImplementGetAddressMasterFileData<Region>(
                        countryData,
                        regionData,
                        provinceData,
                        municipalityData,
                        barangayData,
                        _dataContext.RegionMasterFile
                    );
                case "PROVINCE":
                    return ImplementGetAddressMasterFileData<Province>(
                        countryData,
                        regionData,
                        provinceData,
                        municipalityData,
                        barangayData,
                        _dataContext.ProvinceMasterFile
                    );
                case "CITYMUNICIPALITY":
                    return ImplementGetAddressMasterFileData<CityMunicipality>(
                        countryData,
                        regionData,
                        provinceData,
                        municipalityData,
                        barangayData,
                        _dataContext.CityMunicipalityMasterFile
                    );
                case "BARANGAY":
                    return ImplementGetAddressMasterFileData<Barangay>(
                        countryData,
                        regionData,
                        provinceData,
                        municipalityData,
                        barangayData,
                        _dataContext.BarangayMasterFile
                    );
                default:
                    throw new Exception($"Failed retrieving {request} master file");
            }
        }

        public async Task<GetAddressResponse> ImplementGetAddressMasterFileData<TEntity>(
            IEnumerable<CountryDto> countryData,
            IEnumerable<RegionDto> regionData,
            IEnumerable<ProvinceDto> provinceData,
            IEnumerable<MunicipalityDto> municipalityData,
            IEnumerable<BarangayDto> barangayData,
            DbSet<TEntity> dbSet
        )
            where TEntity : class
        {
            /*Check if there is already data in the requested address masterfile*/
            var hasData = dbSet.Any();

            if (!hasData)
            {
                var entityType = typeof(TEntity);

                switch (entityType.Name)
                {
                    case "Country":
                        var countryEntities = countryData
                            .Select(countries =>
                            {
                                Country country = new();
                                return country.Create(countryName: countries.CountryName);
                            })
                            .ToList();

                        await _dataContext.CountryMasterFile.AddRangeAsync(countryEntities!);
                        await _dataContext.SaveChangesAsync();

                        var getMasterFileData = await _dataContext.CountryMasterFile.ToListAsync();
                        var getMasterFileResponse = _mapper.Map<GetAddressResponse>(
                            getMasterFileData
                        );

                        return getMasterFileResponse;

                    /*In this case, im joining both the region data and country data from json based on
                    a common property called country code,then assigns country name to regions country name*/
                    case "Region":
                        var regionEntities = regionData
                            .Join(
                                countryData,
                                region => region.CountryCode,
                                country => country.CountryCode,
                                (region, country) =>
                                    new { RegionDto = region, CountryDto = country }
                            )
                            .Select(pair =>
                            {
                                Region region = new();
                                return region.Create(
                                    regionName: pair.RegionDto.RegionName,
                                    countryName: pair.CountryDto.CountryName
                                );
                            })
                            .ToList();

                        await _dataContext.RegionMasterFile.AddRangeAsync(regionEntities!);
                        await _dataContext.SaveChangesAsync();

                        var getRegionMasterFileData =
                            await _dataContext.RegionMasterFile.ToListAsync();
                        var getRegionMasterFileResponse = _mapper.Map<GetAddressResponse>(
                            getRegionMasterFileData
                        );
                        return getRegionMasterFileResponse;

                    case "Province":
                        var provinceEntities = provinceData
                            .Join(
                                regionData,
                                province => province.RegionCode,
                                region => region.RegionCode,
                                (province, region) =>
                                    new { ProvinceDto = province, RegionDto = region }
                            )
                            .Join(
                                countryData,
                                pair => pair.RegionDto.CountryCode,
                                country => country.CountryCode,
                                (pair, country) =>
                                    new
                                    {
                                        ProvinceDto = pair.ProvinceDto,
                                        RegionDto = pair.RegionDto,
                                        CountryDto = country
                                    }
                            )
                            .Select(provinces =>
                            {
                                Province province = new();
                                return province.Create(
                                    provinceName: provinces.ProvinceDto.ProvinceName,
                                    regionName: provinces.RegionDto.RegionName,
                                    countryName: provinces.CountryDto.CountryName
                                );
                            })
                            .ToList();

                        await _dataContext.ProvinceMasterFile.AddRangeAsync(provinceEntities);
                        await _dataContext.SaveChangesAsync();

                        var getProvincesMasterFileData =
                            await _dataContext.ProvinceMasterFile.ToListAsync();
                        var getProvinceMasterFileResponse = _mapper.Map<GetAddressResponse>(
                            getProvincesMasterFileData
                        );
                        return getProvinceMasterFileResponse;

                    case "CityMunicipality":
                        var cityMunicipalityEntities = municipalityData
                            .Join(
                                provinceData,
                                municipality => municipality.ProvinceCode,
                                province => province.ProvinceCode,
                                (municipality, province) =>
                                    new { MunicipalityDto = municipality, ProvinceDto = province }
                            )
                            .Join(
                                regionData,
                                pair1 => pair1.ProvinceDto.RegionCode,
                                region => region.RegionCode,
                                (pair1, region) =>
                                    new
                                    {
                                        MunicipalityDto = pair1.MunicipalityDto,
                                        ProvinceDto = pair1.ProvinceDto,
                                        RegionDto = region
                                    }
                            )
                            .Join(
                                countryData,
                                pair2 => pair2.RegionDto.CountryCode,
                                country => country.CountryCode,
                                (pair2, country) =>
                                    new
                                    {
                                        MunicipalityDto = pair2.MunicipalityDto,
                                        ProvinceDto = pair2.ProvinceDto,
                                        RegionDto = pair2.RegionDto,
                                        CountryDto = country
                                    }
                            )
                            .Select(municipalities =>
                            {
                                CityMunicipality cityMunicipality = new();
                                return cityMunicipality.Create(
                                    cityMunicipalityName: municipalities
                                        .MunicipalityDto
                                        .MunicipalityName,
                                    provinceName: municipalities.ProvinceDto.ProvinceName,
                                    regionName: municipalities.RegionDto.RegionName,
                                    countryName: municipalities.CountryDto.CountryName
                                );
                            })
                            .ToList();

                        await _dataContext.CityMunicipalityMasterFile.AddRangeAsync(
                            cityMunicipalityEntities
                        );
                        await _dataContext.SaveChangesAsync();

                        var getCityMunicipalityMasterFileData =
                            await _dataContext.CityMunicipalityMasterFile.ToListAsync();

                        var getCityMunicipalityMasterFileResponse = _mapper.Map<GetAddressResponse>(
                            getCityMunicipalityMasterFileData
                        );

                        return getCityMunicipalityMasterFileResponse;

                    case "Barangay":
                        var barangayEntities = barangayData
                            .Join(
                                municipalityData,
                                barangay => barangay.MunicipalityCode,
                                municipality => municipality.MunicipalityCode,
                                (barangay, municipality) =>
                                    new { BarangayDto = barangay, MunicipalityDto = municipality }
                            )
                            .Join(
                                provinceData,
                                pair1 => pair1.MunicipalityDto.ProvinceCode,
                                province => province.ProvinceCode,
                                (pair1, province) =>
                                    new
                                    {
                                        BarangayDto = pair1.BarangayDto,
                                        MunicipalityDto = pair1.MunicipalityDto,
                                        ProvinceDto = province
                                    }
                            )
                            .Join(
                                regionData,
                                pair2 => pair2.ProvinceDto.RegionCode,
                                region => region.RegionCode,
                                (pair2, region) =>
                                    new
                                    {
                                        BarangayDto = pair2.BarangayDto,
                                        MunicipalityDto = pair2.MunicipalityDto,
                                        ProvinceDto = pair2.ProvinceDto,
                                        RegionDto = region
                                    }
                            )
                            .Join(
                                countryData,
                                pair3 => pair3.RegionDto.CountryCode,
                                country => country.CountryCode,
                                (pair3, country) =>
                                    new
                                    {
                                        BarangayDto = pair3.BarangayDto,
                                        MunicipalityDto = pair3.MunicipalityDto,
                                        ProvinceDto = pair3.ProvinceDto,
                                        RegionDto = pair3.RegionDto,
                                        CountryDto = country
                                    }
                            )
                            .Select(barangays =>
                            {
                                Barangay barangay = new();
                                return barangay.Create(
                                    barangayName: barangays.BarangayDto.BarangayName,
                                    cityMunicipalityName: barangays
                                        .MunicipalityDto
                                        .MunicipalityName,
                                    provinceName: barangays.ProvinceDto.ProvinceName,
                                    regionName: barangays.RegionDto.RegionName,
                                    countryName: barangays.CountryDto.CountryName
                                );
                            })
                            .ToList();

                        await _dataContext.BarangayMasterFile.AddRangeAsync(barangayEntities);
                        await _dataContext.SaveChangesAsync();

                        var getBarangayMasterFileData =
                            await _dataContext.BarangayMasterFile.ToListAsync();
                        var getBarangayMasterFileResponse = _mapper.Map<GetAddressResponse>(
                            getBarangayMasterFileData
                        );

                        return getBarangayMasterFileResponse;

                    default:
                        _logger.LogError(
                            "Failed operation in ImplementGetAddressMasterFile, if block, creating and retrieving data"
                        );
                        throw new Exception(
                            "Failed creating and retrieving address master file data"
                        );
                }
            }
            else
            {
                var entityType = typeof(TEntity);

                switch (entityType.Name)
                {
                    case "Country":

                        var getMasterFileData = await _dataContext.CountryMasterFile.ToListAsync();
                        var getMasterFileResponse = _mapper.Map<GetAddressResponse>(
                            getMasterFileData
                        );

                        return getMasterFileResponse;

                    case "Region":

                        var getRegionMasterFileData =
                            await _dataContext.RegionMasterFile.ToListAsync();
                        var getRegionMasterFileResponse = _mapper.Map<GetAddressResponse>(
                            getRegionMasterFileData
                        );
                        return getRegionMasterFileResponse;

                    case "Province":

                        var getProvincesMasterFileData =
                            await _dataContext.ProvinceMasterFile.ToListAsync();
                        var getProvinceMasterFileResponse = _mapper.Map<GetAddressResponse>(
                            getProvincesMasterFileData
                        );
                        return getProvinceMasterFileResponse;

                    case "CityMunicipality":

                        var getCityMunicipalityMasterFileData =
                            await _dataContext.CityMunicipalityMasterFile.ToListAsync();

                        var getCityMunicipalityMasterFileResponse = _mapper.Map<GetAddressResponse>(
                            getCityMunicipalityMasterFileData
                        );

                        return getCityMunicipalityMasterFileResponse;

                    case "Barangay":

                        var getBarangayMasterFileData =
                            await _dataContext.BarangayMasterFile.ToListAsync();
                        var getBarangayMasterFileResponse = _mapper.Map<GetAddressResponse>(
                            getBarangayMasterFileData
                        );

                        return getBarangayMasterFileResponse;

                    default:
                        _logger.LogError(
                            "Failed operation in ImplementGetAddressMasterFile else block, retrieiving data"
                        );
                        throw new Exception(
                            "Failed creating and retrieving address master file data"
                        );
                }
            }
        }

        /*A generic method that adds the new master file to the database*/
        public async Task<AddMasterFileResponse> ImplementAddNewMasterFileData<TEntity>(
            AddMasterFileRequest requestData,
            Func<TEntity, string> getNameFunc,
            DbSet<TEntity> dbSet
        )
            where TEntity : class
        {
            try
            {
                // Retrieve existing data
                var existingData = await dbSet
                    .Where(entity => requestData.MasterFileValue.Contains(getNameFunc.ToString()))
                    .Select(entity => getNameFunc.ToString())
                    .ToListAsync();

                //list data to add in the db except those who are already in the db
                var newData = requestData.MasterFileValue.Except(existingData);

                if (newData.Any())
                {
                    // Create new entities
                    var newEntities = newData.Select(data =>
                    {
                        TEntity newEntity = CreateEntity(data!);
                        return newEntity;
                    });

                    /*Statuc method to create the entity*/
                    static TEntity CreateEntity(string data)
                    {
                        var entityType = typeof(TEntity);

                        if (entityType == typeof(BusinessSector))
                        {
                            BusinessSector businessSector = new();
                            var newEntity = businessSector.Create(data);
                            return (TEntity)(object)newEntity;
                        }
                        else if (entityType == typeof(ClientReference))
                        {
                            ClientReference reference = new();
                            var newEntity = reference.Create(data);
                            return (TEntity)(object)newEntity;
                        }
                        else if (entityType == typeof(ClientSource))
                        {
                            ClientSource source = new();
                            var newEntity = source.Create(data);
                            return (TEntity)(object)newEntity;
                        }
                        else if (entityType == typeof(EconomicActivity))
                        {
                            EconomicActivity economicActivity = new();
                            var newEntity = economicActivity.Create(data);
                            return (TEntity)(object)newEntity;
                        }
                        else if (entityType == typeof(EducationalAttainment))
                        {
                            EducationalAttainment educationalAttainment = new();
                            var newEntity = educationalAttainment.Create(data);
                            return (TEntity)(object)newEntity;
                        }
                        else if (entityType == typeof(MembershipStatus))
                        {
                            MembershipStatus membershipStatus = new();
                            var newEntity = membershipStatus.Create(data);
                            return (TEntity)(object)newEntity;
                        }
                        else if (entityType == typeof(MembershipType))
                        {
                            MembershipType membershipType = new();
                            var newEntity = membershipType.Create(data);
                            return (TEntity)(object)newEntity;
                        }
                        else if (entityType == typeof(Nationality))
                        {
                            Nationality nationality = new();
                            var newEntity = nationality.Create(data);
                            return (TEntity)(object)newEntity;
                        }
                        else if (entityType == typeof(Occupation))
                        {
                            Occupation occupation = new();
                            var newEntity = occupation.Create(data);
                            return (TEntity)(object)newEntity;
                        }
                        else if (entityType == typeof(PrimaryIdentificationType))
                        {
                            PrimaryIdentificationType primaryId = new();
                            var newEntity = primaryId.Create(data);
                            return (TEntity)(object)newEntity;
                        }
                        else
                        {
                            Religion religion = new();
                            var newEntity = religion.Create(data, string.Empty);
                            return (TEntity)(object)newEntity;
                        }
                    }

                    // Add new entities to the DbSet
                    await dbSet.AddRangeAsync(newEntities);
                    await _dataContext.SaveChangesAsync();
                }

                return new AddMasterFileResponse
                {
                    AddResponse = newData.Any()
                        ? "Successfully added new masterfile values"
                        : "All values are already in the master files"
                };
            }
            catch (Exception exception)
            {
                throw new Exception("Failed adding new masterfile values", exception);
            }
        }

        /*A Generic method that gets the list of master file data while also seeding the default
        data if there is no master file data in the database */
        public async Task<MasterFileResponse> ImplementGetMasterFileData<TEntity>(
            Func<TEntity, string> getNameFunc,
            DbSet<TEntity> dbSet
        )
            where TEntity : class
        {
            var hasData = await dbSet.AnyAsync();
            if (!hasData)
            {
                var defaultDataArray = DefaultMasterFileData<TEntity>();
                var newEntities = defaultDataArray
                    .Select(data =>
                    {
                        TEntity entity = CreateEntity(data);
                        return entity;
                    })
                    .ToList();

                /*Statuc method to create the entity*/
                static TEntity CreateEntity(string data)
                {
                    var entityType = typeof(TEntity);

                    if (entityType == typeof(BusinessSector))
                    {
                        BusinessSector businessSector = new();
                        var newEntity = businessSector.Create(data);
                        return (TEntity)(object)newEntity;
                    }
                    else if (entityType == typeof(ClientReference))
                    {
                        ClientReference reference = new();
                        var newEntity = reference.Create(data);
                        return (TEntity)(object)newEntity;
                    }
                    else if (entityType == typeof(ClientSource))
                    {
                        ClientSource source = new();
                        var newEntity = source.Create(data);
                        return (TEntity)(object)newEntity;
                    }
                    else if (entityType == typeof(EconomicActivity))
                    {
                        EconomicActivity economicActivity = new();
                        var newEntity = economicActivity.Create(data);
                        return (TEntity)(object)newEntity;
                    }
                    else if (entityType == typeof(EducationalAttainment))
                    {
                        EducationalAttainment educationalAttainment = new();
                        var newEntity = educationalAttainment.Create(data);
                        return (TEntity)(object)newEntity;
                    }
                    else if (entityType == typeof(MembershipStatus))
                    {
                        MembershipStatus membershipStatus = new();
                        var newEntity = membershipStatus.Create(data);
                        return (TEntity)(object)newEntity;
                    }
                    else if (entityType == typeof(MembershipType))
                    {
                        MembershipType membershipType = new();
                        var newEntity = membershipType.Create(data);
                        return (TEntity)(object)newEntity;
                    }
                    else if (entityType == typeof(Nationality))
                    {
                        Nationality nationality = new();
                        var newEntity = nationality.Create(data);
                        return (TEntity)(object)newEntity;
                    }
                    else if (entityType == typeof(Occupation))
                    {
                        Occupation occupation = new();
                        var newEntity = occupation.Create(data);
                        return (TEntity)(object)newEntity;
                    }
                    else if (entityType == typeof(PrimaryIdentificationType))
                    {
                        PrimaryIdentificationType primaryId = new();
                        var newEntity = primaryId.Create(data);
                        return (TEntity)(object)newEntity;
                    }
                    else
                    {
                        Religion religion = new();
                        var newEntity = religion.Create(data, string.Empty);
                        return (TEntity)(object)newEntity;
                    }
                }

                /*Saving the llist of entities to the database*/
                await dbSet.AddRangeAsync(newEntities);
                await _dataContext.SaveChangesAsync();

                /*Retrieving the data from the database*/
                var getMasterFileData = await dbSet.ToListAsync();
                var getMasterFileResponse = _mapper.Map<MasterFileResponse>(getMasterFileData);
                return getMasterFileResponse;
            }
            else
            {
                var getMasterFileData = await dbSet.ToListAsync();
                var getMasterFileResponse = _mapper.Map<MasterFileResponse>(getMasterFileData);
                return getMasterFileResponse;
            }
        }

        /*Returns an array of default data for a specific master file*/
        private static string[] DefaultMasterFileData<TEntity>()
            where TEntity : class
        {
            var entityType = typeof(TEntity);

            if (entityType.Name.Equals("BusinessSector"))
            {
                string[] businessNatureArray =
                {
                    "Agriculture",
                    "Enterprise",
                    "Farming",
                    "Fishing",
                    "Manufacturing",
                    "Services",
                    "Others",
                };

                return businessNatureArray;
            }
            else if (entityType.Name.Equals("ClientReference"))
            {
                string[] clientReferenceArray =
                {
                    "Employee",
                    "Facebook",
                    "Friends",
                    "Institutional Partnerships",
                    "Others",
                    "RAFI MFI Client",
                    "RAFI Website"
                };

                return clientReferenceArray;
            }
            else if (entityType.Name.Equals("ClientSource"))
            {
                string[] clientSourceArray = { "Chat Bot", "TS Approach" };

                return clientSourceArray;
            }
            else if (entityType.Name.Equals("EconomicActivity"))
            {
                string[] economiActivityArray =
                {
                    "Accomodations",
                    "AgrivetSupply",
                    "Boarding House / Room for Rent",
                    "Buy and Sell",
                    "Canteen/Carenderia",
                    "Car Services (wash, repair, etc.)",
                    "Catering Services",
                    "Cattle Raising",
                    "Cellphone/Gadget Shop",
                    "Coco Lumber",
                    "Computer Shop / Internet Cafe",
                    "Cosmetics Soap Making",
                    "Crab Fattening",
                    "Direct Selling / Retailing",
                    "Dried Fish",
                    "Drinks and Beverages",
                    "Farming (Corn)",
                    "Farming (Flowers)",
                    "Farming (HVC)",
                    "Farming (Rice)",
                    "Fish Vending",
                    "Fishing",
                    "Flower Vending",
                    "Bake shop, Coffee shop, etc.,",
                    "Frozen Food Selling",
                    "Fruits and Vegetables",
                    "Furniture Making",
                    "General Merchandise",
                    "Glass and Aluminum",
                    "Goat Farming",
                    "Handwoven Item (Abaca, Amakan, Nipa, etc.,)",
                    "Hog Raising / Farming",
                    "Housing Improvement",
                    "Jewelry and Accessories",
                    "Landscaping",
                    "Laundry Shop",
                    "Online Selling",
                    "Others",
                    "Oyster Breeding",
                    "Photography and Photo Editing",
                    "Pig Fattening",
                    "Potter and Sculpture",
                    "Poultry",
                    "Pre Packed Food",
                    "Prepared Food Vending",
                    "Souvenir Items",
                    "T-shirt Printing",
                    "Tailoring",
                    "Transport Operator, Driver, Maintainance etc.,",
                    "Travel and Tour Services",
                    "Unspecefied"
                };

                return economiActivityArray;
            }
            else if (entityType.Name.Equals("MembershipStatus"))
            {
                string[] membershipStatusArray = { "Member", "Client", "Borrower", };
                return membershipStatusArray;
            }
            else if (entityType.Name.Equals("MembershipType"))
            {
                string[] membershipTypeArray = { "Balik RAFI", "New Loan", "Repeat Loan", };
                return membershipTypeArray;
            }
            else if (entityType.Name.Equals("Occupation"))
            {
                string[] occupationArray =
                {
                    "Carpenter",
                    "Clerk",
                    "Construction Worker",
                    "Cook",
                    "Entrepreneur",
                    "Farmer",
                    "Fisherman",
                    "Government Employee",
                    "Driver",
                    "Not Applicable",
                    "Production / Factory Worker",
                    "Professional",
                    "Sales Man / Sales Lady",
                    "Seaman / Domestic Helper / OFW",
                    "Security Guard",
                    "Social Service Worker",
                    "Technician",
                    "Welder",
                    "Others"
                };
                return occupationArray;
            }
            else if (entityType.Name.Equals("PrimaryIdentificationType"))
            {
                string[] primaryIdTypesArray =
                {
                    "Alient Certification of Registration/Immigrant Certificate of Registration",
                    "Alumni Id",
                    "Barangay Certification",
                    "Cedula/Community Tax Certificate",
                    "Certification from the National Council of the Welfare Disabled Persons",
                    "Company Id",
                    "Credit Card with Photo",
                    "Department of Social Welfare and Development (DSWD) Certification",
                    "Driver's License",
                    "Fire Arms License Card",
                    "Government Service Insurance (GSIS) e-Card",
                    "Government Service Record",
                    "Home Development Mutual Fund Id",
                    "Integrated Bar of the Philippines Id",
                    "Land Title",
                    "National Bureau of Investigation Clearance",
                    "OFW ID",
                    "Overseas Workers Welfare Administration (OWWA Id)",
                    "PLRA ID",
                    "PSA Birth Certificate",
                    "PSA Marriage Contract",
                    "PWD Id",
                    "Passport",
                    "Phil Health Card",
                    "Police Clearance",
                    "Postal Id",
                    "Professional Regulations Commi",
                    "RMF Membership Id",
                    "Seaman's Book",
                    "Senior Citizen Card",
                    "Social Security Sytem (SSS) Card",
                    "TIN Card",
                    "Transcript of Records from University or College",
                    "Voter's Id",
                    "Voter Certification"
                };
                return primaryIdTypesArray;
            }
            else if (entityType.Name.Equals("Religion"))
            {
                string[] religionArray =
                {
                    "Christianity",
                    "Islam",
                    "Hinduism",
                    "Buddhism",
                    "Judaism",
                    "Sikhism",
                    "Bahá'í Faith",
                    "Jainism",
                    "Shinto",
                    "Taoism",
                    "Zoroastrianism",
                    "Wicca",
                };

                return religionArray;
            }
            else if (entityType.Name.Equals("EducationalAttainment"))
            {
                string[] qualificationArray =
                {
                    "College Graduate",
                    "College Level",
                    "Elementary Graduate",
                    "Elementary Level",
                    "High School Graduate",
                    "High School Level",
                    "Post Graduate",
                    "Vocational"
                };

                return qualificationArray;
            }
            else
            {
                string[] nationalityArray =
                {
                    "Filipino",
                    "American",
                    "British",
                    "Chinese",
                    "Indian",
                    "Japanese",
                    "Korean",
                    "Mexican",
                    "Russian",
                    "Australian",
                    "Canadian",
                    "French",
                    "German",
                    "Italian",
                    "Spanish",
                    "Brazilian",
                    "Indonesian",
                    "Thai",
                    "Vietnamese",
                    "Swiss"
                };
                return nationalityArray;
            }

            //Additional master file default values will be added here for the address masterfiles
        }
    }
}
