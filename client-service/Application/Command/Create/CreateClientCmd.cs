using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection.Metadata;
using System.Threading.Tasks;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using ClientService.Domain.Entity;
using ClientService.Domain.Repositories;
using ClientService.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace ClientService.Application.Command.Create
{
    public class CreateClientCmd : ICreateClientCmd
    {
        private readonly IClientRepository _iclient;
        private readonly ILogger<CreateClientCmd> _logger;
        private readonly IConfiguration _configuration;
        private readonly IMasterFileRepository _masterFile;
        private readonly DataContext _context;

        public CreateClientCmd(
            IClientRepository iclient,
            IMasterFileRepository masterFile,
            ILogger<CreateClientCmd> logger,
            IConfiguration configuration,
            DataContext context
        )
        {
            _iclient = iclient;
            _logger = logger;
            _configuration = configuration;
            _masterFile = masterFile;
            _context = context;
        }

        public async Task<CreateClientResponse> HandleCreateCommand(CreateClientRequest request)
        {
            try
            {
                /*Get the blob connection string from azure deployment environment variable*/
                string blobConnectionString = Environment.GetEnvironmentVariable(
                    "Azure_Blob_ConnectionString"
                )!;

                /*Get the connection string from secrets.json, triggers when testing in local environment*/
                if (blobConnectionString.IsNullOrEmpty())
                {
                    /*Blob connection string*/
                    blobConnectionString = _configuration.GetConnectionString(
                        "BlobConnectionString"
                    )!;
                }

                /*Blob container name*/
                var containerName = "client-service-container";

                /*Client Document*/
                var newClientDocs = request
                    .ClientDetails.DocumentDetails.Select(async details =>
                    {
                        /*Client document folder structure*/
                        var clientBlobFileName =
                            $"Client/{request.ClientDetails.PersonDetails.FirstName}{request.ClientDetails.PersonDetails.LastName}/PersonalFiles/{details.FileType}/{details.FileName}{Guid.NewGuid()}.{details.FileExtenstion}";

                        BlobServiceClient blobServiceClient = new BlobServiceClient(
                            blobConnectionString
                        );
                        BlobContainerClient blobContainerClient =
                            blobServiceClient.GetBlobContainerClient(containerName);

                        BlobClient blobClient = await UploadToBlob(
                            blobContainerClient,
                            clientBlobFileName,
                            details.ActualFile.ToByteArray(),
                            details.FileExtenstion,
                            _logger
                        );

                        var url = blobClient.Uri.ToString();

                        var newDocument = new DocumentDetails()
                        {
                            FileName = details.FileName,
                            FileExtenstion = details.FileExtenstion,
                            FileType = details.FileType,
                            FilePath = url
                        };

                        return newDocument;
                    })
                    .ToList();

                /*Spouse documents*/
                var newSpouseDocs = request
                    .SpouseDetails.SelectMany(spouse =>
                        spouse.DocumentDetails.Select(async details =>
                        {
                            /*Spouse document folder structure*/
                            var clientBlobFileName =
                                $"Client/{request.ClientDetails.PersonDetails.FirstName}{request.ClientDetails.PersonDetails.LastName}/SpouseFiles/{spouse.PersonDetails.FirstName}{spouse.PersonDetails.LastName}/{details.FileType}/{details.FileName}{Guid.NewGuid()}.{details.FileExtenstion}";

                            BlobServiceClient blobServiceClient = new BlobServiceClient(
                                blobConnectionString
                            );
                            BlobContainerClient blobContainerClient =
                                blobServiceClient.GetBlobContainerClient(containerName);

                            BlobClient blobClient = await UploadToBlob(
                                blobContainerClient,
                                clientBlobFileName,
                                details.ActualFile.ToByteArray(),
                                details.FileExtenstion,
                                _logger
                            );

                            var url = blobClient.Uri.ToString();

                            var newDocument = new DocumentDetails()
                            {
                                FileName = details.FileName,
                                FileExtenstion = details.FileExtenstion,
                                FileType = details.FileType,
                                FilePath = url,
                            };

                            return newDocument;
                        })
                    )
                    .ToList();

                /*Dependant documents*/
                var newDependantDocs = request
                    .DependantDetails.SelectMany(dependant =>
                        dependant.DocumentDetails.Select(async details =>
                        {
                            /*Dependant document folder structure*/
                            var clientBlobFileName =
                                $"Client/{request.ClientDetails.PersonDetails.FirstName}{request.ClientDetails.PersonDetails.LastName}/DependantFiles/{dependant.PersonDetails.FirstName}{dependant.PersonDetails.LastName}/{details.FileType}/{details.FileName}{Guid.NewGuid()}.{details.FileExtenstion}";

                            BlobServiceClient blobServiceClient = new BlobServiceClient(
                                blobConnectionString
                            );
                            BlobContainerClient blobContainerClient =
                                blobServiceClient.GetBlobContainerClient(containerName);

                            BlobClient blobClient = await UploadToBlob(
                                blobContainerClient,
                                clientBlobFileName,
                                details.ActualFile.ToByteArray(),
                                details.FileExtenstion,
                                _logger
                            );

                            var url = blobClient.Uri.ToString();

                            var newDocument = new DocumentDetails()
                            {
                                FileName = details.FileName,
                                FileExtenstion = details.FileExtenstion,
                                FileType = details.FileType,
                                FilePath = url,
                            };

                            return newDocument;
                        })
                    )
                    .ToList();

                /*Send the data to the repository*/
                var response = await _iclient.CreateClient(
                    request,
                    newClientDocs,
                    newSpouseDocs,
                    newDependantDocs
                );
                return response;
            }
            catch (ValidationException exception)
            {
                CreateClientResponse response =
                    new() { Result = $"Validation Error, {exception.Message}" };
                return response;
            }
        }

        /*Method that uploads files to blob*/
        private static async Task<BlobClient> UploadToBlob(
            BlobContainerClient containerClient,
            string blobFileName,
            byte[] data,
            string fileExtension,
            ILogger<CreateClientCmd> logger
        )
        {
            BlobClient blobClient = containerClient.GetBlobClient(blobFileName);

            /*aims to solve incompatability issue of the blob data that results to a force
            download whenever it is accessed  via URL, the solution is to declare the content-disposition as "inlne"
            and explicit declaration of image extensions that was concatinated in the blob file name */
            var fileExtensionMap = new Dictionary<string, string>
            {
                { "JPG", "jpg" },
                { "JPEG", "jpeg" },
                { "PNG", "png" },
                { "BMP", "bmp" },
                { "WEBP", "webp" },
                { "SVG", "svg" },
                { "TIFF", "tiff" },
                { "TIF", "tif" },
                { "GIF", "gif" },
                { "HEIC", "heic" }
            };

            if (fileExtensionMap.TryGetValue(fileExtension.Trim().ToUpper(), out var extension))
            {
                using (MemoryStream memoryStream = new(data))
                {
                    await blobClient.UploadAsync(memoryStream, true);
                    await blobClient.SetHttpHeadersAsync(
                        new BlobHttpHeaders
                        {
                            ContentType = $"image/{extension}",
                            ContentDisposition = "inline",
                        }
                    );

                    return blobClient;
                }
            }
            else
            {
                logger.LogError("Failed blob upload operation at create client command");
                throw new Exception("No matching file extension found");
            }
        }

        /*Method that adds new master  values to the master file*/
        public async Task<AddMasterFileResponse> HandleAddMasterFileCommand(
            AddMasterFileRequest request
        )
        {
            try
            {
                /*Map the proto enums with its equivalent string value*/
                var addMasterFileMap = new Dictionary<MasterFilesEnum, string>
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
                    { MasterFilesEnum.Religion, "RELIGION" },
                    { MasterFilesEnum.Nationailty, "NATIONALITY" }
                };

                if (addMasterFileMap.TryGetValue(request.MasterFileName, out var masterFileName))
                {
                    var response = await _masterFile.AddNewMasterFileData(masterFileName, request);
                    return response;
                }
                else
                {
                    AddMasterFileResponse response =
                        new() { AddResponse = "No Matching Master File Type Available" };
                    return response;
                }
            }
            catch (Exception e)
            {
                _logger.LogError("Failed operation in HandleAddMasterFileCmd", e);
                throw new Exception("Failed operation in HandleAddMasterFileCmd", e);
            }
        }
    }
}
